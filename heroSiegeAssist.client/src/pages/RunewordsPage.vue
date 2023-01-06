<template>
  <div class="runewords d-flex justify-content-center align-items-center text-visible">
    <AddRuneword />
  </div>
</template>

<script>
import AddRuneword from "../components/AddRuneword.vue";

export default {
    setup() {
        return {};
    },
    components: { AddRuneword }
}
</script>

<style scoped lang="scss">
  .runewords {
    height: 100vh;
    background-color: black;
  }
</style>