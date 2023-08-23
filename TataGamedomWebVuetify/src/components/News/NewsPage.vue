<template>
  <NewsCarousel />
  <v-main class="bg-grey-lighten-3 v-main">
    <v-container>
      <v-row>
        <v-col cols="8">
          <v-sheet min-height="300vh" rounded="lg">
            <div>
              <div>{{ newsData.title }}</div>
              <div>{{ newsData.content }}</div>
              <div>{{ newsData.scheduleDate }}</div>
              <div>{{ newsData.name }}</div>
            </div>

            <div v-for="item in newsData.newsComments" :key="item" class="mt-5">
              <div>{{ item.name }}</div>
              <div>{{ item.content }}</div>
              <div>發表於:{{ relativeTime(item.time) }}</div>
            </div>

            <div
              class="mt-5"
              style="
                display: flex;
                justify-content: flex-end;
                align-items: center;
              "
            >
              <v-btn
                class=""
                variant="text"
                icon="mdi-thumb-up"
                color="blue-lighten-2"
                @click="likes"
              ></v-btn>
              {{ newsData.likeCount }}人說讚
            </div>

            <v-form style="padding: 5px 15px">
              <div v-if="$store.state.isLoggedIn">
                <v-textarea
                  :rules="rules"
                  clearable
                  variant="solo"
                  rows="4"
                  v-model="comment"
                ></v-textarea>
                <v-btn
                  @click="onSubmit"
                  type="submit"
                  :disabled="comment.length < 10 || comment.length > 500"
                  color="#FFBF5D"
                  >送出</v-btn
                >
              </div>
              <div v-else>
                <v-card height="100" class="d-flex align-center justify-center">
                  <p>
                    請先登入會員以啟用評論功能，<a href="/Members/Login"
                      >點此登入</a
                    >
                  </p>
                </v-card>
              </div>
            </v-form>
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
  </v-main>
</template>
    
<script setup >
import axios from "axios";
import { ref, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import NewsCarousel from "../News/NewsCarousel.vue";
import SearchTextBox from "../News/SearchTextBox.vue";
import NewsGameClass from "./NewsGameClass.vue";
import HotNews from "../News/HotNews.vue";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";

const router = useRouter();
const route = useRoute();
const newsData = ref([]);
const newsComments = ref([]);
const newsId = ref(parseInt(route.params.newsId, 10));
const comment = ref("");
const likeCount = ref("");

const loadData = async () => {
  try {
    const response = await fetch(
      `https://localhost:7081/api/News/${newsId.value}`
    );
    const datas = await response.json();
    newsData.value = datas;
    console.log(datas);
  } catch (err) {
    console.log("錯誤訊息", err);
  }
};

onMounted(() => {
  loadData();
});

//留言
const onSubmit = async () => {
  await axios
    .post(
      `https://localhost:7081/api/News/${newsId.value}/Comment`,
      {
        newsId: newsId.value,
        content: comment.value,
      },
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res);
      alert("發表留言成功");
    })
    .catch((error) => {
      console.log("ERRRRR", error.response.data);
      alert("留言失敗");
    });
};

const inputHandler = (value) => {
  router.push({
    name: "News",
    query: { keyword: value },
  });
};

const classificationHandler = (value) => {
  router.push({
    name: "News",
    query: {
      gamesCategory: value,
    },
  });
};

const rules = [
  (value) => !!value || "評論不可為空",
  (value) => (value && value.length >= 10) || "評論不得低於10個字",
  (value) => (value && value.length <= 500) || "評論不得超過500個字",
];

// //按讚
const likes = async () => {
  await axios
    .post(
      `https://localhost:7081/api/News/${newsId.value}/Like`,
      {
        newsId: newsId.value,
      },
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res);
      if (res.data === "成功按讚") {
        alert("已按讚");
        loadData();
      } else {
        alert("已取消按讚");
        loadData();
      }
    })
    .catch((err) => {
      console.log(err);
      alert("按讚失敗");
    });
};

//時間轉換
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
</script>
    
<style>
.v-main {
  padding-top: 0;
}
</style>