using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Skill : IRepoItem
{
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Description { get; set; }
}