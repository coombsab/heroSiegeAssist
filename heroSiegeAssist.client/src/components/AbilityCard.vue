<template>
  <div class="ability-card">
    <div class="card-wrapper d-flex flex-column p-3 text-center text-visible">
      <p class="fs-4">{{ ability.name }}</p>
      <div class="flex-grow-1 d-flex justify-content-center align-items-center">
        <p class="fs-6">{{ ability.description }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    ability: { type: Object }
  },

  setup(props) {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.ability-card {
  background-color: transparent;
  height: 25vh;
  width: 35vw;
  box-shadow: 0.5px 0.5px 10px 0px rgba(0, 255, 255, 0.25), -0.5px -0.5px 10px 0px rgba(0, 255, 255, 0.25);
  border-radius: 1rem;
}

.card-wrapper {
  height: 100%;
  width: 100%;
  border-radius: 1rem;
  background-color: rgba(0, 0, 0, 0.75);
  display: flex;
  align-items: center;
  // position: relative;
}

img {
  height: 25px;
  width: 20px;
}

p {
  margin: 0;
}

@media (min-width: 768px) {
  .ability-card {
    height: 25vh;
    width: 15vw;
  }
}
</style>