namespace heroSiegeAssist.Services;

public class RunewordsService {
  private readonly RunewordsRepository _runewordsRepository;
  private readonly RuneRunewordsService _runeRunewordsService;
  private readonly EffectsService _effectsService;
  private readonly AbilitiesService _abilitiesService;
  private readonly ItemsService _itemsService;

  public RunewordsService(RunewordsRepository runewordsRepository, RuneRunewordsService runeRunewordsService, EffectsService effectsService, AbilitiesService abilitiesService, ItemsService itemsService)
  {
    _runewordsRepository = runewordsRepository;
    _runeRunewordsService = runeRunewordsService;
    _effectsService = effectsService;
    _abilitiesService = abilitiesService;
    _itemsService = itemsService;
  }

  public List<Runeword> GetRunewords() {
    List<Runeword> runewords = _runewordsRepository.GetRunewords();
    runewords.ForEach(runeword => {
      List<Rune> runes = this.GetRunesByRunewordName(runeword.Name);
      runeword.Runes = runes;

      List<RunewordEffect> runewordEffects = this.GetEffectsByRunewordName(runeword.Name);
      runeword.Effects = runewordEffects;

      List<Ability> abilities = this.GetAbilitiesByRunewordName(runeword.Name);
      runeword.Abilities = abilities;

      List<Item> items = this.GetItemsByRunewordName(runeword.Name);
      runeword.Items = items;
    });

    return runewords;
  }

  public Runeword GetRunewordByName(string name) {
    Runeword runeword = _runewordsRepository.GetRunewordByName(name);
    if (runeword == null) {
      throw new Exception("Could not this runeword: " + name);
    }

    List<Rune> runes = this.GetRunesByRunewordName(runeword.Name);
    runeword.Runes = runes;

    List<RunewordEffect> runewordEffects = this.GetEffectsByRunewordName(runeword.Name);
    runeword.Effects = runewordEffects;

    List<Ability> abilities = this.GetAbilitiesByRunewordName(runeword.Name);
    runeword.Abilities = abilities;

    List<Item> items = this.GetItemsByRunewordName(runeword.Name);
    runeword.Items = items;

    return runeword;
  }

  public List<Runeword> GetRunewordsByRune(Rune rune) {
    return _runewordsRepository.GetRunewordsByRune(rune);
  }

  public Runeword AddRuneword(Runeword runewordData) {
    _runewordsRepository.AddRuneword(runewordData);
    runewordData.Runes.ForEach(rune => {
      _runeRunewordsService.AddRuneToRuneword(new RuneRuneword(rune.Name, runewordData.Name));
    });
    runewordData.Effects.ForEach(effect => {
      _effectsService.AddEffectToRuneword(new RunewordEffect(effect.Name, runewordData.Name));
    });
    runewordData.Abilities.ForEach(ability => {
      _abilitiesService.AddAbilityToRuneword(new RunewordAbility(ability.Name, runewordData.Name));
    });
    runewordData.Items.ForEach(item => {
      _itemsService.AddItemToRuneword(new RunewordItem(item.Name, runewordData.Name));
    });

    Runeword runeword = this.GetRunewordByName(runewordData.Name);
    return runeword;
  }

  public List<Rune> GetRunesByRunewordName(string name)
  {
    return _runewordsRepository.GetRunesByRunewordName(name);
  }

  public List<RunewordEffect> GetEffectsByRunewordName(string name) {
    return _runewordsRepository.GetEffectsByRunewordName(name);
  }

  public List<Ability> GetAbilitiesByRunewordName(string name) {
    return _runewordsRepository.GetAbilitiesByRunewordName(name);
  }

  public List<Item> GetItemsByRunewordName(string name) {
    return _runewordsRepository.GetItemsByRunewordName(name);
  }

  public Runeword EditRuneword(Runeword runewordData) {
    Runeword runeword = this.GetRunewordByName(runewordData.Name);

    runeword.ItemSlot = runewordData.ItemSlot ?? runeword.ItemSlot;
    runeword.ItemType = runewordData.ItemType ?? runeword.ItemType;

    _runewordsRepository.EditRuneword(runeword);
    return runeword;
  }

  public Runeword DeleteRuneword(string runewordName) {
    Runeword runeword = this.GetRunewordByName(runewordName);
    _runewordsRepository.DeleteRuneword(runeword);
    return runeword;
  }
}