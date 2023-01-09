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
import RunewordCard from "../components/RunewordCard.vue";

export default {
    setup() {
        return {
          runewords: computed(() => AppState.runewords.sort())
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