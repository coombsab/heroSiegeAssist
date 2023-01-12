namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RunewordsController : ControllerBase {
  private readonly RunewordsService _runewordsService;
  private readonly RuneRunewordsService _runeRunewordsService;

  public RunewordsController(RunewordsService runewordsService, RuneRunewordsService runeRunewordsService)
  {
    _runewordsService = runewordsService;
    _runeRunewordsService = runeRunewordsService;
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

  // [HttpPost("Runes")]
  // public ActionResult<RuneRuneword> AddRuneToRuneword([FromBody] RuneRuneword runeRunewordData) {
  //   try {
  //     RuneRuneword runeRuneword = _runeRunewordsService.AddRuneToRuneword(runeRunewordData);
  //     return Ok(runeRuneword);
  //   }
  //   catch(Exception e) {
  //     return BadRequest(e.Message);
  //   }
  // }
}