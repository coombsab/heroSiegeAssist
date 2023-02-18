namespace heroSiegeAssist.Services;

public class RuneRunewordsService {
  private readonly RuneRunewordsRepository _runeRunewordsRepository;

  public RuneRunewordsService(RuneRunewordsRepository runeRunewordsRepository)
  {
    _runeRunewordsRepository = runeRunewordsRepository;
  }

  public RuneRuneword AddRuneToRuneword(RuneRuneword runeRunewordData) {
    runeRunewordData.Id = _runeRunewordsRepository.AddRuneToRuneword(runeRunewordData);
    return runeRunewordData;
  }
}