namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EffectsController : ControllerBase
{
  private readonly EffectsService _effectsService;

  public EffectsController(EffectsService effectsService)
  {
    this._effectsService = effectsService;
  }

  [HttpGet]
  public ActionResult<List<EffectText>> GetEffectsText()
  {
    try
    {
      List<EffectText> effectsText = _effectsService.GetEffectsText();
      return Ok(effectsText);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<EffectText> AddEffectText([FromBody] EffectText effectTextData) {
    try {
      EffectText effectText = _effectsService.AddEffectText(effectTextData);
      return Ok(effectText);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}