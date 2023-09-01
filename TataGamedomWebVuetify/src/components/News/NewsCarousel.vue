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
      @click="GotoNewsPage(item.id)"
    >
      <div class="title" style="cursor: pointer">
        <p class="titleword">{{ item.title }}</p>
      </div>
    </v-carousel-item>
  </v-carousel>
</template>
    

<script setup>
import { ref, reactive, onMounted } from "vue";
import { useRouter } from "vue-router";

const news = ref([]);
const img = "https://localhost:7081/Files/NewsImages/";
const currentIndex = ref(0);
const router = useRouter();

const loadNews = async () => {
  const response = await fetch("https://localhost:7081/api/News/HotNews");
  const data = await response.json();
  news.value = data;
};

onMounted(() => {
  loadNews();
});

const GotoNewsPage = async (newsId) => {
  router.push({
    name: "NewsPage",
    params: { newsId: newsId },
  });
  window.scrollTo({
    top: 500,
  });
};
</script>
    

<style>
.title {
  background-color: rgba(0, 0, 0, 0.8);
  height: 100px;
  margin-top: 400px;
}

.titleword {
  color: #a1dfe9;
  display: flex;
  font-size: 60px;
  justify-content: center;
  align-items: center;
  display: flex;
  height: 100%;
}

.v-responsive__content {
  cursor: pointer;
}
</style>