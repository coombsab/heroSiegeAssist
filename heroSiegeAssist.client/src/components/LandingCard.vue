<template>
  <div class="landing-card" :style="{ backgroundImage: `url(${background})` }">
    <div class="card-wrapper">
      <button @click="reRoute()">
        <p class="m-auto fs-3 text-visible">{{ title }}</p>
      </button>
    </div>
  </div>
</template>

<script>
import { useRouter } from "vue-router";
import Pop from "../utils/Pop";

export default {
  props: {
    title: { type: String },
    background: { type: String }
  },

  setup(props) {
    const router = useRouter();

    return {
      reRoute() {
        try {
          router.push({ name: `${props.title}` })
        }
        catch (error) {
          Pop.error(`${props.title} page could not be found.`, `[reRoute > LandingCard.vue] ${error.message}, Msg:`)
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
.landing-card {
  border-radius: 1rem;
  height: 20vh;
  width: 35vw;
  background-color: purple;
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
  // box-shadow: 10px 5px 5px teal;
  box-shadow: 0.5px 0.5px 10px 0px rgba(0,255,255,0.25), -0.5px -0.5px 10px 0px rgba(0,255,255,0.25);
  // box-shadow: 0px 5px 10px 0px rgba(0,255,255,0.7);
  // box-shadow:  7px 7px 15px rgba(0, 255, 255,0.5), -5px -5px 15px rgba(0, 255, 255, 0.25);
}

.landing-card:hover {
  transform: translateY(-10px);
  // box-shadow: inset 0px 5px 10px 5px rgba(0,255,255,0.7);

}

.card-wrapper {
  height: 100%;
  width: 100%;
  border-radius: 1rem;
  background-color: rgba(0, 0, 0, 0.75);
  display: flex;
  justify-content: center;
  align-items: center;

  >button {
    background-color: transparent;
    border: none;
    height: 100%;
    width: 100%;
  }
}

@media (min-width: 768px) {
  .landing-card {
    height: 28rem;
    width: 16rem;
  }
}

// @media (min-width: 1440px) {
//   .landing-card {
//     height: 36rem;
//     width: 24rem;
//   }
// }
</style>