import { AppState } from "../AppState"
import { MyRune } from "../models/MyRune"
import { Runeword } from "../models/Runeword"
import { api } from "./AxiosService"

class RunewordsService {
  async getRunewords() {
    const res = await api.get("/api/runewords")
    AppState.runewords = res.data.map(data => new Runeword(data))
  }

  async addRuneword(runewordData) {
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


    const res = await api.post("/api/runewords", runewordData)
    AppState.runewords.push(new Runeword(res.data))
  }

  checkForRunewords() {
    let myRunesTemp = []
    AppState.possibleRunewords = []
    AppState.myRunes.forEach(r => myRunesTemp.push(new MyRune(r)))

    let hasRunes = true

    AppState.runewords.forEach(runeword => {
      runeword.runes.forEach(rune => {
        let myRune = myRunesTemp.find(r => r.name === rune.name)

        if (!myRune) {
          hasRunes = false
        } else {
          if (myRune.quantity >= 1) {
            myRune.quantity--
          } else {
            hasRunes = false
          }
        }
      })
      if (hasRunes) {
        AppState.possibleRunewords.push(runeword)
      } else {
        hasRunes = true
      }
      myRunesTemp = []
      AppState.myRunes.forEach(r => myRunesTemp.push(new MyRune(r)))

    })

  }
}

export const runewordsService = new RunewordsService()