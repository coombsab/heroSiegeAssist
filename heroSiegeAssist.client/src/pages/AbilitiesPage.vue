<template>
  <div class="abilities d-flex justify-content-center align-items-center">
    <p class="text-visible">I'm the abilities page!</p>
  </div>
  <AddButton :buttonText="'Add Ability'" :modalId="'addAbilityModal'" />
  <AddModal :modalId="'addAbilityModal'">
    <!-- <AddRuneForm /> -->
    <p>Abilities</p>
  </AddModal>
</template>

<script>
export default {
  setup() {
    
    return {
      
    }
  }
}
</script>

<style scoped lang="scss">
  .abilities {
    background-color: black;
    height: 100vh;
  }
</style>