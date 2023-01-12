namespace heroSiegeAssist.Models;

public class RunewordAbility {
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string RunewordId { get; set; }
  public string AbilityId { get; set; }

  public RunewordAbility(string abilityId, string runewordId) {
    AbilityId = abilityId;
    RunewordId = runewordId;
  }
}