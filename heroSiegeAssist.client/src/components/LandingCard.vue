<template>
  <div class="landing-card text-visible">
    <div class="card-wrapper">
      <p class="m-auto fs-3">{{title}}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: { type: String }
  },

  setup(props) {
    
    return {
      
    }
  }
}
</script>

<style scoped lang="scss">
  .landing-card {
    border-radius: 1rem;
    height: 18rem;
    width: 12rem;
    background-color: purple;
  }

  .card-wrapper {
    height: 100%;
    width: 100%;
    border-radius: 1rem;
    background-color: rgba(0, 0, 0, 0.75);
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
</style>