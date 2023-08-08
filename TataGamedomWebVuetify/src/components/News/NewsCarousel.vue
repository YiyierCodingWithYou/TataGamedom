<template>
  <v-carousel hide-delimiters style="height: 500px">
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
</template>
    

<script>
import { ref, onMounted } from "vue";

export default {
  setup() {
    const news = ref([]);
    const img = "https://localhost:7081/Files/NewsImages/";

    const loadNews = async () => {
      try {
        const response = await fetch("https://localhost:7081/api/News");
        const data = await response.json();
        news.value = data.news;
      } catch (error) {
        console.error("Error loading news:", error);
      }
    };

    onMounted(loadNews);

    return {
      news,
      img,
    };
  },
};
</script>
    

<style>
.title {
  background-color: rgba(0, 0, 0, 0.9);
  height: 100px;
  margin-top: 400px;
}

.titleword {
  color: white;
  display: flex;
}
</style>