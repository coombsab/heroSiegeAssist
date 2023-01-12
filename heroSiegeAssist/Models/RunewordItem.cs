namespace heroSiegeAssist.Models;

public class RunewordItem
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string ItemId { get; set; }
  public string RunewordId { get; set; }

  public RunewordItem() {
    
  }

  public RunewordItem(string itemId, string runewordId) {
    ItemId = itemId;
    RunewordId = runewordId;
  }
}