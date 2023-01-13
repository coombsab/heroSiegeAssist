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

  public MyRune GetMyRuneById(int runeId)
  {
    string sql = @"
      SELECT *
      FROM possessedrunes
      WHERE id = @runeId;
    ";

    return _db.QueryFirstOrDefault<MyRune>(sql, new { runeId });
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


  public int AddToMyRunes(MyRune myRuneData)
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

    int runeId = _db.ExecuteScalar<int>(sql, myRuneData);
    return runeId;
  }

  public void EditMyRune(MyRune myRuneData)
  {
    string sql = @"
      UPDATE possessedrunes
      SET
        quantity = @Quantity
      WHERE id = @Id
      LIMIT 1;
    ";
    int rows = _db.Execute(sql, myRuneData);
    if (rows < 1)
    {
      throw new Exception("Changes to my runes were not saved.");
    }

    if (rows > 1)
    {
      throw new Exception("Something went wrong with editing your rune.  Please contact your DBA.");
    }
  }

  public void DeleteMyRune(int runeId)
  {
    string sql = @"
      DELETE FROM possessedrunes
      WHERE id = @runeId
      LIMIT 1;
    ";

    int rows = _db.Execute(sql, new { runeId });
    if (rows < 1)
    {
      throw new Exception("Changes to my runes were not saved.");
    }

    if (rows > 1)
    {
      throw new Exception("Something went wrong with deleting your rune.  Please contact your DBA.");
    }

  }

  public string DeleteMyRunes(string accountId)
  {
    string sql = @"
      DELETE FROM possessedrunes
      WHERE accountId = @accountId;
    ";

    int rows = _db.Execute(sql, new { accountId });
    if (rows < 1)
    {
      throw new Exception("Changes to my runes were not saved.");
    }

    return "Successfully cleared your runes";
  }
}