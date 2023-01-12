namespace heroSiegeAssist.Services;

public class ItemsService {
  private readonly ItemsRepository _itemsRepository;

  public ItemsService(ItemsRepository itemsRepository)
  {
    _itemsRepository = itemsRepository;
  }

  public List<Item> GetItems() {
    return _itemsRepository.GetItems();
  }

  public Item GetItemByName(string name) {
    Item item = _itemsRepository.GetItemByName(name);
    if (item == null) {
      throw new Exception("Could not find the item " + name);
    }

    return item;
  }

  public Item AddItem(Item itemData) {
    _itemsRepository.AddItem(itemData);

    Item item = this.GetItemByName(itemData.Name);

    return item;
  }
}