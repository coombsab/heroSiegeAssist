namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RunewordsController : ControllerBase {
  private readonly RunewordsService _runewordsService;
  private readonly RuneRunewordsService _runeRunewordsService;
  private readonly EffectsService _effectsService;
  private readonly AbilitiesService _abilitiesService;
  private readonly ItemsService _itemsService;

  public RunewordsController(RunewordsService runewordsService, RuneRunewordsService runeRunewordsService, EffectsService effectsService, AbilitiesService abilitiesService, ItemsService itemsService)
  {
    _runewordsService = runewordsService;
    _runeRunewordsService = runeRunewordsService;
    _effectsService = effectsService;
    _abilitiesService = abilitiesService;
    _itemsService = itemsService;
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

  // [HttpPost("Effects")]
  // public ActionResult<RunewordEffect> AddEffectToRuneword([FromBody] RunewordEffect runewordEffectData) {
  //   try {
  //     RunewordEffect runewordEffect = _effectsService.AddEffectToRuneword(runewordEffectData);
  //     return Ok(runewordEffect);
  //   }
  //   catch(Exception e) {
  //     return BadRequest(e.Message);
  //   }
  // }

  // [HttpPost("Abilities")]
  // public ActionResult<RunewordAbility> AddAbilityToRuneword([FromBody] RunewordAbility runewordAbilityData) {
  //   try {
  //     RunewordAbility runewordAbility = _abilitiesService.AddAbilityToRuneword(runewordAbilityData);
  //     return Ok(runewordAbility);
  //   }
  //   catch(Exception e) {
  //     return BadRequest(e.Message);
  //   }
  // }

  // [HttpPost("Items")]
  // public ActionResult<RunewordItem> AddItemToRuneword([FromBody] RunewordItem runewordItemData) {
  //   try {
  //     RunewordItem runewordItem = _itemsService.AddItemToRuneword(runewordItemData);
  //     return Ok(runewordItem);
  //   }
  //   catch(Exception e) {
  //     return BadRequest(e.Message);
  //   }
  // }
}