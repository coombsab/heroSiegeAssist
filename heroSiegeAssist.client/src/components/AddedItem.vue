<template>
  <p class="m-0 text-secondary text-lighten-3 fw-1">{{ title }}:</p>
  <div class="d-flex gap-1 align-items-center justify-content-between added-item" v-for="i in arrayOfItems">
    <p class="m-0 text-secondary">{{ i }}</p>
    <button type="button"><i class="mdi mdi-delete-circle text-secondary"></i></button>
  </div>
</template>

<script>
export default {
  props: {
    arrayOfItems: { type: Array },
    title: { type: String }
  },

  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
button {
  background-color: transparent;
  // background-color: green;
  border: none;
}

.added-item {
  padding-left: 0.5rem;
  padding-right: 0.25rem;
  border-radius: 0.375rem;
}

.added-item:hover {
  background-color: rgba(128, 0, 128, 0.25);
}

.fw-1 {
  font-weight: 700;
}
</style>