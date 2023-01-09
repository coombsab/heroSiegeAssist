<template>
  <div class="runes d-flex flex-wrap justify-content-center align-items-center text-visible gap-3" v-if="true">
    <RuneCard v-for="r in runes" :key="r.name" :rune="r" />
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
}
</style>