namespace heroSiegeAssist.Repositories;

public class EffectsRepository {
  private readonly IDbConnection _db;

  public EffectsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<EffectText> GetEffectsText() {
    string sql = @"
      SELECT *
      FROM effectstext;
    ";

    return _db.Query<EffectText>(sql).ToList();
  }

  public EffectText GetEffectTextByName(string name) {
    string sql = @"
      SELECT *
      FROM effectstext
      WHERE effectstext.name = @name
    ";

    return _db.QueryFirstOrDefault<EffectText>(sql, new { name });
  }

  public void AddEffectText(EffectText effectTextData) {
    string sql = @"
      INSERT INTO effectstext (
        name
      )
      VALUES (
        @Name
      );
      SELECT LAST_INSERT_ID();
    ";

    string effectTextId = _db.ExecuteScalar<string>(sql, effectTextData);
  }
}