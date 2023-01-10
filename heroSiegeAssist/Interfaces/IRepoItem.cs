namespace heroSiegeAssist.Interfaces;

public interface IRepoItem {
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}