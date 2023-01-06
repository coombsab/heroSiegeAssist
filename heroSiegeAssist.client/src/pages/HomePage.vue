<template>
  <div class="home">
    <div class="home-wrapper flex-grow-1 d-flex flex-column align-items-center justify-content-center">
      <div class="card-holder d-flex gap-3 flex-wrap">
        <LandingCard :title="'Runewords'" :background="'https://steamuserimages-a.akamaihd.net/ugc/1702909686225947976/2354D9E2F7263F61043C01B62B1E5FC143416604/'" />
        <!-- <LandingCard :title="'Runes'" /> -->
      </div>
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
  height: 100vh;
  place-content: center;
  text-align: center;
  user-select: none;
  background-image: url('../assets/img/HeroSiege.png');
  background-position: center;
  background-size: cover;
}

.home-wrapper {
  background-color: rgba(0, 0, 0, 0.75);
  height: 100vh;
  width: 100vw;
}

.card-holder {
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: space-around;
  align-items: center;
}

@media (min-width: 768px) {
  
}
</style>
