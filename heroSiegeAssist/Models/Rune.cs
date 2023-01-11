using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Rune : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Effect { get; set; }
  public string Tier { get; set; }
  public string DropRate { get; set; }
  public string Img { get; set; }
  
  public List<Runeword> PossibleRunewords { get; set; }

}