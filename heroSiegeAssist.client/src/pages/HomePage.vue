<template>
  <div class="home">
    <div class="home-wrapper flex-grow-1 d-flex flex-column align-items-center justify-content-center p-5">
      <div class="card-holder d-flex gap-3 flex-wrap">
        <LandingCard :title="'Runewords'" :background="'https://steamuserimages-a.akamaihd.net/ugc/1702909686225947976/2354D9E2F7263F61043C01B62B1E5FC143416604/'" />
        <LandingCard :title="'Runes'" :background="'https://i.pinimg.com/564x/50/bb/86/50bb86315bc0c3771eefc7e97983e582.jpg'" />
        <LandingCard :title="'MyRunes'" :background="'https://preview.redd.it/spell-rune-glyph-circle-generator-v0-s3jpu4n9ysy91.png?width=771&format=png&auto=webp&s=acfe2b1458af39d7f4af08d38c5aba96fc2b2879'" />
        <LandingCard :title="'Items'" :background="'https://media.wizards.com/2014/images/dnd/articles/DMG_MagicItems.jpg'" />
        <LandingCard :title="'Abilities'" :background="'https://pbs.twimg.com/media/EJX5l1NXsAEeqE4.jpg'" />
        <LandingCard :title="'Hunts'" :background="'https://i.ibb.co/3rZ0dMx/hunt.png'" />
        <LandingCard :title="'Misc'" :background="'https://www.fg-a.com/wallpapers/1-circuit-red-1280.jpg'" />
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
  overflow-y: auto;
}

.card-holder {
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: space-around;
  align-items: center;
  align-content: center;
}

@media (min-width: 768px) {

}
</style>
