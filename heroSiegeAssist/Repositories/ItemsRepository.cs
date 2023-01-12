namespace heroSiegeAssist.Repositories;

public class ItemsRepository {
  private readonly IDbConnection _db;

  public ItemsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Item> GetItems() {
    string sql = @"
      SELECT *
      FROM items;
    ";

    return _db.Query<Item>(sql).ToList();
  }

  public Item GetItemByName(string name) {
    string sql = @"
      SELECT *
      FROM items
      WHERE items.name = @name;
    ";

    return _db.QueryFirstOrDefault<Item>(sql, new { name });
  }

  public string AddItem(Item itemData) {
    string sql = @"
      INSERT INTO items (
        name, itemSlot, itemType
      )
      VALUES (
        @Name, @ItemSlot, @ItemType
      );
      SELECT LAST_INSERT_ID();
    ";

    return _db.ExecuteScalar<string>(sql, itemData);
  }

  public RunewordItem GetRunewordItemById(int runewordItemId)
  {
    string sql = @"
      SELECT *
      FROM runeworditems
      WHERE runeworditems.id = @runewordItemId;
    ";

    return _db.QueryFirstOrDefault<RunewordItem>(sql, new { runewordItemId });
  }

  public int AddItemToRuneword(RunewordItem runewordItemData)
  {
    string sql = @"
      INSERT INTO runeworditems (
        itemId, runewordId
      )
      VALUES (
        @ItemId, @RunewordId
      );
      SELECT LAST_INSERT_ID();
    ";

    return _db.ExecuteScalar<int>(sql, runewordItemData);
  }
}