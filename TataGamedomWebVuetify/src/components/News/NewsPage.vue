<template>
  <NewsCarousel />
  <v-main style="background-color: #01010f">
    <v-container>
      <v-row>
        <v-col cols="8">
          <v-sheet min-height="300vh" rounded="lg" style="background-color: #01010f; box-shadow: 2px 2px 10px #a1dfe9"
            theme="dark">
            <div>
              <div class="size blue">{{ newsData.title }}</div>
              <v-chip class="ma-2 f9ee08" @click="classificationHandler(newsData.name)">#{{ newsData.name }} </v-chip>
              {{ (newsData.scheduleDate) }}
              <hr />
              <img style="height: 550px; width: 100%" :src="img + newsData.coverImg" alt="" />
              <br />
              <div v-html="newsData.content"></div>
            </div>
            <br />
            <hr />
            <h2 style="color: #a1dfe9; margin-bottom: 15px" id="comment">新聞評語</h2>
            <div v-for="item in newsData.newsComments" :key="item" class="mb-5 comment-container">
              <div class="comment-info">
                <img style="
                    margin: 0 10px;
                    height: 60px;
                    width: 60px;
                    border-radius: 50%;
                  " :src="icons + item.iconImg" alt="" />
                <div class="comment-text">
                  <div style="color: #a1dfe9">{{ item.name }} :</div>
                  <div style="width: 800px">{{ item.content }}</div>
                  <div style="font-size: 8px; color: grey">
                    發表於:{{ relativeTime(item.time) }}
                  </div>
                </div>
              </div>
            </div>

            <div class="mt-5 me-5" style="
                display: flex;
                justify-content: flex-end;
                align-items: center;
              ">
              <v-btn class="" variant="text" icon="mdi-thumb-up" color="blue-lighten-2" @click="likesCheck"></v-btn>
              {{ newsData.likeCount }}人說讚
            </div>

            <v-form style="padding: 5px 15px">
              <h2>發表新聞評語</h2>
              <div v-if="$store.state.isLoggedIn">
                <v-textarea :rules="rules" clearable variant="solo" rows="4" v-model="comment"></v-textarea>
                <v-btn @click="onSubmit" type="submit" :disabled="comment.length < 10 || comment.length > 100" style="
                    color: #01010f;
                    background-color: #fbf402;
                    margin-top: 10px;
                  ">送出</v-btn>
              </div>
              <div v-else>
                <v-card height="100" class="d-flex align-center justify-center"
                  style="border: 1px solid #fbf402; background-color: #01010f">
                  <p>
                    請先登入會員以啟用評論功能，<a href="/Members/Login">點此登入</a>
                  </p>
                </v-card>
              </div>
            </v-form>
          </v-sheet>
        </v-col>

        <v-col cols="4" style="position: absolute; left: 71%; max-width: 550px">
          <v-sheet rounded="lg" min-height="100" style="background-color: #01010f" theme="dark">
            <h1 class="blue">關鍵字搜尋</h1>
            <SearchTextBox class="mt-2" @searchInput="inputHandler"></SearchTextBox>
          </v-sheet>
        </v-col>

        <v-col cols="4" class="gameclass">
          <v-sheet rounded="lg" min-height="400" style="background-color: #01010f" theme="dark">
            <h1 class="blue">遊戲類別</h1>
            <NewsGameClass @classificationInput="classificationHandler" class="mt-10"></NewsGameClass>
          </v-sheet>
        </v-col>

        <v-col cols="4" class="hotnews">
          <v-sheet rounded="lg" min-height="500" style="background-color: #01010f" theme="dark">
            <h1 class="blue">熱門新聞</h1>
            <HotNews></HotNews>
          </v-sheet>
        </v-col>
      </v-row>
    </v-container>
  </v-main>
</template>
    
<script setup >
import axios from "axios";
import { ref, onMounted, computed } from "vue";
import { useRoute, useRouter } from "vue-router";
import NewsCarousel from "../News/NewsCarousel.vue";
import SearchTextBox from "../News/SearchTextBox.vue";
import NewsGameClass from "./NewsGameClass.vue";
import HotNews from "../News/HotNews.vue";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";
import { useStore } from "vuex";

const router = useRouter();
const route = useRoute();
const newsData = ref([]);
const newsComments = ref([]);
const scheduleDate = ref("");
const newsId = ref(parseInt(route.params.newsId, 10));
const comment = ref("");
const likeCount = ref("");
const store = useStore();
const isLoggedIn = computed(() => store.state.isLoggedIn);
let img = "https://localhost:7081/Files/NewsImages/";
let icons = "https://localhost:7081/Files/Uploads/icons/";

const loadData = async () => {
  try {
    const response = await fetch(
      `https://localhost:7081/api/News/${newsId.value}`
    );
    const datas = await response.json();
    newsData.value = datas;
    console.log("我的TADAS", datas);
    scheduleDate.value = datas.scheduleDate;
    console.log("DATEEEEEEE", newsData.value.scheduleDate)
    console.log("aaa", newsData.name);
  } catch (err) {
    console.log("錯誤訊息", err);
  }
};

onMounted(() => {
  loadData();
  window.scrollTo({
    top: 550,
  });
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
      //  window.scrollTo({ top: 600, behavior: 'smooth' });
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
  if (value === "所有遊戲") {
    value = "";
  }
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
  (value) => (value && value.length <= 100) || "評論不得超過100個字",
];

//按讚
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
        loadData();
        alert("已按讚");
      } else {
        loadData();
        alert("已取消按讚");
      }
    })
    .catch((err) => {
      console.log(err);
      alert("按讚失敗");
    });
};

const likesCheck = () => {
  if (!isLoggedIn.value) {
    showLoginAlert();
    return;
  }
  likes();
};

const showLoginAlert = () => {
  alert("請先登入會員以使用按讚功能");
};

//時間轉換
const relativeTime = (datetime) => {
  const formattedDate = format(new Date(datetime), "yyyy年MM月dd日 HH:mm:ss", {
    locale: zhTW,
  });
  return formattedDate;
};
</script>
    
<style>
.size {
  font-size: 60px;
}

.f9ee08 {
  background-color: #f9ee08;
  color: black;
}

/* .v-main {
  padding-top: 0;
} */

.comment-container {
  display: flex;

  align-items: flex-start;
}

.comment-info {
  display: flex;
  align-items: center;
  margin-right: 10px;
}

.comment-text {
  flex: 1;
}

.blue {
  color: #a1dfe9;
}
</style>