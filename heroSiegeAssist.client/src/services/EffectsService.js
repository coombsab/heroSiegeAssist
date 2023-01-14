import { AppState } from "../AppState"
import { api } from "./AxiosService"

class EffectsService {
  async getEffectsText() {
    const res = await api.get("/api/effects")
    AppState.effectsText = res.data
    AppState.effectsText.sort((a, b) => a.name.localeCompare(b.name))
  }

  addEffectToRunewordSubmission(effect) {
    // AppState.tempEffects.push(effect)
    let effects = [effect]
    AppState.tempEffects = [...new Set([...AppState.tempEffects, ...effects])]
  }
}

export const effectsService = new EffectsService()