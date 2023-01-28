import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  runewords: [],
  runes: [],
  myRunes: [],
  items: [],
  abilities: [],
  effectsText: [],
  tempRunes: [],
  tempItems: [],
  tempAbilities: [],
  tempEffects: [],
  possibleItemSlots: [ "head", "neck", "charm", "main-hand", "body", "off-hand", "hands", "waist", "finger", "pouch", "feet" ],
  possibleItemTypes: [ "helmet", "pendant", "charm", "armor", "shield", "gloves", "belt", "ring", "potion", "boots", "sword", "spear", "bow", "javelin", "gun", "lance", "dagger", "wand", "flask", "staff", "chainsaw", "axe", "flail", "mace"],
  activeRune: null,
  possibleRunewords: []
})
