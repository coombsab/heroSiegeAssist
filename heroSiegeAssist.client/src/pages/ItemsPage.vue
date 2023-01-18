<template>
  <div class="items d-flex justify-content-center align-items-center">
    <p class="text-visible">I'm the items page!</p>
  </div>
  <AddButton :buttonText="'Add Item'" :modalId="'addItemModal'" />
  <AddModal :modalId="'addItemModal'">
    <!-- <AddRuneForm /> -->
    <p>Items</p>
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
  .items {
    background-color: black;
    height: 100vh;
  }
</style>