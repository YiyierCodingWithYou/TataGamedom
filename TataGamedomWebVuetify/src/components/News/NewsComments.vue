<template>
  <div style="height: 70px" ref="bookmark"></div>
  <hr />
  <h1 style="color: #a1dfe9; margin-bottom: 15px" id="comment">新聞評語</h1>
  <div
    v-for="item in newsData.newsComments"
    :key="item"
    class="mb-5 comment-container"
  >
    <div class="comment-info">
      <img
        style="margin: 0 10px; height: 60px; width: 60px; border-radius: 50%"
        :src="icons + item.iconImg"
        alt=""
      />
      <div class="comment-text">
        <div style="color: #a1dfe9">{{ item.name }} :</div>
        <div style="width: 800px">{{ item.content }}</div>
        <div style="font-size: 8px; color: grey">
          發表於:{{ relativeTime(item.time) }}
        </div>
      </div>
    </div>
  </div>

  <div
    class="mt-5 me-5"
    style="display: flex; justify-content: flex-end; align-items: center"
  >
    <v-btn
      class=""
      variant="text"
      icon="mdi-thumb-up"
      color="blue-lighten-2"
      @click="likesCheck"
    ></v-btn>
    {{ newsData.likeCount }}人說讚
  </div>

  <v-form style="padding: 5px 15px">
    <h2>發表新聞評語</h2>
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
        type="button"
        :disabled="comment.length < 10 || comment.length > 100"
        style="color: #01010f; background-color: #fbf402; margin-top: 10px"
        >送出</v-btn
      >
    </div>
    <div v-else>
      <v-card
        height="100"
        class="d-flex align-center justify-center"
        style="border: 1px solid #fbf402; background-color: #01010f"
      >
        <p>請先登入會員以啟用評論功能，<a href="/Members/Login">點此登入</a></p>
      </v-card>
    </div>
  </v-form>
</template>
    
<script setup>
import axios from "axios";
import { ref, onMounted, computed, nextTick } from "vue";
import { useRoute, useRouter } from "vue-router";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";
import { useStore } from "vuex";
import Swal from "sweetalert2";

const router = useRouter();
const route = useRoute();
const newsData = ref([]);
const newsComments = ref([]);
const scheduleDate = ref("");
const newsId = ref(parseInt(route.params.newsId, 10));
const comment = ref("");
const bookmark = ref(null);
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
    scheduleDate.value = datas.scheduleDate;
  } catch (err) {}
};

onMounted(() => {
  loadData();
});

//偷你書籤
const returnComments = async () => {
  await nextTick(() => {
    if (bookmark.value) {
      const offset = bookmark.value.offsetTop;
      window.scrollTo({
        top: offset,
        behavior: "smooth",
      });
    }
  });
};

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
      Swal.fire({ title: "發表留言成功", icon: "success" });
      comment.value = "";
      loadData();
      returnComments();
    })
    .catch((error) => {
      Swal.fire({ title: "留言失敗", icon: "error" });
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
        Swal.fire({
          icon: "success",
          title: "已成功按讚",
          showConfirmButton: false,
          timer: 1500,
        });
      } else {
        loadData();
        Swal.fire({
          icon: "error",
          title: "已取消按讚",
          showConfirmButton: false,
          timer: 1500,
        });
      }
    })
    .catch((err) => {
      console.log(err);
      Swal.fire("按讚失敗");
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
  Swal.fire("請先登入會員以使用按讚功能");
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