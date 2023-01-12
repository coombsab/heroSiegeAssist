using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Item : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string ItemSlot { get; set; }
  public string ItemType { get; set; }
}