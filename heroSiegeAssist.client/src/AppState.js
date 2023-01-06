import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  runewords: [
    { 
      name: "Breath of the Dying", 
      runes: [
        { name: "hel" }, 
        { name: "vex" }, 
        { name: "zod" }, 
        { name: "aux" }, 
        { name: "ox" }, 
        { name: "xeo" }
      ], 
      effects: [
        "4,946 Damage", 
        "1.84 aps", 
        "12% Attack Power", 
        "10% Ability Power", 
        "8% Attack Speed", 
        "2 All Talents", 
        "900 All Stats", 
        "20% Critical Damage", 
        "1,340 Damage", 
        "22% Damage",
        "[Poison Nova]"
      ]
    },
    {
      name: "Thinking Cap",
      runes: [
        { name: "lux" },
        { name: "gul" }, 
        { name: "von" },
        { name: "ye" }
      ],
      effects: [
        "900 Stamina",
        "13% Attack Power",
        "13% Ability Power",
        "1 All Talents",
        "12% Mana",
        "1% Mana Per Second",
        "400 Damage",
        "17% Random Resistance",
        "17% Random Resistance",
        "[Manashield]"
      ]
    }
  ],
  runes: [
    { name: "aux", effect: "10% hp"}, 
    { name: "ox", effect: "10% mana" }, 
    { name: "xeo", effect: "10 speed"}, 
    { name: "hel", effect: "10% cooldown reduction" }, 
    { name: "vex", effect: "100 mana" }, 
    { name: "zod", effect: "indestructable" } ],
  myRunes: [{ name: "xeo", effect: "10 speed"}]
})
