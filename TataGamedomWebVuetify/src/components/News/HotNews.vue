<template>
  <v-card class="mx-auto mt-5" width="400" v-for="item in news" :key="item.id" @click="GotoNewsPage(item.id)">
    <div class="d-flex">
      <img style="height: 200px; width: 400px" :src="img + item.coverImg" />
    </div>
    <v-card-text> {{ item.title }} </v-card-text>
    <v-card-text> {{ item.scheduleDate }} </v-card-text>
  </v-card>
  <!-- <div>
    <ul>
      <li v-for="item in news" :key="item.id" class="mt-8">
        <div class="d-flex">
          <img :src="img + item.coverImg" width="150" cover />
          <div class="d-flex flex-column">
            <v-chip class="ma-2 w100 justify-center" color="primary">
              {{ item.title }}
            </v-chip>
            {{ item.scheduleDate }}
          </div>
        </div>
      </li>
    </ul>
  </div> -->
</template>
    
<script setup>
import { onMounted, reactive, ref } from "vue";
import { useRouter } from 'vue-router';
const router = useRouter();

const news = ref([]);
const img = "https://localhost:7081/Files/NewsImages/";


const loadNewstop5 = async () => {
  const response = await fetch("https://localhost:7081/api/News/HotNews");
  const data = await response.json();
  news.value = data;
  // console.log(data);
};

onMounted(() => {
  loadNewstop5();
});

const GotoNewsPage = async (newsId) => {
  window.scrollTo({
    top: 0,
  });
  router.push({
    name: "NewsPage",
    params: { newsId: newsId }
  })
}
</script>
    
<style></style>