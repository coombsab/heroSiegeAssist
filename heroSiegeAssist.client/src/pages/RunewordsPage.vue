<template>
  <div class="runewords">
    <div class="runewords-container d-flex flex-wrap gap-4 justify-content-center">
      <RunewordCard v-for="r in runewords" :key="r.name" :runeword="r" />
    </div>
    <AddButton :buttonText="'Add Runeword'" :modalId="'addRunewordModal'" />
    <AddModal :modalId="'addRunewordModal'">
      <AddRunewordForm />
    </AddModal>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import AddButton from "../components/AddButton.vue";
import AddModal from "../components/AddModal.vue";
import AddRunewordForm from "../components/AddRunewordForm.vue";
import { runewordsService } from "../services/RunewordsService"
import RunewordCard from "../components/RunewordCard.vue";
import Pop from "../utils/Pop";
import { onMounted } from "vue";
import { effectsService } from "../services/EffectsService";
import { itemsService } from "../services/ItemsService";
import { abilitiesService } from "../services/AbilitiesService";
import { runesService } from "../services/RunesService";
import { accountService } from "../services/AccountService";

export default {
  setup() {
    async function getRunewords() {
      try {
        await runewordsService.getRunewords()
      }
      catch (error) {
        Pop.error(error.message, "[getRunewords > RunewordsPage]")
      }
    }

    async function getRunes() {
      try {
        await runesService.getRunes()
      }
      catch (error) {
        Pop.error(error.message, "[getRunes > RunewordsPage]")
      }
    }

    async function getAbilities() {
      try {
        await abilitiesService.getAbilities()
      }
      catch (error) {
        Pop.error(error.message, "[getAbilities > RunewordsPage]")
      }
    }

    async function getEffectsText() {
      try {
        await effectsService.getEffectsText()
      }
      catch (error) {
        Pop.error(error.message, "[getEffectsText > RunewordsPage]")
      }
    }

    async function getItems() {
      try {
        await itemsService.getItems()
      }
      catch (error) {
        Pop.error(error.message, "[getItems > RunewordsPage]")
      }
    }

    async function getMyRunes() {
      try {
        await accountService.getMyRunes()
      }
      catch (error) {
        Pop.error(error.message, "[getMyRunes > RunewordsPage]")
      }
    }

    onMounted(() => {
      getRunewords()
      getRunes()
      getAbilities()
      getEffectsText()
      getItems()
      getMyRunes()
    })

    return {
      runewords: computed(() => AppState.runewords.sort((a, b) => a.name.localeCompare(b.name)))
    };
  },
  components: { RunewordCard, AddModal, AddButton, AddRunewordForm }
}
</script>

<style scoped lang="scss">
.runewords {
  height: 100vh;
  background-color: black;
  position: relative;

  >.runewords-container {
    overflow-y: auto;
    height: 100%;
    width: 100%;
    padding-top: 5rem;
    padding-bottom: 2.5rem;
    align-content: flex-start;
  }
}
</style>