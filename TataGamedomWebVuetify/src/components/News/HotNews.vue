<template>
  <H2>是我啦熱門新聞</H2>
  <v-card class="mx-auto" width="400" v-for="item in news" :key="item.id">
    <template v-slot:title>{{ item.title }}</template>
    <div class="d-flex">
      <img
        style="height: 225px; width: 400px"
        :src="img + item.coverImg"
        alt=""
      />
    </div>
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
const news = ref([]);
const img = "https://localhost:7081/Files/NewsImages/";

const loadNews = async () => {
  const response = await fetch("https://localhost:7081/api/News/HotNews");
  const data = await response.json();
  news.value = data;
  console.log(data);
};

onMounted(() => {
  loadNews();
});
</script>
    
<style>
</style>