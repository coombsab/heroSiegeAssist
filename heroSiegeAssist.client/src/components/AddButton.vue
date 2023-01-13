<template>
  <div class="add-button">
    <button class="d-flex gap-3 align-items-center px-2" data-bs-toggle="modal" :data-bs-target="'#' + modalId">
      <p class="text-visible m-0">{{buttonText}} </p><i class="mdi mdi-plus fs-1 text-visible"></i>
    </button>
  </div>
</template>

<script>
export default {
  props: {
    buttonText: { type: String },
    modalId: { type: String }
  },

  setup(props) {

    return {
    }
  }
}
</script>

<style scoped lang="scss">
.add-button {
  position: absolute;
  top: 1%;
  right: 1%;
  backdrop-filter: blur(2px);
}

.add-button>button {
  background-color: transparent;
  border: none;
  border-radius: 0.75rem;
}

.add-button>button:hover {
  filter: drop-shadow(0.5px 0.5px 5px rgba(0,255,255,0.25));
  // box-shadow: inset 0px 5px 10px 0px rgba(0,255,255,0.7);
}
</style>