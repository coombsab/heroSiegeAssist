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
}