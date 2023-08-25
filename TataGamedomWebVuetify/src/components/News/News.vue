<template>
  <NewsCarousel />
  <v-main class="bg-grey-lighten-3" style="position: relative">
    <v-container class="container">
      <v-row>
        <!-- <v-col cols="9" v-for="(item, index) in news" :key="item.id" :offset="index == 0 ? index : 3"> -->
        <v-col cols="9" v-for="item in news" :key="item.id">
          <v-sheet min-height="100" rounded="lg">
            <v-card-item style="">
              <div class="d-flex">
                <img
                  style="height: 225px; width: 400px"
                  :src="img + item.coverImg"
                  @click="GotoNewsPage(item.id)"
                />
                <div class="ms-5">
                  <div class="text-h4 mb-2" @click="GotoNewsPage(item.id)">
                    {{ item.title }}
                  </div>
                  <div
                    v-html="truncateAndEllipsis(item.content, 50)"
                    class=""
                  ></div>
                  <!-- <div class="">{{ item.content }}</div> -->

                  <div>{{ item.name }}</div>
                  <div class="text-caption mt-7">
                    {{ relativeTime(item.scheduleDate) }}
                    <br />
                    點閱率{{ item.viewCount }}
                  </div>
                  <v-btn
                    style="position: absolute"
                    variant="outlined"
                    @click="GotoNewsPage(item.id)"
                    >詳細
                  </v-btn>
                </div>
              </div>
            </v-card-item>
          </v-sheet>
        </v-col>

        <v-col cols="4" style="position: absolute; left: 71%; max-width: 550px">
          <v-sheet rounded="lg" min-height="100">
            <h1>關鍵字搜尋</h1>
            <SearchTextBox
              class="mt-2"
              @searchInput="inputHandler"
            ></SearchTextBox>
          </v-sheet>
        </v-col>

        <v-col cols="4" class="gameclass">
          <v-sheet rounded="lg" min-height="400">
            <h1>遊戲類別</h1>
            <NewsGameClass
              @classificationInput="classificationHandler"
              class="mt-10"
            ></NewsGameClass>
          </v-sheet>
        </v-col>

        <v-col cols="4" class="hotnews">
          <v-sheet rounded="lg" min-height="500">
            <h1 class="">熱門新聞</h1>
            <HotNews></HotNews>
          </v-sheet>
        </v-col>
      </v-row>
    </v-container>
    <div class="text-center">
      <v-pagination
        v-model="thePage"
        :length="totalPages"
        :total-visible="5"
        @update:model-value="clickHandler"
      ></v-pagination>
    </div>
  </v-main>
</template>
    
<script setup>
import { ref, reactive, onMounted, watchEffect } from "vue";
import NewsCarousel from "../News/NewsCarousel.vue";
import SearchTextBox from "../News/SearchTextBox.vue";
import NewsGameClass from "./NewsGameClass.vue";
import HotNews from "../News/HotNews.vue";
import { useRoute, useRouter } from "vue-router";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";

const keyword = ref("");
const news = ref([]);
const name = ref("");
const title = ref("");
const content = ref("");
const scheduleDate = ref("");
const totalPages = ref(1); //共幾頁
const thePage = ref(1); //第幾頁
const router = useRouter();
const route = useRoute();
const classification = ref("");
const API = "https://localhost:7081/api/";
let img = "https://localhost:7081/Files/NewsImages/";

const loadNews = async () => {
  const response = await fetch(
    `${API}News?keyword=${keyword.value}&page=${thePage.value}&gamesCategory=${classification.value}`
  );
  const datas = await response.json();
  news.value = datas.news;
  totalPages.value = datas.totalPage;
  console.log("123132", datas);
  //console.log("456456", news.value);
};

onMounted(() => {
  if (keyword.value == "") {
    loadNews();
  }
});

//搜尋
const inputHandler = (value) => {
  keyword.value = value;
  loadNews();
};

//遊戲分類
const classificationHandler = (value) => {
  if (value === "所有遊戲") {
    classification.value = "";
  } else {
    classification.value = value;
  }
  loadNews();
};

//分頁
const clickHandler = (nextPage) => {
  thePage.value = nextPage;
  loadNews();

  window.scrollTo({
    top: 500,
    behavior: "smooth",
  });
};

// 定義過濾器，限制顯示字數並添加省略號
const truncateAndEllipsis = (value, limit) => {
  if (value.length > limit) {
    return value.substring(0, limit) + "...";
  } else {
    return value;
  }
};

//跳到新聞主頁
const GotoNewsPage = async (newsId) => {
  router.push({
    name: "NewsPage",
    params: { newsId: newsId },
  });
};

const once = (func) => {
  let executed = false;
  return function (...args) {
    if (!executed) {
      executed = true;
      return func.apply(this, args);
    }
  };
};

const searchOnce = once(function () {
  if (typeof route.query.gamesCategory !== "undefined") {
    classification.value = route.query.gamesCategory;
  }
  if (typeof route.query.keyword !== "undefined") {
    keyword.value = route.query.keyword;
  }
});

const relativeTime = (datetime) => {
  const formattedDate = format(
    new Date(datetime),
    "yyyy年MM月dd日 EEEE HH:mm:ss",
    {
      locale: zhTW,
    }
  );
  return formattedDate;
};

watchEffect(() => {
  searchOnce();
});
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