namespace heroSiegeAssist.Models;

public class RunewordEffect {
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string RunewordId { get; set; }

  // REVIEW Not sure why I get an error without this constructor, did not need to add it for RunewordAbility or RuneRuneword

  public RunewordEffect() {

  }

  public RunewordEffect(string name, string runewordId) {
    Name = name;
    RunewordId = runewordId;
  }
}