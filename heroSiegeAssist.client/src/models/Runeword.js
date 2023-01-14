export class Runeword {
  constructor(data) {
    this.name = data.name;
    this.createdAt = data.createdAt;
    this.updatedAt = data.updatedAt;
    this.itemSlot = data.itemSlot;
    this.itemType = data.itemType;
    this.runes = data.runes;
    this.effects = data.effects;
    this.items = data.items;
    this.abilities = data.abilities;
  }
}