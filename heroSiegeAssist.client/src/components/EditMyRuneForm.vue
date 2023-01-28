<template>
  <div class="add-my-rune-form">
    <form @submit.prevent="handleSubmit()">
      <div class="title mb-3 px-3 d-flex justify-content-between align-items-center">
        <p class="fs-4 m-0 text-visible">Edit {{ activeRune?.name }}</p>
        <button type="submit" data-bs-dismiss="modal"><i class="mdi mdi-plus-outline fs-4 text-visible"></i></button>
      </div>
        <div class="form-floating mb-3">
          <input type="number" class="form-control bg-dark text-secondary text-lighten-3"
            id="floatingInputMyRuneQuantity" placeholder="Quantity" v-model="editable.quantity" required min="1">
          <label for="floatingInputMyRuneQuantity" class="text-secondary text-lighten-3">Quantity</label>
      </div>
    </form>
  </div>
</template>

<script>
import { ref, computed } from "vue";
import { AppState } from "../AppState";
import Pop from "../utils/Pop";
import { accountService } from "../services/AccountService";

export default {
  setup() {
    const editable = ref({})

    return {
      editable,
      runes: computed(() => AppState.runes.sort((a, b) => a.name.localeCompare(b.name))),
      activeRune: computed(() => AppState.activeRune),
      async handleSubmit() {
        try {
          await accountService.editMyRune(editable.value)
          editable.value = {}
        }
        catch (error) {
          Pop.error(error.message, "[handleSubmit] > EditMyRuneForm")
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