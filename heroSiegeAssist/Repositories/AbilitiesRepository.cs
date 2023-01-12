namespace heroSiegeAssist.Repositories;

public class AbilitiesRepository {
  private readonly IDbConnection _db;

  public AbilitiesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Ability> GetAbilities() {
    string sql = @"
      SELECT *
      FROM abilities;
    ";

    return _db.Query<Ability>(sql).ToList();
  }

  public Ability GetAbilityByName(string name) {
    string sql = @"
      SELECT *
      FROM abilities
      WHERE abilities.name = @name;
    ";

    return _db.QueryFirstOrDefault<Ability>(sql, new { name });
  }

  public void AddAbility(Ability abilityData) {
    string sql = @"
      INSERT INTO abilities (
        name, description
      )
      VALUES (
        @Name, @Description
      )
    ";

    string abilityName = _db.ExecuteScalar<string>(sql, abilityData);
  }
}