namespace heroSiegeAssist.Repositories;

public class RunewordsRepository
{
  private readonly IDbConnection _db;

  public RunewordsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Runeword> GetRunewords()
  {
    string sql = @"
      SELECT *
      FROM runewords;
    ";

    return _db.Query<Runeword>(sql).ToList();
  }

  public Runeword GetRunewordByName(string name)
  {
    string sql = @"
      SELECT *
      FROM runewords
      WHERE name = @name;
    ";

    return _db.QueryFirstOrDefault<Runeword>(sql, new { name });
  }

  public List<Runeword> GetRunewordsByRune(Rune rune)
  {
    string sql = @"
      SELECT rw.name
      FROM runewords rw
      RIGHT JOIN runerunewords rrw
      ON rrw.runewordId = rw.name
      WHERE rrw.runeId = @Name;
    ";

    return _db.Query<Runeword>(sql, rune).ToList();
  }

  public void AddRuneword(Runeword runewordData)
  {
    string sql = @"
      INSERT INTO runewords (
        name, itemSlot, itemType
      )
      VALUES (
        @Name, @ItemSlot, @ItemType
      );
      SELECT LAST_INSERT_ID();
    ";

    string runewordName = _db.ExecuteScalar<string>(sql, runewordData);
  }

  public List<Rune> GetRunesByRunewordName(string name)
  {
    string sql = @"
      SELECT r.*
      FROM runes r
      RIGHT JOIN runerunewords rrw
      ON rrw.runeId = r.name
      WHERE rrw.runewordId = @name;
    ";

    return _db.Query<Rune>(sql, new { name }).ToList();
  }

  public List<RunewordEffect> GetEffectsByRunewordName(string name)
  {
    string sql = @"
      SELECT *
      FROM runewordeffects
      WHERE runewordeffects.runewordId = @name;
    ";

    return _db.Query<RunewordEffect>(sql, new { name }).ToList();
  }

  public List<Ability> GetAbilitiesByRunewordName(string name)
  {
    string sql = @"
      SELECT a.*
      FROM abilities a
      RIGHT JOIN runewordabilities rwa
      ON rwa.abilityId = a.name
      WHERE rwa.runewordId = @name;
    ";

    return _db.Query<Ability>(sql, new { name }).ToList();
  }
}