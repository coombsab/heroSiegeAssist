namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RunesController : ControllerBase
{

  private readonly RunesService _runesService;

  public RunesController(RunesService runesService)
  {
    _runesService = runesService;
  }

  [HttpGet]
  public ActionResult<List<Rune>> GetRunes()
  {
    try {
      List<Rune> runes = _runesService.GetRunes();
      return Ok(runes);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Rune> AddRune([FromBody] Rune runeData) {
    try {
      Rune rune = _runesService.AddRune(runeData);
      return Ok(rune);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{accountId}")]
  public ActionResult<List<MyRune>> GetRunesByAccountId(string accountId) {
    try {
      List<MyRune> runes = _runesService.GetRunesByAccountId(accountId);
      return Ok(runes);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("accounts/list")]
  public ActionResult<List<MyRune>> GetRunesForAccounts([FromBody] Accounts accounts) {
    try {
      List<MyRune> runes = _runesService.GetRunesForAccounts(accounts);
      return Ok(runes);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("accounts")]
  public ActionResult<List<Profile>> GetAccountsWithRunes() {
    try {
      List<Profile> accounts = _runesService.GetAccountsWithRunes();
      return Ok(accounts);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}