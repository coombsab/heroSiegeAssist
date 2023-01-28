import { AppState } from "../AppState"
import { Runeword } from "../models/Runeword"
import { api } from "./AxiosService"

class RunewordsService {
  async getRunewords() {
    const res = await api.get("/api/runewords")
    AppState.runewords = res.data.map(data => new Runeword(data))
  }

  async addRuneword(runewordData) {
    // console.log("initialRunewordData", runewordData)
    AppState.tempAbilities = []
    AppState.tempEffects = []
    AppState.tempItems = []
    AppState.tempRunes = []

    let abilities = []
    let items = []
    let runes = []
    let effects = []

    runewordData.abilities.forEach(ability => abilities.push(AppState.abilities.find(a => a.name === ability)))
    runewordData.abilities = abilities
    runewordData.items.forEach(item => items.push(AppState.items.find(i => i.name === item)))
    runewordData.items = items
    runewordData.runes.forEach(rune => runes.push(AppState.runes.find(r => r.name === rune)))
    runewordData.runes = runes
    runewordData.effects.forEach(effect => effects.push({ name: effect }))
    runewordData.effects = effects
    
    // console.log("runewordData", runewordData)

    const res = await api.post("/api/runewords", runewordData)
    AppState.runewords.push(new Runeword(res.data))
    console.log(res.data)
  }

  checkForRunewords() {
    console.log("checking for runewords")
    let myRunesTemp = [...AppState.myRunes]
    let neededRunes = []
    AppState.runewords.forEach(runeword => {
      neededRunes = [...runeword.runes]
      console.log(runeword.name, "needs", neededRunes)
    })
  }
}

export const runewordsService = new RunewordsService()