using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Runeword : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string ItemSlot { get; set; }
  public string ItemType { get; set; }
  public string Rune1 { get; set; }
  public string Rune2 { get; set; }
  public string Rune3 { get; set; }
  public string Rune4 { get; set; }
  public string Rune5 { get; set; }
  public string Rune6 { get; set; }

  public List<Rune> Runes { get; set; }
  public List<string> Effects { get; set; }
  public List<string> Items { get; set; }
  public List<Skill> Skills { get; set; }
}