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
}