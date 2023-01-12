namespace heroSiegeAssist.Repositories;

public class RuneRunewordsRepository {
  private readonly IDbConnection _db;

  public RuneRunewordsRepository(IDbConnection db)
  {
    _db = db;
  }

  public int AddRuneToRuneword(RuneRuneword runeRunewordData) {
    string sql = @"
      INSERT INTO runerunewords (
        runeId, runewordId
      )
      VALUES (
        @RuneId, @RunewordId
      );
      SELECT LAST_INSERT_ID();
    ";

    return _db.QueryFirstOrDefault<int>(sql, runeRunewordData);
  }

  public List<RuneRuneword> GetRunesInRuneword(Runeword runeword) {
    string sql = @"
      SELECT *
      WHERE runewordId = @Name;
    ";

    return _db.Query<RuneRuneword>(sql, runeword).ToList();
  }
}