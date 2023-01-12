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

  public RunewordEffect GetRunewordEffectById(int runewordEffectId)
  {
    string sql = @"
      SELECT *
      FROM runewordeffects
      WHERE runewordeffects.id = @runewordEffectId;
    ";

    return _db.QueryFirstOrDefault<RunewordEffect>(sql, new { runewordEffectId });
  }

  public int AddEffectToRuneword(RunewordEffect runewordEffectData)
  {
    string sql = @"
      INSERT INTO runewordeffects (
        name, runewordId
      )
      VALUES (
        @Name, @RunewordId
      );
      SELECT LAST_INSERT_ID();
    ";
    return _db.ExecuteScalar<int>(sql, runewordEffectData);
  }
}