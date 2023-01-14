import { Rune } from "./Rune";

export class MyRune extends Rune {
  constructor(data) {
    super(data);
    this.quantity = data.quantity;
    this.accountId = data.accountId;
    this.id = data.id;
  }
}