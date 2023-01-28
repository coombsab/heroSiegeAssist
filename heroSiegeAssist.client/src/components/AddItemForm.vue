<template>
  <div class="add-item-form">
    <div class="title mb-3 px-3 d-flex justify-content-between align-items-center">
      <p class="fs-4 m-0 text-visible">Add Item</p>
      <button type="submit" form="submitItemForm" data-bs-dismiss="modal"><i class="mdi mdi-plus-outline fs-4 text-visible"></i></button>
    </div>
    <form @submit.prevent="handleSubmit()" id="submitItemForm">
      <div class="container-fluid">
        <div class="row">
          <div class="col-12">
            <div class="form-floating mb-3">
              <input type="text" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputItemName"
                placeholder="Name" v-model="editable.name" required>
              <label for="floatingInputItemName" class="text-secondary text-lighten-3">Name</label>
            </div>
          </div>
          <div class="col-6">
            <div class="form-floating mb-3 select-wrapper">
              <select class="form-control bg-dark text-secondary text-lighten-3" id="floatingSelectItemSlot"
                placeholder="ItemSlot" v-model="editable.itemSlot" required>
                <option v-for="i in possibleItemSlots" :value="i">{{ i }}</option>
              </select>
              <label for="floatingSelectItemSlot" class="text-secondary text-lighten-3">ItemSlot</label>
            </div>
          </div>
          <div class="col-6">
            <div class="form-floating mb-3 select-wrapper">
              <select class="form-control bg-dark text-secondary text-lighten-3" id="floatingSelectItemType"
                placeholder="ItemType" v-model="editable.itemType" required>
                <option v-for="i in possibleItemTypes" :value="i">{{ i }}</option>
              </select>
              <label for="floatingSelectItemType" class="text-secondary text-lighten-3">ItemType</label>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { ref, computed } from "vue";
import { AppState } from "../AppState";
import { itemsService } from "../services/ItemsService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})
    const effectEditable = ref({})

    return {
      editable,
      effectEditable,
      possibleItemSlots: computed(() => AppState.possibleItemSlots),
      possibleItemTypes: computed(() => AppState.possibleItemTypes),
      async handleSubmit() {
        try {
          await itemsService.addItem(editable.value)
          editable.value = {}
        }
        catch (error) {
          Pop.error(error.message, "[handleSubmit] > AddItemForm")
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
button {
  background-color: transparent;
  border: none;
}

button:hover {
  filter: drop-shadow(0.5px 0.5px 5px rgba(0, 255, 255, 0.25));
}

.w-30 {
  width: 30%;
}
</style>