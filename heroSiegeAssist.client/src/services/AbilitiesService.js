import { AppState } from "../AppState"
import { Ability } from "../models/Ability"
import { api } from "./AxiosService"


class AbilitiesService {
  async getAbilities() {
    const res = await api.get("/api/abilities")
    AppState.abilities = res.data.map(data => new Ability(data))
  }
}

export const abilitiesService = new AbilitiesService()