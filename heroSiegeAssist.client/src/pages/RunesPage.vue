<template>
  <div class="runes" v-if="true">
    <div class="runes-container d-flex flex-wrap gap-4 justify-content-center">
      <RuneCard v-for="r in runes" :key="r.name" :rune="r" />
    </div>
  </div>
  <div class="runes d-flex flex-column justify-content-center" v-else>
    <RuneCard v-for="r in runes" :key="r.name" :rune="r" />
  </div>
  <AddRune />
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import AddRune from "../components/AddRune.vue";
import RuneCard from "../components/RuneCard.vue";

export default {
  setup() {
    return {
      runes: computed(() => AppState.runes.sort())
    };
  },
  components: { AddRune, RuneCard }
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