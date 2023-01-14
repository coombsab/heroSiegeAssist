export class Item {
  constructor(data) {
    this.name = data.name;
    this.createdAt = data.createdAt;
    this.updatedAt = data.updatedAt;
    this.itemSlot = data.itemSlot;
    this.itemType = data.itemType;
  }
}