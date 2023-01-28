<template>
  <div class="add-ability-form">
    <div class="title mb-3 px-3 d-flex justify-content-between align-items-center">
      <p class="fs-4 m-0 text-visible">Add Item</p>
      <button type="submit" form="submitItemForm" data-bs-dismiss="modal"><i class="mdi mdi-plus-outline fs-4 text-visible"></i></button>
    </div>
    <form @submit.prevent="handleSubmit()" id="submitItemForm">
      <div class="container-fluid">
        <div class="row">
          <div class="col-12">
            <div class="form-floating mb-3">
              <input type="text" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputAbilityName"
                placeholder="Name" v-model="editable.name" required>
              <label for="floatingInputAbilityName" class="text-secondary text-lighten-3">Name</label>
            </div>
          </div>
          <div class="col-12">
            <div class="form-floating mb-3 select-wrapper">
              <textarea class="form-control bg-dark text-secondary text-lighten-3" id="floatingSelectAbilityDescription"
                placeholder="AbilityDescription" v-model="editable.description" required>
              </textarea>
              <label for="floatingSelectAbilityDescription" class="text-secondary text-lighten-3">AbilityDescription</label>
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
import { abilitiesService } from "../services/AbilitiesService";
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
          await abilitiesService.addAbility(editable.value)
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

#floatingSelectAbilityDescription {
  height: 10.8rem;
}
</style>