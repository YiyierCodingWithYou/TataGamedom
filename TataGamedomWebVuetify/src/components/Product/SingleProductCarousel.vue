<template>
  <div>
    <v-carousel
      v-model="currentIndex"
      hide-delimiters
      :show-arrows="false"
      cycle
      class="singleFullScreen"
    >
      <v-carousel-item
        v-for="image in productData.productImg"
        :key="image"
        :src="imgLink + image"
        cover
      >
      </v-carousel-item>
      <v-sheet
        class="me-auto d-flex justify-center align-center"
        height="160"
        style="
          position: absolute;
          bottom: 0;
          width: 100%;
          /* background-color: RGBA(64, 64, 64, 0.01); */
          background: linear-gradient(
            RGBA(255, 255, 255, 0.01),
            RGBA(64, 64, 64, 1)
          );
        "
      >
        <v-slide-group
          v-model="currentIndex"
          class="pa-4 d-flex justify-center align-center"
          center-active
          show-arrows
        >
          <v-slide-group-item
            v-for="image in productData.productImg"
            :key="image"
            v-slot="{ select }"
          >
            <v-card class="ma-4" height="120" width="250" @click="select">
              <v-img :src="imgLink + image" cover />
              <div class="d-flex fill-height align-center justify-center"></div>
            </v-card>
          </v-slide-group-item>
        </v-slide-group>
      </v-sheet>
    </v-carousel>

    <!-- Place slide group below the carousel -->
  </div>
</template>

<script setup>
import { ref } from "vue";
const currentIndex = ref(0);
const props = defineProps(["productData"]);
const imgLink = "https://localhost:7081/Files/Uploads/";
</script>

<style>
.singleFullScreen {
  height: calc(100vh - 64px) !important;
}
</style>