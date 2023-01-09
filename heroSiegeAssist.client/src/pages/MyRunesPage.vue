<template>
  <div class="my-runes">
    <div class="my-runes-container d-flex flex-wrap gap-4 justify-content-center">
      <RuneCard v-for="r in myRunes" :key="r.name" :rune="r" />
    </div>

    <AddButton :buttonText="'Add Rune'" :modalId="'addMyRunesModal'" />
    <AddModal :modalId="'addMyRunesModal'">
      <AddMyRunesForm />
    </AddModal>

  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import AddButton from "../components/AddButton.vue";
import AddModal from "../components/AddModal.vue";
import AddMyRunesForm from "../components/AddMyRunesForm.vue";
import RuneCard from "../components/RuneCard.vue";

export default {
  setup() {
    return {
      myRunes: computed(() => AppState.myRunes.sort())
    };
  },
  components: { RuneCard, AddModal, AddButton, AddMyRunesForm }
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