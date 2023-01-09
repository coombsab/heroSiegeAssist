<template>
  <div class="add-runeword">
    <button class="d-flex gap-3 align-items-center px-2">
      <p class="text-visible m-0">Add runeword </p><i class="mdi mdi-plus fs-1 text-visible"></i>
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
.add-runeword {
  position: absolute;
  top: 1%;
  right: 1%;
  backdrop-filter: blur(2px);
}

.add-runeword>button {
  background-color: transparent;
  border: none;
  border-radius: 0.75rem;
}


.add-runeword>button:hover {
  // box-shadow: inset 0px 5px 10px 0px rgba(0,255,255,0.7);
  // box-shadow: inset 0.5px 0.5px 10px 0px rgba(0,255,255,0.25), inset 0.5px 0.5px 10px 0px rgba(0,255,255,0.25);
  filter: drop-shadow(0.5px 0.5px 5px rgba(0, 255, 255, 0.25));
  // box-shadow: inset 5px 5px 12px #006666,
  //           inset -5px -5px 12px #00ffff;
}
</style>