<template>
  <v-card style="background-color: #01010f; box-shadow: 2px 2px 10px #a1dfe9" theme="dark" class=" mt-5" width="450"
    v-for="item in news" :key="item.id" @click="GotoNewsPage(item.id)">
    <div class="d-flex">
      <img style="height: 200px; width: 450px" :src="img + item.coverImg" />
    </div>
    <v-card-text> {{ item.title }} </v-card-text>
    <v-card-text> {{ relativeTime(item.scheduleDate) }} </v-card-text>
  </v-card>
</template>
    
<script setup>
import { onMounted, reactive, ref } from "vue";
import { useRouter } from "vue-router";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";
const router = useRouter();

const news = ref([]);
const img = "https://localhost:7081/Files/NewsImages/";

const loadNewstop5 = async () => {
  const response = await fetch("https://localhost:7081/api/News/HotNews");
  const data = await response.json();
  news.value = data;
  console.log("HOTNEWS", news);
};

onMounted(() => {
  loadNewstop5();
});

const GotoNewsPage = async (newsId) => {
  window.scrollTo({
    top: 500,
  });
  router.push({
    name: "NewsPage",
    params: { newsId: newsId },
  });
};

const relativeTime = (datetime) => {
  const formattedDate = format(
    new Date(datetime),
    "yyyy年MM月dd日 EEEE HH:mm",
    {
      locale: zhTW,
    }
  );
  return formattedDate;
};
</script>
    
<style></style>