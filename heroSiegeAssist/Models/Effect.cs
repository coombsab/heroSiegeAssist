using heroSiegeAssist.Interfaces;

namespace heroSiegeAssist.Models;

public class Effect : IRepoItem
{
  public int Id { get; set; }
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int Amount { get; set; }
  public Boolean IsPercent { get; set; }
}