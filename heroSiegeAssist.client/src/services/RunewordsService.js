import { AppState } from "../AppState"
import { Runeword } from "../models/Runeword"
import { api } from "./AxiosService"

class RunewordsService {
  async getRunewords() {
    const res = await api.get("/api/runewords")
    AppState.runewords = res.data.map(data => new Runeword(data))
  }

  async addRuneword(runewordData) {
    
  }
}

export const runewordsService = new RunewordsService()