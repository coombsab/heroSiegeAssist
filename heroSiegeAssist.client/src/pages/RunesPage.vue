<template>
  <div class="runes" v-if="true">
    <div class="runes-container d-flex flex-wrap gap-4 justify-content-center">
      <RuneCard v-for="r in runes" :key="r.name" :rune="r" />
    </div>
  </div>
  <div class="runes d-flex flex-column justify-content-center" v-else>
    <RuneCard v-for="r in runes" :key="r.name" :rune="r" />
  </div>
  <AddButton :buttonText="'Add Rune'" :modalId="'addRuneModal'" />
  <AddModal :modalId="'addRuneModal'">
    <AddRuneForm />
  </AddModal>

</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState";
import AddButton from "../components/AddButton.vue";
import AddModal from "../components/AddModal.vue";
import AddRuneForm from "../components/AddRuneForm.vue";
import RuneCard from "../components/RuneCard.vue";
import Pop from "../utils/Pop";
import { runesService } from "../services/RunesService"
import { effectsService } from "../services/EffectsService"

export default {
  setup() {
    async function getRunes() {
      try {
        await runesService.getRunes()
      }
      catch(error) {
        Pop.error(error.message, "[getRunes > RunesPage]")
      }
    }

    async function getEffectsText() {
      try {
        await effectsService.getEffectsText()
      }
      catch(error) {
        Pop.error(error.message, "[getEffectsText > RunesPage]")
      }
    }

    onMounted(() => {
      getRunes()
      getEffectsText()
    })

    return {
      runes: computed(() => AppState.runes.sort((a, b) => a.name.localeCompare(b.name))),
    };
  },
  components: { RuneCard, AddModal, AddButton, AddRuneForm }
}
</script>

<style scoped lang="scss">
  .runes {
    height: 100vh;
    background-color: black;
    position: relative;
    
    >.runes-container {
      overflow-y: auto;
      height: 100%;
      width: 100%;
      padding-top: 5rem;
      padding-bottom: 2.5rem;
      align-content: flex-start;
    }
  }
</style>