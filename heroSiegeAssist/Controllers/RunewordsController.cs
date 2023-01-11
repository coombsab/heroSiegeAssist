namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RunewordsController : ControllerBase {
  private readonly RunewordsService _runewordsService;

  public RunewordsController(RunewordsService runewordsService)
  {
    _runewordsService = runewordsService;
  }

  [HttpGet]
  public ActionResult<List<Runeword>> GetRunewords() {
    try {
      List<Runeword> runewords = _runewordsService.GetRunewords();
      return Ok(runewords);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Runeword> AddRuneword([FromBody] Runeword runewordData) {
    try {
      Runeword runeword = _runewordsService.AddRuneword(runewordData);
      return Ok(runeword);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}