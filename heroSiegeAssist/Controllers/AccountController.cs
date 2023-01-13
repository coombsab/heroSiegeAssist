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

  [HttpPut("runes/{runeId}")]
  [Authorize]
  public async Task<ActionResult<MyRune>> EditMyRune([FromBody] MyRune myRuneData, int runeId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      myRuneData.Id = runeId;
      MyRune rune = _runesService.EditMyRune(myRuneData, userInfo.Id);
      return Ok(rune);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("runes/{runeId}")]
  [Authorize]
  public async Task<ActionResult<MyRune>> DeleteMyRune(int runeId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      MyRune rune = _runesService.DeleteMyRune(runeId, userInfo.Id);
      return Ok(rune);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("runes")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteMyRunes() {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _runesService.DeleteMyRunes(userInfo.Id);
      return Ok(message);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
 
}
