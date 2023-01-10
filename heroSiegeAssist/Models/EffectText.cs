using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class EffectText : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}