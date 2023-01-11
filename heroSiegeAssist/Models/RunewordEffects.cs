namespace heroSiegeAssist.Models;

public class RunewordEffects {
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string RunewordId { get; set; }
  public int EffectId { get; set; }
}