namespace heroSiegeAssist.Services;

public class AbilitiesService {
  private readonly AbilitiesRepository _abilitiesRepository;

  public AbilitiesService(AbilitiesRepository abilitiesRepository)
  {
    _abilitiesRepository = abilitiesRepository;
  }

  public List<Ability> GetAbilities() {
    return _abilitiesRepository.GetAbilities();
  }

  public Ability GetAbilityByName(string name) {
    Ability ability = _abilitiesRepository.GetAbilityByName(name);

    if (ability == null) {
      throw new Exception("Could not find ability: " + name);
    }

    return ability;
  }

  public Ability AddAbility(Ability abilityData) {
    _abilitiesRepository.AddAbility(abilityData);

    Ability ability = this.GetAbilityByName(abilityData.Name);
    return ability;
  }

  public RunewordAbility AddAbilityToRuneword(RunewordAbility runewordAbilityData)
  {
    runewordAbilityData.Id = _abilitiesRepository.AddAbilityToRuneword(runewordAbilityData);
    
    return runewordAbilityData;
  }
}