namespace heroSiegeAssist.Services;

public class EffectsService {
  private readonly EffectsRepository _effectsRepository;

  public EffectsService(EffectsRepository effectsRepository)
  {
    _effectsRepository = effectsRepository;
  }

  public List<EffectText> GetEffectsText() {
    return _effectsRepository.GetEffectsText();
  }

  public EffectText GetEffectsTextByName(string name) {
    EffectText effectText = _effectsRepository.GetEffectTextByName(name);

    if (effectText == null) {
      throw new Exception("Could not find effecttext: " + name);
    }

    return effectText;
  }

  public EffectText AddEffectText(EffectText effectTextData) {
    _effectsRepository.AddEffectText(effectTextData);

    EffectText effectText = this.GetEffectsTextByName(effectTextData.Name);

    return effectText;
  }

  public RunewordEffect GetRunewordEffectById(int runewordEffectId) {
    RunewordEffect runewordEffect = _effectsRepository.GetRunewordEffectById(runewordEffectId);
    if (runewordEffect == null) {
      throw new Exception("Could not find runeword effect by id " + runewordEffectId);
    }

    return runewordEffect;
  }

  public RunewordEffect AddEffectToRuneword(RunewordEffect runewordEffectData)
  {
    int runewordEffectId = _effectsRepository.AddEffectToRuneword(runewordEffectData);
    RunewordEffect runewordEffect = this.GetRunewordEffectById(runewordEffectId);

    return runewordEffect;
  }
}