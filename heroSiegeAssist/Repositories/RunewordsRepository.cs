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
      SELECT *
      FROM runewords
      WHERE runewords.rune1 = @Name OR runewords.rune2 = @Name OR runewords.rune3 = @Name OR runewords.rune4 = @Name OR runewords.rune5 = @Name OR runewords.rune6 = @Name;
    ";

    return _db.Query<Runeword>(sql, rune).ToList();
  }

  public void AddRuneword(Runeword runewordData)
  {
    string sql = @"
      INSERT INTO runewords (
        name, itemSlot, itemType, rune1, rune2, rune3, rune4, rune5, rune6
      )
      VALUES (
        @Name, @ItemSlot, @ItemType, @Rune1, @Rune2, @Rune3, @Rune4, @Rune5, @Rune6
      );
      SELECT LAST_INSERT_ID();
    ";

    string runewordName = _db.ExecuteScalar<string>(sql, runewordData);
  }
}