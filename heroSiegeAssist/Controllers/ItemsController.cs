namespace heroSiegeAssist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase {
  private readonly ItemsService _itemsService;

  public ItemsController(ItemsService itemsService)
  {
    _itemsService = itemsService;
  }

  [HttpGet]
  public ActionResult<List<Item>> GetItems() {
    try {
      List<Item> items = _itemsService.GetItems();
      return Ok(items);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Item> AddItem([FromBody] Item itemData) {
    try {
      Item item = _itemsService.AddItem(itemData);
      return Ok(item);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}