<template>
  <v-carousel v-model="model" show-arrows="hover" cycle interval="3000">
    <v-carousel-item
      v-for="image in productData.productImg"
      :key="image"
      :src="imgLink + image"
      cover
    >
    </v-carousel-item>
  </v-carousel>
  <v-sheet class="me-auto">
    <v-slide-group
      v-model="model"
      class="pa-4 d-flex justify-center align-center"
      center-active
      show-arrows
    >
      <v-slide-group-item
        v-for="image in productData.productImg"
        :key="image"
        v-slot="{ toggle }"
        class="d-flex justify-center align-center"
      >
        <v-card class="ma-4" height="120" width="250" @click="toggle">
          <v-img :src="imgLink + image" cover />
          <div class="d-flex fill-height align-center justify-center"></div>
        </v-card>
      </v-slide-group-item>
    </v-slide-group>
  </v-sheet>
</template>

<script setup>
import { ref } from "vue";

const props = defineProps(["productData"]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const model = ref(0);
</script>

<style>
</style>