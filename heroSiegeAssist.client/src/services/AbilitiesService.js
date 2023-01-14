import { AppState } from "../AppState"
import { Ability } from "../models/Ability"
import { api } from "./AxiosService"


class AbilitiesService {
  async getAbilities() {
    const res = await api.get("/api/abilities")
    AppState.abilities = res.data.map(data => new Ability(data))
  }

  addAbilityToRunewordSubmission(ability) {
    let abilities = [ability.name]
    AppState.tempAbilities = [...new Set([...AppState.tempAbilities, ...abilities])]
  }

  removeAbilityFromRunewordSubmission(ability) {
    AppState.tempAbilities = AppState.tempAbilities.filter(a => a !== ability)
  }
}

export const abilitiesService = new AbilitiesService()