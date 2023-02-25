<template>
  <div class="items d-flex justify-content-center align-items-center gap-4">
    <ItemCard v-for="i in items" :key="i.name" :item="i" />
  </div>
  <AddButton :buttonText="'Add Item'" :modalId="'addItemModal'" />
  <AddModal :modalId="'addItemModal'">
    <AddItemForm />
    <!-- <p>Items</p> -->
  </AddModal>
</template>

<script>
import { computed, onMounted } from "vue";
import { AppState } from "../AppState";
import { itemsService } from "../services/ItemsService";
import Pop from "../utils/Pop";

export default {
  setup() {

    async function getItems() {
      try {
        await itemsService.getItems()
      }
      catch(error) {
        Pop.error(error.message, "[getItems] > ItemsPage")
      }
    }

    onMounted(() => {
      getItems()
    })

    return {
      items: computed(() => AppState.items.sort((a, b) => a.name.localeCompare(b.name)))
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