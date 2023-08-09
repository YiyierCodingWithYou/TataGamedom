<template>
  <NewsCarousel />
  <v-app id="inspire">
    <v-main class="bg-grey-lighten-3">
      <v-container class="container">
        <v-row>
          <!-- <v-col cols="9" v-for="(item, index) in news" :key="item.id" :offset="index == 0 ? index : 3"> -->
          <v-col cols="9" v-for="item in news" :key="item.id">
            <v-sheet min-height="100" rounded="lg">
              <v-card-item style="">
                <div class="d-flex">
                  <img style="height: 225px; width: 400px" :src="img + item.coverImg" alt="" />
                  <div class="ms-5">
                    <div class="text-h4 mb-2">{{ item.title }}</div>
                    <div class="">{{ item.content }}</div>
                    <div class="text-caption mt-7">
                      {{ item.scheduleDate }}
                    </div>
                    <div>{{ item.name }}</div>
                    <v-btn style="position: absolute" variant="outlined">詳細 </v-btn>
                  </div>
                </div>
              </v-card-item>
            </v-sheet>
          </v-col>

          <v-col cols="4" style="position: absolute; left: 71%; max-width:550px ;">
            <v-sheet rounded="lg" min-height="100">
              <SearchTextBox @searchInput="inputHandler"></SearchTextBox>
            </v-sheet>
          </v-col>

          <v-col cols="4" class="gameclass">
            <v-sheet rounded="lg" min-height="400">
              <h2>遊戲類別</h2>
              <NewsGameClass @classificationInput="classificationHandler" class="mt-10"></NewsGameClass>
            </v-sheet>
          </v-col>

          <v-col cols="4" class="hotnews">
            <v-sheet rounded="lg" min-height="500">
              <h2>熱門新聞</h2>
            </v-sheet>
          </v-col>

        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>
    
<script setup>
import { ref, reactive } from "vue";

import NewsCarousel from "../News/NewsCarousel.vue";
import SearchTextBox from "../News/SearchTextBox.vue";
import NewsGameClass from "./NewsGameClass.vue";

const keyword = ref("");
const news = ref([]);
const name = ref("")
const title = ref("");
const content = ref("");
const scheduleDate = ref("");

const totalPages = ref(1); //共幾頁
const thePage = ref(1); //第幾頁
const API = "https://localhost:7081/api/";

const loadNews = async () => {
  const response = await fetch(`${API}News?keyword=${keyword.value}`);
  const datas = await response.json();
  news.value = datas.news;
  console.log(news.value);
};

loadNews();

//搜尋
const inputHandler = (value) => {
  keyword.value = value;
  loadNews();
};

//遊戲分類
const classificationHandler = (value) => {
  if (value === "所有遊戲") {
    name.value = "";
  } else {
    name.value = value;
  }
  loadNews();
}

let img = "https://localhost:7081/Files/NewsImages/";
</script>


    
<style>
.container {
  margin-left: 0px;
}

.gameclass {
  position: absolute;
  left: 71%;
  max-width: 550px;
  margin-top: 125px;
}

.hotnews {
  position: absolute;
  left: 71%;
  max-width: 550px;
  margin-top: 550px;
}
</style>