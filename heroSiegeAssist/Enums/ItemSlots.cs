using System.Text.Json.Serialization;

namespace heroSiegeAssist.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemSlots {
  Weapon,
  Shield,
  Helmet,
  Chest,
  Boots,
  Gloves,
  Charm,
  Pendant,
  Belt,
  Potion
}