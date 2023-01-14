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

  addRunesToRunewordSubmission(runes) {
    if (AppState.tempRunes.length < 6) {
      AppState.tempRunes = [...new Set([...AppState.tempRunes, ...runes])]
    }
  }

  removeRuneFromRunewordSubmission(rune) {
    AppState.tempRunes = AppState.tempRunes.filter(r => r !== rune)
  }
}

export const runesService = new RunesService()