using System.Text.Json.Serialization;

namespace heroSiegeAssist.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemTypes {
  Sword,
  Dagger,
  Staff,
  Flask,
  Bow,
  Spear,
  Javalin,
  Lance,
  Chainsaw,
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