namespace heroSiegeAssist.Models;

public class RuneRuneword {
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string RunewordId { get; set; }
  public string RuneId { get; set; }

  public Rune Rune { get; set; }
  public Runeword Runeword { get; set; }

  public RuneRuneword(string runeId, string runewordId) {
    RuneId = runeId;
    RunewordId = runewordId;
  }
}