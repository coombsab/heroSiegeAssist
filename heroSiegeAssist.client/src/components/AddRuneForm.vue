<template>
  <div class="add-rune-form">
    <form @submit.prevent="handleSubmit()">
      <div class="title mb-3 px-3 d-flex justify-content-between align-items-center">
        <p class="fs-4 m-0 text-visible">Add Rune</p>
        <button type="submit" data-bs-dismiss="modal"><i class="mdi mdi-plus-outline fs-4 text-visible"></i></button>
      </div>
      <div class="form-floating mb-3">
        <input type="text" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputRuneName"
          placeholder="Name" v-model="editable.name" required>
        <label for="floatingInputRuneName" class="text-secondary text-lighten-3">Name</label>
      </div>
      <div class="d-flex justify-content-between gap-1">
        <div class="form-floating mb-3 flex-shrink-1 w-30">
          <input type="text" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputRuneEffect"
          placeholder="Effect Value" v-model="effectEditable.value" required>
          <label for="floatingInputRuneEffect" class="text-secondary text-lighten-3">Effect Value</label>
        </div>
        <div class="form-floating mb-3 flex-grow-1">
          <select class="form-select bg-dark text-secondary text-lighten-3" id="floatingSelectRuneEffectText" v-model="effectEditable.text" required>
            <option v-for="e in effectsText" :key="e.name" :value="e.name">{{ e.name }}</option>
          </select>
          <label for="floatingSelectEffectText" class="text-secondary text-lighten-3">Effect Text</label>
        </div>
      </div>
      <div class="form-floating mb-3">
        <input type="text" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputRuneTier"
          placeholder="Tier" v-model="editable.tier" required>
        <label for="floatingInputRuneTier" class="text-secondary text-lighten-3">Tier</label>
      </div>
      <div class="form-floating mb-3">
        <input type="text" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputRuneDropRate"
          placeholder="DropRate" v-model="editable.dropRate" required>
        <label for="floatingInputRuneDropRate" class="text-secondary text-lighten-3">DropRate</label>
      </div>
      <div class="form-floating">
        <input type="URL" class="form-control bg-dark text-secondary text-lighten-3" id="floatingInputRuneImage"
          placeholder="Image URL" v-model="editable.img" required>
        <label for="floatingInputRuneImage" class="text-secondary text-lighten-3">Image URL</label>
      </div>
    </form>
  </div>
</template>

<script>
import { ref, computed } from "vue";
import { AppState } from "../AppState";
import { runesService } from "../services/RunesService";
import Pop from "../utils/Pop";

export default {
  setup() {
    const editable = ref({})
    const effectEditable = ref({})

    return {
      editable,
      effectEditable,
      effectsText: computed(() => AppState.effectsText),
      async handleSubmit() {
        try {
          editable.value.effect = effectEditable.value.value + " " + effectEditable.value.text
          await runesService.addRune(editable.value)
          editable.value = {}
          effectEditable.value = {}
        }
        catch(error) {
          Pop.error(error.message, "[handleSubmit] > AddRuneForm")
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