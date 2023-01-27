import { AppState } from "../AppState"
import { Item } from "../models/Item"
import { api } from "./AxiosService"

class ItemsService {
  async getItems() {
    const res = await api.get("api/items")
    AppState.items = res.data.map(data => new Item(data))
  }

  async addItem(itemData) {
    const res = await api.post("api/items", itemData)
    AppState.items.push(new Item(res.data))
  }

  addItemsToRunewordSubmission(items) {
    AppState.tempItems = [...new Set([...AppState.tempItems, ...items])]
  }

  removeItemFromRunewordSubmission(item) {
    AppState.tempItems = AppState.tempItems.filter(i => i !== item)
  }
}

export const itemsService = new ItemsService()