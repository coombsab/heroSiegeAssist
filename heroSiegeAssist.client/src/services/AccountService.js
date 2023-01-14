import { AppState } from '../AppState'
import { MyRune } from "../models/MyRune"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

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
  }
}

export const accountService = new AccountService()
