<template>
  <div class="add-runeword-form">
    <form @submit.prevent="handleSubmit()">
      <div class="container-fluid">
        <div class="row">
          <div class="col-12">
            <div class="title mb-3 px-3 d-flex justify-content-between align-items-center">
              <p class="fs-4 m-0 text-visible">Add Runeword</p>
              <button type="submit"><i class="mdi mdi-plus-outline fs-4 text-visible" :disabled="checkIfDisable()"></i></button>
            </div>
            <div class="form-floating mb-3">
              <input type="text" class="form-control bg-dark text-secondary text-lighten-3"
                id="floatingInputRunewordName" placeholder="Name" v-model="editable.name" required>
              <label for="floatingInputRunewordName" class="text-secondary text-lighten-3">Name</label>
            </div>
            <div class="d-flex justify-content-between">
              <div class="form-floating mb-3">
                <input type="text" class="form-control bg-dark text-secondary text-lighten-3"
                  id="floatingInputRunewordItemSlot" placeholder="ItemSlot" v-model="editable.itemSlot" required>
                <label for="floatingInputRunewordItemSlot" class="text-secondary text-lighten-3">ItemSlot</label>
              </div>
              <div class="form-floating mb-3">
                <input type="text" class="form-control bg-dark text-secondary text-lighten-3"
                  id="floatingInputRunewordItemType" placeholder="ItemType" v-model="editable.itemType" required>
                <label for="floatingInputRunewordItemType" class="text-secondary text-lighten-3">ItemType</label>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <form @submit.prevent="handleSubmitEffect()">
              <div class="d-flex justify-content-between gap-4">
                <div class="form-floating mb-3 flex-shrink-1 w-30">
                  <input type="text" class="form-control bg-dark text-secondary text-lighten-3"
                    id="floatingInputRunewordEffect" placeholder="Effect Value" v-model="effectEditable.value" required>
                  <label for="floatingInputRunewordEffect" class="text-secondary text-lighten-3">Effect Value</label>
                </div>
                <div class="form-floating mb-3 flex-grow-1">
                  <select class="form-select bg-dark text-secondary text-lighten-3"
                    id="floatingSelectRunewordEffectText" v-model="effectEditable.text" required>
                    <option v-for="e in effectsText" :key="e.name" :value="e.name">{{ e.name }}</option>
                  </select>
                  <label for="floatingSelectEffectText" class="text-secondary text-lighten-3">Effect Text</label>
                </div>
              </div>
              <button>submit</button>
            </form>
          </div>
          <div class="col-12">
            <p class="m-0" v-for="e in tempEffects">{{ e }}</p>
          </div>
        </div>

        <div class="row">
          <div class="col-12">
            <form @submit.prevent="handleSubmitAbility()">
              <div class="d-flex justify-content-between gap-4">
                <div class="form-floating mb-3 flex-grow-1">
                  <select class="form-select bg-dark text-secondary text-lighten-3"
                    id="floatingSelectRunewordAbility" v-model="abilityEditable.name" required>
                    <option v-for="a in abilities" :key="a?.name" :value="a?.name">{{ a?.name }}</option>
                  </select>
                  <label for="floatingSelectAbility" class="text-secondary text-lighten-3">Ability</label>
                </div>
              </div>
              <button>submit</button>
            </form>
          </div>
          <div class="col-12">
            <p class="m-0" v-for="a in tempAbilities">{{ a }}</p>
          </div>
        </div>

        <div class="row">
          <div class="col-6">
            <form @submit.prevent="handleSubmitRunes()">
              <div class="input-group mb-3">
                <div class="form-floating">
                  <select class="form-select bg-dark text-secondary text-lighten-3" id="floatingSelectRunewordRunes"
                    v-model="runeEditable" multiple required>
                    <option v-for="r in runes" :value="r.name">{{ r.name }}</option>
                  </select>
                  <label for="floatingSelectRunewordRunes" class="text-secondary text-lighten-3">Add Rune</label>
                </div>
                <button class="rounded-end bg-dark"><i class="mdi mdi-plus text-secondary text-lighten-3"></i></button>
              </div>
            </form>
          </div>
          <div class="col-6">
            <form @submit.prevent="handleSubmitItems()">
              <div class="input-group mb-3">
                <div class="form-floating">
                  <select class="form-select bg-dark text-secondary text-lighten-3" id="floatingSelectRunewordItems"
                    v-model="itemEditable" multiple required>
                    <option v-for="i in items" :value="i.name">{{ i.name }}</option>
                  </select>
                  <label for="floatingSelectRunewordItems" class="text-secondary text-lighten-3">Add Item</label>
                </div>
                <button class="rounded-end bg-dark"><i class="mdi mdi-plus text-secondary text-lighten-3"></i></button>
              </div>
            </form>
          </div>
        </div>

        <div class="row">
          <div class="col-6">
            <p class="m-0" v-for="r in tempRunes">{{ r }}</p>
          </div>
          <div class="col-6">
            <p class="m-0" v-for="i in tempItems">{{ i }}</p>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { ref, computed } from "vue";
