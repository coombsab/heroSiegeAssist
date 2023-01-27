<template>
  <div class="item-card">
    <div class="card-wrapper d-flex flex-column p-3 text-center text-visible">
      <div class="d-flex flex-column align-items-center">
        <div class="d-flex gap-1 align-items-center">
          <!-- <img :src="item.img" :alt="item.name"> -->
          <p class="fs-5">{{ item.name }}</p>
        </div>
      </div>
      <div class="flex-grow-1 d-flex justify-content-center align-items-center gap-3">
        <p>{{ item.itemSlot }}</p>
        <p>{{ item.itemType }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    item: { type: Object }
  },

  setup(props) {

    return {

    }
  }
}
</script>

<style scoped lang="scss">
.item-card {
  background-color: transparent;
  height: 12rem;
  width: 8rem;
  border: 1px solid #f1f1f1;
  perspective: 1000px;
  /* Remove this if you don't want the 3D effect */
}

.card-wrapper {
  height: 100%;
  width: 100%;
  border-radius: 1rem;
  background-color: rgba(0, 0, 0, 0.75);
  display: flex;
  align-items: center;
  position: relative;
}

img {
  height: 25px;
  width: 20px;
}

p {
  margin: 0;
}

@media (min-width: 768px) {
  .item-card {
    height: 12rem;
    width: 8rem;
  }
}
</style>