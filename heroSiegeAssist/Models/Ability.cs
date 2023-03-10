using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Ability : IRepoItem {
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Description { get; set; }
}