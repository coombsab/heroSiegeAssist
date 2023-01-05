<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="card-holder d-flex gap-3 flex-wrap">
      <LandingCard :title="'Runewords'" />
      <LandingCard :title="'Runes'" />
    </div>
  </div>
</template>

<script>
import LandingCard from "../components/LandingCard.vue";

export default {
    setup() {
        return {};
    },
    components: { LandingCard }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
}

.card-holder {
  // align-items: center;
}
</style>
