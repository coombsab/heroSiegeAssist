<template>
  <div class="abilities d-flex justify-content-center align-items-center gap-4">
    <AbilityCard v-for="a in abilities" :key="a.name" :ability="a" />
  </div>
  <AddButton :buttonText="'Add Ability'" :modalId="'addAbilityModal'" />
  <AddModal :modalId="'addAbilityModal'">
    <AddAbilityForm />
  </AddModal>
</template>

<script>
import { onMounted, computed } from "vue";
import { AppState } from "../AppState";
import { abilitiesService } from "../services/AbilitiesService";
import Pop from "../utils/Pop";

export default {
  setup() {
    async function getAbilities() {
      try {
        await abilitiesService.getAbilities()
      }
      catch(error) {
        Pop.error(error.message, "[getAbilities] > AbilitiesPage")
      }
    }

    onMounted(() => {
      getAbilities()
    })

    return {
      abilities: computed(() => AppState.abilities.sort((a, b) => a.name.localeCompare(b.name)))
    }
  }
}
</script>

<style scoped lang="scss">
  .abilities {
    background-color: black;
    height: 100vh;
  }
</style>