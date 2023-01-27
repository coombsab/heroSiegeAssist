<template>
  <div class="runeword-card text-visible flex-shrink-1">
    <div class="card-wrapper d-flex flex-column p-3">
      <div class="runes-needed d-flex gap-1 flex-wrap justify-content-around px-3">
        <!-- <p v-for="r in runeword.runes" :key="runeword.name + '-' + r.name">{{r.name}}</p> -->
        <div class="d-flex flex-column align-items-center" :class="hasRune(r)" v-for="r in runeword.runes" :key="runeword.name + '-' + r.name">
          <img :src="r.img" :alt="r.name">
          <p class="m-0 rune-name">{{ r.name }}</p>
        </div>
      </div>
      <p class="fs-3 text-visible text-center capitalize">{{ runeword.name }}</p>
      <div class="effects">
        <p class="m-0 text-center" v-for="e in runeword.effects" :key="e.id">{{ e.name }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from "../AppState";

export default {
  props: {
    runeword: { type: Object }
  },

  setup(props) {

    return {
      hasRune(rune) {
        const foundRune = AppState.myRunes.find(myRune => myRune.name === rune.name)
        if(!foundRune) {
          return "rune-darken"
        } else {
          return "rune-brighten"
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
.runeword-card {
  border-radius: 1rem;
  // height: 48vh;
  width: 70vw;
  background-color: purple;
  background-image: url(../assets/img/HeroSiegeRuneWord.png);
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
  // box-shadow: 10px 5px 5px teal;
  // box-shadow: 0px 5px 10px 0px rgba(0, 255, 255, 0.7);
  box-shadow: 0.5px 0.5px 10px 0px rgba(0, 255, 255, 0.25), -0.5px -0.5px 10px 0px rgba(0, 255, 255, 0.25);
}

.runeword-card:hover {
  // transform: translateY(-10px);
  // box-shadow: inset 0px 5px 10px 5px rgba(0,255,255,0.7);

}

.runes-needed {
  width: 100%;
}

.rune-name {
  font-size: 10px;
  // text-transform: capitalize;
}

.rune-darken {
  filter: brightness(0.35);
}

.rune-brighten {
  // filter: drop-shadow(1px 1px 5px rgba(255, 255, 255, 0.25));
}

.effects {
  color: rgb(0,185,185);
}

img {
  height: 25px;
  width: 20px;
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