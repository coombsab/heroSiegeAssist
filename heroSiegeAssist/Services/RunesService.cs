namespace heroSiegeAssist.Services;

public class RunesService {
  private readonly RunesRepository _runesRepository;
  private readonly RunewordsService _runewordsService;

  public RunesService(RunesRepository runesRepository, RunewordsService runewordsService)
  {
    _runesRepository = runesRepository;
    _runewordsService = runewordsService;
  }

  public List<Rune> GetRunes() {
    List<Rune> runes = _runesRepository.GetRunes();
    runes.ForEach(rune => {
      List<Runeword> runewords = _runewordsService.GetRunewordsByRune(rune);
      rune.PossibleRunewords = runewords;
    });
    return runes;
  }

  public Rune GetRuneByName(string name) {
    Rune rune = _runesRepository.GetRuneByName(name);
    if (rune == null) {
      throw new Exception("Could not this rune: " + name);
    }

    return rune;
  }

  public Rune AddRune(Rune runeData) {
    _runesRepository.AddRune(runeData);

    Rune rune = this.GetRuneByName(runeData.Name);
    List<Runeword> runewords = _runewordsService.GetRunewordsByRune(rune);
    rune.PossibleRunewords = runewords;
    return rune;
  }
}