import { AppState } from "../AppState"
import { api } from "./AxiosService"

class EffectsService {
  async getEffectsText() {
    const res = await api.get("/api/effects")
    AppState.effectsText = res.data
    AppState.effectsText.sort((a, b) => a.name.localeCompare(b.name))
  }
}

export const effectsService = new EffectsService()