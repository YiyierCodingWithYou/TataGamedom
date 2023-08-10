<template>
  <v-carousel
    hide-delimiters
    show-arrows="hover"
    cycle
    interval="3000"
    v-model="currentIndex"
    style="height: 500px"
  >
    <v-carousel-item
      v-for="item in news"
      :key="item.id"
      :src="img + item.coverImg"
      cover
    >
      <div class="title">
        <p class="titleword">{{ item.title }}</p>
      </div>
    </v-carousel-item>
  </v-carousel>

  <!-- <div>
    <v-carousel
      show-arrows="hover"
      cycle
      interval="3000"
      v-model="currentIndex"
    >
      <v-carousel-item
        v-for="item in news"
        :src="img + item.coverImg"
        :key="item.id"
        cover
      ></v-carousel-item>
    </v-carousel>
  </div> -->
</template>
    

<script setup>
import { ref, reactive, onMounted } from "vue";

const news = ref([]);
const img = "https://localhost:7081/Files/NewsImages/";
const currentIndex = ref(0);
const loadNews = async () => {
  const response = await fetch("https://localhost:7081/api/News/HotNews");
  const data = await response.json();
  news.value = data;
};

onMounted(() => {
  loadNews();
});
</script>
    

<style>
.title {
  background-color: rgba(0, 0, 0, 0.8);
  height: 100px;
  margin-top: 400px;
}

.titleword {
  color: white;
  display: flex;
  font-size: 60px;
  justify-content: center;
  align-items: center;
  display: flex;
  height: 100%;
}
</style>