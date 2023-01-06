<template>
  <div class="runeword-card">
    <div class="card-wrapper d-flex flex-column p-3">
      <div class="runes-needed d-flex gap-1 flex-wrap">
        <p v-for="r in runeword.runes" :key="runeword.name + '-' + r.name">{{r.name}}</p>
      </div>
      <p class="fs-3 text-visible text-center">{{runeword.name}}</p>
      <div class="effects">
        <p class="m-0 text-center" v-for="e in runeword.effects" :key="runeword.name + '-' + e">{{e}}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    runeword: { type: Object }
  },

  setup(props) {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.runeword-card {
  border-radius: 1rem;
  // height: 80vh;
  // width: 90vw;
  background-color: purple;
  background-image: url(../assets/img/HeroSiegeRuneWord.png);
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
  // box-shadow: 10px 5px 5px teal;
  box-shadow: 0px 5px 10px 0px rgba(0, 255, 255, 0.7);
}

.runeword-card:hover {
  // transform: translateY(-10px);
  // box-shadow: inset 0px 5px 10px 5px rgba(0,255,255,0.7);

}

.card-wrapper {
  height: 100%;
  width: 100%;
  border-radius: 1rem;
  background-color: rgba(0, 0, 0, 0.75);
  display: flex;
  align-items: center;

  >button {
    background-color: transparent;
    border: none;
    height: 100%;
    width: 100%;
  }
}

@media (min-width: 768px) {
  .runeword-card {
    height: 28rem;
    width: 16rem;
  }
}
</style>