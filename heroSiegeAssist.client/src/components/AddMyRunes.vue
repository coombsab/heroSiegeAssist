<template>
  <div class="add-my-runes">
    <button class="d-flex gap-3 align-items-center px-2">
      <p class="text-visible m-0">Add my runes </p><i class="mdi mdi-plus fs-1 text-visible"></i>
    </button>
  </div>
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
.add-my-runes {
  position: absolute;
  top: 1%;
  right: 1%;
  backdrop-filter: blur(2px);
}

.add-my-runes>button {
  background-color: transparent;
  border: none;
  border-radius: 0.75rem;
}

.add-my-runes>button:hover {
  filter: drop-shadow(0.5px 0.5px 5px rgba(0,255,255,0.25));
  // box-shadow: inset 0px 5px 10px 0px rgba(0,255,255,0.7);
}
</style>