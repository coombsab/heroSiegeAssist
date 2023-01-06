<template>
  <div class="runes d-flex justify-content-center align-items-center text-visible">
    <p>These are the possible runes.</p>
  </div>
  <AddRune />
</template>

<script>
import AddRune from "../components/AddRune.vue";

export default {
  setup() {
    return {};
  },
  components: { AddRune }
}
</script>

<style scoped lang="scss">
.runes {
  height: 100vh;
  background-color: black;
  position: relative;
}
</style>