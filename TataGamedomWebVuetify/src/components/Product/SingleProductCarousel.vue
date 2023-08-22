<template>
  <div>
    <v-carousel v-model="currentIndex" hide-delimiters :show-arrows="false" cycle class="h-screen">
      <v-carousel-item v-for="image in productData.productImg" :key="image" :src="imgLink + image" cover>
      </v-carousel-item>
    </v-carousel>
    <v-sheet class="me-auto">
      <v-slide-group v-model="currentIndex" class="pa-4 d-flex justify-center align-center" center-active show-arrows>
        <v-slide-group-item v-for="image in productData.productImg" :key="image" v-slot="{ toggle }">
          <v-card class="ma-4" height="120" width="250" @click="toggle">
            <v-img :src="imgLink + image" cover />
            <div class="d-flex fill-height align-center justify-center"></div>
          </v-card>
        </v-slide-group-item>
      </v-slide-group>
    </v-sheet>
  </div>
</template>

<script setup>
import { ref } from "vue";
const currentIndex = ref(0);
const props = defineProps(["productData"]);
const imgLink = "https://localhost:7081/Files/Uploads/";
</script>

<style></style>