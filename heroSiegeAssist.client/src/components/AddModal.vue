<template>
  <div class="modal fade" :id="modalId" tabindex="-1" :aria-labelledby="modalId + 'Label'" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
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

</style>