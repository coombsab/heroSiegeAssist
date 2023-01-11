using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Runeword : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string ItemSlot { get; set; }
  public string ItemType { get; set; }

  public string[] Effects { get; set; }
  public string[] Items { get; set; }
  public Skill[] Skills { get; set; }
}