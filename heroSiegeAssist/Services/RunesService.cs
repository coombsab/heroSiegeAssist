namespace heroSiegeAssist.Services;

public class RunesService
{
  private readonly RunesRepository _runesRepository;
  private readonly RunewordsService _runewordsService;

  public RunesService(RunesRepository runesRepository, RunewordsService runewordsService)
  {
    _runesRepository = runesRepository;
    _runewordsService = runewordsService;
  }

  public List<Rune> GetRunes()
  {
    List<Rune> runes = _runesRepository.GetRunes();
    runes.ForEach(rune =>
    {
      List<Runeword> runewords = _runewordsService.GetRunewordsByRune(rune);
      rune.PossibleRunewords = runewords;
    });
    return runes;
  }

  public List<MyRune> GetRunesByAccountId(string accountId)
  {
    return _runesRepository.GetRunesByAccountId(accountId);
  }

  public List<MyRune> GetRunesForAccounts(Accounts accounts)
  {
    List<MyRune> runes = new List<MyRune>();
    accounts.AccountIds.ForEach(accountId =>
    {
      runes = runes.Concat(_runesRepository.GetRunesByAccountId(accountId)).ToList();
    });

    return runes;
  }


  public List<Profile> GetAccountsWithRunes()
  {
    return _runesRepository.GetAccountsWithRunes();
  }

  public Rune GetRuneByName(string name)
  {
    Rune rune = _runesRepository.GetRuneByName(name);
    if (rune == null)
    {
      throw new Exception("Could not this rune: " + name);
    }

    return rune;
  }

  public MyRune GetMyRuneById(int runeId)
  {
    MyRune rune = _runesRepository.GetMyRuneById(runeId);
    if (rune == null)
    {
      throw new Exception("Could not find my rune: " + runeId);
    }

    return rune;
  }

  public Rune AddRune(Rune runeData)
  {
    _runesRepository.AddRune(runeData);

    Rune rune = this.GetRuneByName(runeData.Name);
    List<Runeword> runewords = _runewordsService.GetRunewordsByRune(rune);
    rune.PossibleRunewords = runewords;
    return rune;
  }

  public MyRune AddToMyRunes(MyRune myRuneData, string accountId)
  {
    myRuneData.AccountId = accountId;
    myRuneData.Id = _runesRepository.AddToMyRunes(myRuneData);

    MyRune rune = this.GetMyRuneById(myRuneData.Id);
    List<Runeword> runewords = _runewordsService.GetRunewordsByRune((Rune)myRuneData);
    rune.PossibleRunewords = runewords;

    return rune;
  }

  public MyRune EditMyRune(MyRune myRuneData, string accountId)
  {
    myRuneData.AccountId = accountId;
    MyRune rune = this.GetMyRuneById(myRuneData.Id);
    
    _runesRepository.EditMyRune(myRuneData);

    if (myRuneData.Quantity > 0) {
      rune.UpdatedAt = DateTime.Now;
      rune.Quantity = myRuneData.Quantity;
    }

    return rune;
  }

  public MyRune DeleteMyRune(int runeId, string accountId)
  {
    MyRune rune = this.GetMyRuneById(runeId);

    if (rune.AccountId != accountId) {
      throw new Exception("You cannot delete runes that do not belong to you.");
    }

    _runesRepository.DeleteMyRune(runeId);

    return rune;
  }

  public string DeleteMyRunes(string accountId)
  {
    string message = _runesRepository.DeleteMyRunes(accountId);

    return message;
  }
}