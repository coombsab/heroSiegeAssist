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
        { name: "hel", effect: "0.75% all stats", tier: "nightmare", dropRate: "1/32500", img: "/src/assets/img/runes/hel.webp" },
        { name: "vex", effect: "2% energy", tier: "nightmare", dropRate: "1/4500", img: "/src/assets/img/runes/vex.webp" },
        { name: "zod", effect: "250 health/hit", tier: "high", dropRate: "1/24500", img: "/src/assets/img/runes/zod.webp" },
        { name: "aux", effect: "2.50% wind damage", tier: "hell", dropRate: "1/4500", img: "/src/assets/img/runes/aux_rune.webp" },
        { name: "ox", effect: "2% strength", tier: "nightmare", dropRate: "1/4250", img: "/src/assets/img/runes/ox.webp" },
        { name: "xeo", effect: "50 health/sec", tier: "normal", dropRate: "1/400", img: "/src/assets/img/runes/xeo.webp" },
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
        { name: "lux", effect: "0.5% mana/sec", tier: "nightmare", dropRate: "1/3750", img: "/src/assets/img/runes/lux.webp" },
        { name: "gul", effect: "250 mana/hit", tier: "high", dropRate: "1/24000", img: "/src/assets/img/runes/gul.webp" },
        { name: "von", effect: "2% cooldown reduction", tier: "nightmare", dropRate: "1/2250", img: "/src/assets/img/runes/von.webp" },
        { name: "ye", effect: "50 mana/sec", tier: "normal", dropRate: "1/450", img: "/src/assets/img/runes/ye.webp" },
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
    },
    {
      name: "Scholar",
      runes: [
        { name: "wei", effect: "750 max mana", tier: "normal", dropRate: "1/500", img: "/src/assets/img/runes/wei.webp" },
        { name: "xeo", effect: "50 health/sec", tier: "normal", dropRate: "1/400", img: "/src/assets/img/runes/xeo.webp" },
        { name: "ye", effect: "50 mana/sec", tier: "normal", dropRate: "1/450", img: "/src/assets/img/runes/ye.webp" },
      ],
      effects: [
        "200 Armor",
        "200 Stamina",
        "4% Attack Power",
        "4% Ability Power",
        "5% Damage",
        "250 Damage",
        "1 All Talents",
        "1% Mana Per Second",
        "17% Random Resistance",
        "10% All Resistance"
      ]
    }
  ],
  runes: [
    { name: "aux", effect: "2.50% wind damage", tier: "hell", dropRate: "1/4500", img: "/src/assets/img/runes/aux_rune.webp" },
    { name: "ox", effect: "2% strength", tier: "nightmare", dropRate: "1/4250", img: "/src/assets/img/runes/ox.webp" },
    { name: "xeo", effect: "50 health/sec", tier: "normal", dropRate: "1/400", img: "/src/assets/img/runes/xeo.webp" },
    { name: "hel", effect: "0.75% all stats", tier: "nightmare", dropRate: "1/32500", img: "/src/assets/img/runes/hel.webp" },
    { name: "vex", effect: "2% energy", tier: "nightmare", dropRate: "1/4500", img: "/src/assets/img/runes/vex.webp" },
    { name: "zod", effect: "250 health/hit", tier: "high", dropRate: "1/24500", img: "/src/assets/img/runes/zod.webp" },
    { name: "efoel", effect: "2% armor", tier: "nightmare", dropRate: "1/3000", img: "/src/assets/img/runes/efoel.webp" },
    { name: "lux", effect: "0.5% mana/sec", tier: "nightmare", dropRate: "1/3750", img: "/src/assets/img/runes/lux.webp" },
    { name: "gul", effect: "250 mana/hit", tier: "high", dropRate: "1/24000", img: "/src/assets/img/runes/gul.webp" },
    { name: "von", effect: "2% cooldown reduction", tier: "nightmare", dropRate: "1/2250", img: "/src/assets/img/runes/von.webp" },
    { name: "ye", effect: "50 mana/sec", tier: "normal", dropRate: "1/450", img: "/src/assets/img/runes/ye.webp" },
    { name: "wei", effect: "750 max mana", tier: "normal", dropRate: "1/500", img: "/src/assets/img/runes/wei.webp" },
  ],
  myRunes: [
    { name: "xeo", effect: "50 health/sec", tier: "normal", dropRate: "1/400", img: "/src/assets/img/runes/xeo.webp", quantity: 2 },
    { name: "ox", effect: "2% strength", tier: "nightmare", dropRate: "1/4250", img: "/src/assets/img/runes/ox.webp", quantity: 5 },
  ]
})
