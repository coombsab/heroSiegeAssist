<template>
  <div class="my-runes d-flex justify-content-center align-items-center gap-3">
    <RuneCard v-for="r in myRunes" :key="r.name" :rune="r" />

    <AddMyRunes />
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import AddMyRunes from "../components/AddMyRunes.vue";
import RuneCard from "../components/RuneCard.vue";

export default {
    setup() {
        return {
          myRunes: computed(() => AppState.myRunes.sort())
        };
    },
    components: { AddMyRunes, RuneCard }
}
</script>

<style scoped lang="scss">
.my-runes {
  height: 100vh;
  background-color: black;
  position: relative;
}
</style>