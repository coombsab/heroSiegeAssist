<template>
  <div class="add-runeword">
    <button>
      <p class="text-visible">Add runeword </p><i class="mdi mdi-plus fs-1 text-visible"></i>
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
.add-runeword>button {
  background-color: transparent;
  border: none;
}

.add-runeword>button:hover {
  box-shadow: inset 0px 5px 10px 0px rgba(0,255,255,0.7);
}
</style>