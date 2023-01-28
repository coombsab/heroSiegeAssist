<template>
  <div class="my-runes">
    <div class="my-runes-container">
      <div class="d-flex flex-wrap gap-4 justify-content-center mb-3">
        <RuneCard v-for="r in myRunes" :key="r.name" :rune="r" />
      </div>
      <div class="possible-runewords d-flex justify-content-center gap-4">
        <!-- <p class="text-visible">POSSIBLE RUNEWORDS</p> -->
        <RunewordCard v-for="r in possibleRunewords" :key="r.name" :runeword="r" />
      </div>
    </div>

    <AddButton :buttonText="'Add Rune'" :modalId="'addMyRunesModal'" />
    <AddModal :modalId="'addMyRunesModal'">
      <AddMyRunesForm />
    </AddModal>
    <AddModal :modalId="'editMyRuneModal'">
      <EditMyRuneForm />
    </AddModal>

  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState";
import AddButton from "../components/AddButton.vue";
import AddModal from "../components/AddModal.vue";
import AddMyRunesForm from "../components/AddMyRunesForm.vue";
import RuneCard from "../components/RuneCard.vue";
import RunewordCard from "../components/RunewordCard.vue";
import { accountService } from "../services/AccountService";
import { runesService } from "../services/RunesService";
import { runewordsService } from "../services/RunewordsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    async function getMyRunes() {
      try {
        await runewordsService.getRunewords()
        await accountService.getMyRunes()
      }
      catch(error) {
        Pop.error(error.message, "[getMyRunes > MyRunesPage]")
      }
    }

    async function getRunes() {
      try {
        await runesService.getRunes()
      }
      catch(error) {
        Pop.error(error.message, "[getRunes] > MyRunesPage")
      }
    }

    onMounted(() => {
      getMyRunes()
      getRunes()
    })

    return {
      myRunes: computed(() => AppState.myRunes.sort((a, b) => a.name.localeCompare(b.name))),
      possibleRunewords: computed(() => AppState.possibleRunewords.sort((a, b) => a.name.localeCompare(b.name)))
    };
  },
  components: { RuneCard, AddModal, AddButton, AddMyRunesForm, RunewordCard }
}
</script>

<style scoped lang="scss">
.my-runes {
  height: 100vh;
  background-color: black;
  position: relative;

  >.my-runes-container {
    overflow-y: auto;
    height: 100%;
    width: 100%;
    padding-top: 5rem;
    padding-bottom: 2.5rem;
    align-content: flex-start;
  }
}
</style>