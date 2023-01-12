using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Runeword : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string ItemSlot { get; set; }
  public string ItemType { get; set; }

  public List<Rune> Runes { get; set; }
  public List<string> Effects { get; set; }
  public List<string> Items { get; set; }
  public List<Ability> Abilities { get; set; }
}