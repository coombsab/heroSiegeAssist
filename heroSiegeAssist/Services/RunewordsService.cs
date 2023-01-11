namespace heroSiegeAssist.Services;

public class RunewordsService {
  private readonly RunewordsRepository _runewordsRepository;

  public RunewordsService(RunewordsRepository runewordsRepository)
  {
    _runewordsRepository = runewordsRepository;
  }

  public List<Runeword> GetRunewords() {
    return _runewordsRepository.GetRunewords();
  }

  public Runeword GetRunewordByName(string name) {
    Runeword runeword = _runewordsRepository.GetRunewordByName(name);
    if (runeword == null) {
      throw new Exception("Could not this runeword: " + name);
    }

    return runeword;
  }

  public List<Runeword> GetRunewordsByRune(Rune rune) {
    return _runewordsRepository.GetRunewordsByRune(rune);
  }

  public Runeword AddRuneword(Runeword runewordData) {
    _runewordsRepository.AddRuneword(runewordData);

    Runeword runeword = this.GetRunewordByName(runewordData.Name);
    return runeword;
  }
}