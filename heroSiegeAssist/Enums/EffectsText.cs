using System.Text.Json.Serialization;

namespace heroSiegeAssist.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EffectsText {
  // DrainHealth = "health on hit",
  // DrainMana = "mana on hit"
  // FIXME cannot use enums with strings, so need to figure out how I want to do this
}