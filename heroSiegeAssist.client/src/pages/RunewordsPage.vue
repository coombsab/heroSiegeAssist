<template>
  <div class="runewords d-flex justify-content-center align-items-center text-visible">
    <div class="runewords-container d-flex gap-4">
      <RunewordCard v-for="r in runewords" :key="r.name" :runeword="r" />
    </div>
    <AddRuneword />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import AddRuneword from "../components/AddRuneword.vue";
import RunewordCard from "../components/RunewordCard.vue";

export default {
    setup() {
        return {
          runewords: computed(() => AppState.runewords.sort())
        };
    },
    components: { AddRuneword, RunewordCard }
}
</script>

<style scoped lang="scss">
  .runewords {
    height: 100vh;
    background-color: black;
    position: relative;
  }
</style>