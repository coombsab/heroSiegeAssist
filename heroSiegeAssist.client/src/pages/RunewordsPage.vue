<template>
  <div class="runewords d-flex justify-content-center align-items-center text-visible">
    <AddRuneword />
    <AddMyRunes />
  </div>
</template>

<script>
import AddMyRunes from "../components/AddMyRunes.vue";
import AddRuneword from "../components/AddRuneword.vue";

export default {
    setup() {
        return {};
    },
    components: { AddMyRunes, AddRuneword }
}
</script>

<style scoped lang="scss">
  .runewords {
    height: 100vh;
    background-color: black;
  }
</style>