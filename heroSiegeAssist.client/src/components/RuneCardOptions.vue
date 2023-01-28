<template>
  <div class="options-icon">
    <button @click="toggleOptions()"><i class="mdi mdi-menu-up fs-4"></i></button>
  </div>
  <div class="popover-wrapper px-2 hidden" :id="'popover-' + side + '-' + rune.name + '-' + rune.accountId">
    <div class="popover-content gap-2">
      <button @click="deleteMyRune()"><i class="mdi mdi-delete"></i></button>
      <button @click="editMyRune()" data-bs-toggle="modal" :data-bs-target="'#editMyRuneModal'"><i class="mdi mdi-cog"></i></button>
    </div>
  </div>
</template>

<script>
import { AppState } from "../AppState"
import { accountService } from "../services/AccountService"
import Pop from "../utils/Pop"

export default {
  props: {
    rune: { type: Object },
    side: { type: String }
  },

  setup(props) {

    return {
      toggleOptions() {
        let popoverElement = document.getElementById(`popover-${props.side}-${props.rune.name}-${props.rune.accountId}`)
        if (!popoverElement) {
          return
        }
        popoverElement.classList.toggle("hidden")
      },
      async deleteMyRune() {
        const yes = await Pop.confirm(`Do you want to delete ${props.rune.name}?`)
        this.toggleOptions()
        if (!yes) {
          return
        }
        await accountService.deleteMyRune(props.rune.id)
      },
      editMyRune() {
        AppState.activeRune = props.rune
        this.toggleOptions()
      }
    }
  }
}
</script>

<style scoped lang="scss">
.options-icon {
  position: absolute;
  bottom: 0;
  left: 5px;
}

button {
  background-color: transparent;
  border: none;
  padding: 0;
  margin: 0;
  color: rgb(105, 1, 105);
  // z-index: 1;
}

button:hover {
  filter: drop-shadow(0.5px 0.5px 5px rgba(0, 255, 255, 0.45));
  color: rgb(185, 3, 185);
}

.popover-wrapper {
  position: absolute;
  bottom: 5px;
  left: 50%;
  border-radius: 0 0 1rem 1rem;
  background-color: rgba(0, 0, 0, 0.75);
  transform: translateX(-50%);
}

.popover-content {
  backdrop-filter: blur(1px);
  color: rgb(105, 1, 105);
  display: flex;
}
</style>