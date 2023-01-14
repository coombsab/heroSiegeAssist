import { AppState } from "../AppState"
import { Runeword } from "../models/Runeword"
import { api } from "./AxiosService"

class RunewordsService {
  async getRunewords() {
    const res = await api.get("/api/runewords")
    AppState.runewords = res.data.map(data => new Runeword(data))
  }

  async addRuneword(runewordData) {
    console.log("adding runeword", runewordData)
    AppState.tempAbilities = []
    AppState.tempEffects = []
    AppState.tempItems = []
    AppState.tempRunes = []
  }
}

export const runewordsService = new RunewordsService()