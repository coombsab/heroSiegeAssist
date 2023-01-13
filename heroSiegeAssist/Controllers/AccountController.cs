namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly RunesService _runesService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, RunesService runesService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _runesService = runesService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("runes")]
  [Authorize]
  public async Task<ActionResult<List<MyRune>>> GetMyRunes() {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<MyRune> runes = _runesService.GetRunesByAccountId(userInfo.Id);
      return Ok(runes);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost("runes")]
  [Authorize]
  public async Task<ActionResult<MyRune>> AddToMyRunes([FromBody] MyRune myRuneData) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      MyRune rune = _runesService.AddToMyRunes(myRuneData, userInfo.Id);
      return Ok(rune);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}