import { AppState } from "../AppState";
import { abilitiesService } from "../services/AbilitiesService";
import { effectsService } from "../services/EffectsService";
import { itemsService } from "../services/ItemsService";
import { runesService } from "../services/RunesService";
import { runewordsService } from "../services/RunewordsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})
    const effectEditable = ref({})
    const runeEditable = ref([])
    const itemEditable = ref([])
    const abilityEditable = ref({})

    return {
      editable,
      effectEditable,
      runeEditable,
      itemEditable,
      abilityEditable,
      effectsText: computed(() => AppState.effectsText),
      tempRunes: computed(() => AppState.tempRunes),
      tempItems: computed(() => AppState.tempItems),
      tempEffects: computed(() => AppState.tempEffects),
      tempAbilities: computed(() => AppState.tempAbilities),
      runes: computed(() => AppState.runes.sort((a, b) => a.name.localeCompare(b.name))),
      items: computed(() => AppState.items.sort((a, b) => a.name.localeCompare(b.name))),
      abilities: computed(() => AppState.abilities.sort((a, b) => a.name.localeCompare(b.name))),
      async handleSubmit() {
        try {
          editable.value.runes = this.tempRunes
          editable.value.items = this.tempItems
          editable.value.effects = this.tempEffects
          editable.value.abilities = this.tempAbilities
          
          await runewordsService.addRuneword(editable.value)

          editable.value = {}
          effectEditable.value = {}
          runeEditable.value = []
          itemEditable.value = []
          abilityEditable.value = {}
        }
        catch (error) {
          Pop.error(error.message, "[handleSubmit] > AddRunewordForm")
        }
      },
      handleSubmitRunes() {
        console.log("runeEditable", runeEditable.value)
        runesService.addRunesToRunewordSubmission(runeEditable.value)
      },
      handleSubmitItems() {
        console.log("itemEditable", itemEditable.value)
        itemsService.addItemsToRunewordSubmission(itemEditable.value)
      },
      handleSubmitEffect() {
        console.log("effectEditable", effectEditable.value.value + " " + effectEditable.value.text)
        effectsService.addEffectToRunewordSubmission(effectEditable.value.value + " " + effectEditable.value.text)
      },
      handleSubmitAbility() {
        console.log("abilityEditable", abilityEditable.value)
        abilitiesService.addAbilityToRunewordSubmission(abilityEditable.value)
      },
      checkIfDisable() {
        if (this.tempEffects.length > 0 && this.tempItems.length > 0 && this.tempRunes.length > 0) {
          return false
        } else {
          return true
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
button {
  background-color: transparent;
  border: none;
}

button:hover {
  filter: drop-shadow(0.5px 0.5px 5px rgba(0, 255, 255, 0.25));
}

.w-30 {
  width: 30%;
}

button {
  background-color: red;
  border: 1px solid #ced4da;
}

#floatingSelectRunewordRunes {
  border-right: none;
  height: 15rem;
}

#floatingSelectRunewordItems {
  border-right: none;
  height: 15rem;
}
</style>