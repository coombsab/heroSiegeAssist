export class Rune {
  constructor(data) {
    this.name = data.name;
    this.createdAt = data.createdAt;
    this.updatedAt = data.updatedAt;
    this.effect = data.effect;
    this.tier = data.tier;
    this.dropRate = data.dropRate;
    this.img = data.img;
    this.possibleRunewords = data.possibleRunewords;
  }
}