namespace heroSiegeAssist.Repositories;

public class RunesRepository {
  private readonly IDbConnection _db;

  public RunesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Rune> GetRunes() {
    string sql = @"
      SELECT *
      FROM runes;
    ";

    return _db.Query<Rune>(sql).ToList();
  }

  public Rune GetRuneByName(string name)
  {
    string sql = @"
      SELECT *
      FROM runes
      WHERE name = @name;
    ";

    return _db.QueryFirstOrDefault<Rune>(sql, new { name });
  }

  public void AddRune(Rune runeData) {
    string sql = @"
      INSERT INTO runes (
        name, effect, tier, dropRate, img
      )
      VALUES (
        @Name, @Effect, @Tier, @DropRate, @Img
      );
      SELECT LAST_INSERT_ID();
    ";

    string name = _db.ExecuteScalar<string>(sql, runeData);
  }
}