namespace heroSiegeAssist.Services;

public class RunewordsService {
  private readonly RunewordsRepository _runewordsRepository;
  private readonly RuneRunewordsService _runeRunewordsService;

  public RunewordsService(RunewordsRepository runewordsRepository, RuneRunewordsService runeRunewordsService)
  {
    _runewordsRepository = runewordsRepository;
    _runeRunewordsService = runeRunewordsService;
  }

  public List<Runeword> GetRunewords() {
    List<Runeword> runewords = _runewordsRepository.GetRunewords();
    runewords.ForEach(runeword => {
      List<Rune> runes = this.GetRunesByRunewordName(runeword.Name);
      runeword.Runes = runes;
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

    Runeword runeword = this.GetRunewordByName(runewordData.Name);
    return runeword;
  }

  public List<Rune> GetRunesByRunewordName(string name)
  {
    return _runewordsRepository.GetRunesByRunewordName(name);
  }
}