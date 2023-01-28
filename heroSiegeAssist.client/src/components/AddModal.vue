<template>
  <div class="modal fade" :id="modalId" tabindex="-1" :aria-labelledby="modalId + 'Label'" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content p-3">
        <slot>

        </slot>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    modalId: { type: String }
  },
  setup() {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.modal-content {
  background-color: rgba(0, 0, 0, 0);
  box-shadow: 0.5px 0.5px 10px 0px rgba(0, 255, 255, 0.25), -0.5px -0.5px 10px 0px rgba(0, 255, 255, 0.25);
  backdrop-filter: blur(2px);
}
</style>