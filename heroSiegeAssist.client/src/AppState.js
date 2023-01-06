import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  runewords: [{ name: "Breath of the Dying", rune1: "hel", rune2: "vex", rune3: "zod", rune4: "aux", rune5: "ox", rune6: "xeo"}],
  runes: [{ name: "aux", effect: "10% hp"}, { name: "ox", effect: "10% mana" }, { name: "xeo", effect: "10 speed"}, { name: "hel", effect: "10% cooldown reduction" }, { name: "vex", effect: "100 mana" }, { name: "zod", effect: "indestructable" } ],
  myRunes: []
})
