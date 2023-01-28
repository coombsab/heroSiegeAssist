import { AppState } from '../AppState'
import { MyRune } from "../models/MyRune"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { runewordsService } from "./RunewordsService"

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyRunes() {
    const res = await api.get("/account/runes")
    AppState.myRunes = res.data.map(data => new MyRune(data))
    runewordsService.checkForRunewords()
  }

  async addToMyRunes(runeData) {
    const res = await api.post("/account/runes", runeData)
    AppState.myRunes.push(new MyRune(res.data))
    runewordsService.checkForRunewords()
  }

  async deleteMyRune(runeId) {
    const res = await api.delete("/account/runes/" + runeId)
    AppState.myRunes = AppState.myRunes.filter(rune => rune.id !== runeId)
    runewordsService.checkForRunewords()
  }

  async editMyRune(runeData) {
    AppState.activeRune.quantity = runeData.quantity
    const res = await api.put("/account/runes/" + AppState.activeRune.id, AppState.activeRune)
    const updatedRune = new MyRune(res.data)
    updatedRune.possibleRunewords = AppState.activeRune.possibleRunewords
    let index = AppState.myRunes.findIndex(rune => rune.id === updatedRune.id)
    AppState.myRunes.splice(index, 1, updatedRune)
    runewordsService.checkForRunewords()
  }
}

export const accountService = new AccountService()
