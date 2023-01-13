namespace heroSiegeAssist.Repositories;

public class RunesRepository
{
  private readonly IDbConnection _db;

  public RunesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Rune> GetRunes()
  {
    string sql = @"
      SELECT *
      FROM runes;
    ";

    return _db.Query<Rune>(sql).ToList();
  }

  public List<MyRune> GetRunesByAccountId(string accountId)
  {
    string sql = @"
      SELECT *
      FROM possessedrunes
      WHERE possessedrunes.accountId = @accountId;
    ";

    return _db.Query<MyRune>(sql, new { accountId }).ToList();
  }


  public List<Profile> GetAccountsWithRunes()
  {
    string sql = @"
      SELECT DISTINCT acc.*
      FROM possessedrunes pr
      JOIN accounts acc
      ON acc.id = pr.accountId;
    ";

    return _db.Query<Profile>(sql).ToList();
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

  public MyRune GetMyRuneByName(string name)
  {
    string sql = @"
      SELECT *
      FROM possessedrunes
      WHERE name = @name;
    ";

    return _db.QueryFirstOrDefault<MyRune>(sql, new { name });
  }

  public void AddRune(Rune runeData)
  {
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


  public void AddToMyRunes(MyRune myRuneData)
  {
    string sql = @"
      INSERT INTO possessedrunes (
        name, effect, tier, dropRate, img, quantity, accountId
      )
      VALUES (
        @Name, @Effect, @Tier, @DropRate, @Img, @Quantity, @AccountId
      );
      SELECT LAST_INSERT_ID();
    ";

    string name = _db.ExecuteScalar<string>(sql, myRuneData);
  }
}