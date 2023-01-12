namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbilitiesController : ControllerBase {
  private readonly AbilitiesService _abilitiesService;

  public AbilitiesController(AbilitiesService abilitiesService)
  {
    _abilitiesService = abilitiesService;
  }

  [HttpGet]
  public ActionResult<List<Ability>> GetAbilities() {
    try {
      List<Ability> abilities = _abilitiesService.GetAbilities();
      return Ok(abilities);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Ability> AddAbility([FromBody] Ability abilityData) {
    try {
      Ability ability = _abilitiesService.AddAbility(abilityData);
      return Ok(ability);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}