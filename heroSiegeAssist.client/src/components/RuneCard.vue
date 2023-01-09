<template>
  <div class="rune-card" v-if="true">
    <div class="card-wrapper d-flex flex-column p-3 text-center text-visible">
      <div class="d-flex gap-1 align-items-center">
        <img :src="rune.img" :alt="rune.name">
        <p class="fs-5" :title="rune.effect">{{ rune.name }}</p>
        <p v-if="rune.quantity">({{ rune.quantity }})</p>
      </div>
      <div class="flex-grow-1 d-flex justify-content-center align-items-center">
        <p>{{ rune.effect }}</p>
      </div>
    </div>
  </div>
  <div class="d-flex flex-wrap gap-2 text-visible" v-else>
    <div class="d-flex gap-1 rune-title ps-1 py-1">
      <img :src="rune.img" :alt="rune.name">
      <p>{{ rune.name }}</p>
    </div>
    <div class="d-flex gap-2 py-1">
      <p>{{ rune.effect }}</p>
      <p>({{ rune.tier }}, {{ rune.dropRate }})</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    rune: { type: Object }
  },

  setup(props) {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.rune-card {
  border-radius: 1rem;
  // height: 80vh;
  // width: 90vw;
  background-color: purple;
  background-image: url(../assets/img/HeroSiegeRuneWord.png);
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
  // box-shadow: 10px 5px 5px teal;
  // box-shadow: 0px 5px 10px 0px rgba(0, 255, 255, 0.7);
  // box-shadow: 0.5px 0.5px 10px 0px rgba(0,255,255,0.25), -0.5px -0.5px 10px 0px rgba(0,255,255,0.25);

}

.rune-card:hover {
  // transform: translateY(-10px);
  // box-shadow: inset 0px 5px 10px 5px rgba(0,255,255,0.7);
  // box-shadow: 0.5px 0.5px 10px 0px rgba(0,255,255,0.25), -0.5px -0.5px 10px 0px rgba(0,255,255,0.25);

}

.card-wrapper {
  height: 100%;
  width: 100%;
  border-radius: 1rem;
  background-color: rgba(0, 0, 0, 0.75);
  display: flex;
  align-items: center;
}

img {
  height: 25px;
  width: 20px;
}

.rune-title {
  width: 4.75rem;
  // background-color: purple;
}

p {
  margin: 0;
}

@media (min-width: 768px) {
  .rune-card {
    height: 12rem;
    width: 8rem;
  }
}
</style>