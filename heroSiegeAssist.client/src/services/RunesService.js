import { AppState } from "../AppState"
import { Rune } from "../models/Rune"
import { api } from "./AxiosService"

class RunesService {
  async getRunes() {
    const res = await api.get("/api/runes")
    AppState.runes = res.data.map(data => new Rune(data))
    // AppState.runes.sort((a, b) => a.name.localeCompare(b.name))
  }

  async addRune(runeData) {
    const res = await api.post("/api/runes", runeData)
    AppState.runes.push(new Rune(res.data))
    // AppState.runes.sort((a, b) => a.name.localeCompare(b.name))
  }

  addRunesToRunewordSubmission(rune) {
    if (AppState.tempRunes.length < 6) {
      AppState.tempRunes.push(rune)
    }
  }

  removeRuneFromRunewordSubmission(index) {
    AppState.tempRunes.splice(index, 1)
  }
}

export const runesService = new RunesService()