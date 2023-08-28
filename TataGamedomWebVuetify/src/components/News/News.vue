<template>
  <NewsCarousel />
  <v-main style="position: relative; background-color: #01010f">
    <v-container class="container">
      <v-row>
        <!-- <v-col cols="9" v-for="(item, index) in news" :key="item.id" :offset="index == 0 ? index : 3"> -->
        <v-col cols="9" v-for="item in news" :key="item.id">
          <v-sheet
            min-height="100"
            rounded="lg"
            style="background-color: #01010f; box-shadow: 2px 2px 10px #a1dfe9"
            theme="dark"
          >
            <v-card-item>
              <div class="d-flex">
                <img
                  style="
                    width: 400px;
                    height: 225px;
                    object-fit: cover;
                    cursor: pointer;
                  "
                  :src="img + item.coverImg"
                  @click="GotoNewsPage(item.id)"
                />
                <div class="ms-5">
                  <div
                    class="text-h4 mb-2 blue"
                    style="cursor: pointer"
                    @click="GotoNewsPage(item.id)"
                  >
                    {{ item.title }}
                  </div>
                  <v-chip class="f9ee08 mb-2 me-2">#{{ item.name }}</v-chip>
                  　{{ relativeTime(item.scheduleDate) }}　　
                  <v-icon class="mb-1">mdi-eye </v-icon>
                  Views {{ item.viewCount }}　　 {{ item.likeCount }}個人說👍
                  <div
                    v-html="truncateAndEllipsis(item.content, 150)"
                    class="mt-5"
                  ></div>
                  <div style="color: gray; margin-top: 20px"></div>
                </div>
              </div>
            </v-card-item>
          </v-sheet>
        </v-col>

        <v-col cols="4" style="position: absolute; left: 71%; max-width: 550px">
          <v-sheet
            rounded="lg"
            min-height="100"
            style="background-color: #01010f; color: white"
            theme=" dark"
          >
            <h1 class="blue">關鍵字搜尋</h1>
            <SearchTextBox
              class="mt-2"
              style="background-color: #01010f"
              @searchInput="inputHandler"
            >
            </SearchTextBox>
          </v-sheet>
        </v-col>

        <v-col cols="4" class="gameclass">
          <v-sheet
            rounded="lg"
            min-height="400"
            style="background-color: #01010f"
            theme="dark"
          >
            <h1 class="blue">遊戲類別</h1>
            <NewsGameClass
              @classificationInput="classificationHandler"
              class="mt-10"
            ></NewsGameClass>
          </v-sheet>
        </v-col>

        <v-col cols="4" class="hotnews">
          <v-sheet
            rounded="lg"
            min-height="500"
            style="background-color: #01010f"
            theme="dark"
          >
            <h1 class="blue">熱門新聞</h1>
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
  window.scrollTo({
    top: 500,
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
    "yyyy年MM月dd日 EEEE HH:mm",
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

.balck {
  background-color: #01010f;
}

ul {
  list-style: none;
}

html {
  background-color: #01010f;
}

.blue {
  color: #a1dfe9;
}
</style>