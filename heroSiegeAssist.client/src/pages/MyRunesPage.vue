<template>
  <div class="my-runes d-flex flex-column justify-content-center align-items-center text-visible">
    <p>These are my runes and possible runewords.</p>
    <AddMyRunes />
  </div>
</template>

<script>
import AddMyRunes from "../components/AddMyRunes.vue";

export default {
    setup() {
        return {};
    },
    components: { AddMyRunes }
}
</script>

<style scoped lang="scss">
.my-runes {
  height: 100vh;
  background-color: black;
}
</style>