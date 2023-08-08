<template>
  <NewsCarousel />
  <v-app id="inspire">
    <v-main class="bg-grey-lighten-3">
      <v-container>
        <v-row>
          <v-col cols="3" class="">
            <v-sheet rounded="lg" min-height="268">
              <SearchTextBox class="ms-5 mt-5" />
            </v-sheet>
          </v-col>

          <v-col
            cols="9"
            v-for="(item, index) in news"
            :key="item.id"
            :offset="index == 0 ? index : 3"
          >
            <v-sheet min-height="100" rounded="lg">
              <v-card-item style="">
                <div class="d-flex">
                  <v-img
                    style="height: 225px; width: 400px"
                    :src="img + item.coverImg"
                    alt=""
                  />
                  <div class="ms-5">
                    <div class="text-h4 mb-2">標題{{ item.title }}</div>
                    <br />
                    <div class="">內容{{ item.content }}</div>
                    <div class="text-caption mt-7">
                      時間{{ item.scheduleDate }}
                    </div>
                    <br />
                    <div>{{ item.name }}</div>
                    <v-btn style="left: 470px" variant="outlined"> 詳細 </v-btn>
                  </div>
                </div>
              </v-card-item>
            </v-sheet>
          </v-col>

          <!-- <v-col cols="2">
            <v-sheet rounded="lg" min-height="268"> </v-sheet>
          </v-col> -->
        </v-row>
      </v-container>
    </v-main>
  </v-app>
  <!-- <div class="mt-10">
    <v-row>
      <v-col cols="2">
        <SearchTextBox class="ms-5" />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="7" v-for="item in news" :key="item.id" class="mx-auto">
        <v-card class="mx-auto" max-width="100%" variant="outlined">
          <v-card-item>
            <div>
              <div class="text-overline mb-1">OVERLINE</div>
              <div class="text-h6 mb-1">Headline</div>
              <div class="text-caption">
                Greyhound divisely hello coldly fonwderfully
              </div>
            </div>
          </v-card-item>

          <v-card-actions>
            <v-btn variant="outlined"> Button </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </div> -->
</template>
    
<script setup>
import { ref, reactive } from "vue";

import NewsCarousel from "../News/NewsCarousel.vue";
import SearchTextBox from "../News/SearchTextBox.vue";

// const keyword = ref("");
const news = ref([]);
const title = ref("");
const content = ref("");
const scheduleDate = ref("");

const totalPages = ref(1); //共幾頁
const thePage = ref(1); //第幾頁
const API = "https://localhost:7081/api/";

const loadNews = async () => {
  const response = await fetch(`${API}News`);
  const datas = await response.json();
  news.value = datas.news;
  console.log(news.value);
  console.log(news.value.title);
};

loadNews();

let img = "https://localhost:7081/Files/NewsImages/";
</script>


    
<style>
</style>