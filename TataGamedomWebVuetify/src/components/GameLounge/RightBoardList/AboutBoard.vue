<template>
  <v-card class="w-100 my-5">
    <v-img cover max-height="250" :src="iconUrl"></v-img>
    <v-card-item>
      <v-card-title>{{ boardData?.name }}</v-card-title>
    </v-card-item>
    <v-card-subtitle>
      <span class="me-1" v-if="boardData?.isMod">你是版主獺獺</span>
      <span class="me-1" v-if="boardData?.isBucket"
        >正被水桶中，離解禁還有<br />
        <span>{{ countDownTimeComputed }}</span>
      </span>
    </v-card-subtitle>
    <v-card-text>
      <div class="d-flex justify-center align-items-center my-4">
        <v-btn v-if="!boardData?.isFollowed" @click="followAction">
          加入追蹤
        </v-btn>
        <v-btn v-if="boardData?.isFollowed" @click="followAction">
          取消追蹤
        </v-btn>
        <v-btn v-if="!boardData?.isFavorite" @click="favoriteAction">
          加入最愛
        </v-btn>
        <v-btn v-if="boardData?.isFavorite" @click="favoriteAction">
          取消最愛
        </v-btn>
      </div>
      <div class="d-flex justify-center">
        <div class="mx-5 d-flex flex-column align-center justify-center">
          <p>{{ boardData?.memberFollowCount }}</p>
          <p>追隨者</p>
        </div>
        <div class="mx-5 d-flex flex-column align-center justify-center">
          <p>{{ boardData?.postTotalCount }}</p>
          <p>貼文數</p>
        </div>
      </div>
      <v-divider class="mx-4 my-4"></v-divider>
      <v-card-title>About</v-card-title>
      <v-card-text v-html="boardData?.boardAbout"></v-card-text>
    </v-card-text>
  </v-card>
  <v-card class="w-100 my-5" id="buyProduct">
    <v-list density="compact">
      <v-list-subheader>立即購買</v-list-subheader>

      <v-list-item
        v-for="(item, i) in productData"
        :key="i"
        :value="item.value"
        :text="item"
        color="primary"
        @click="openProductLink(item.value)"
      >
        <template v-slot:prepend>
          <v-icon icon="mdi-flag"></v-icon>
        </template>

        <v-list-item-title v-text="item.text"></v-list-item-title>
      </v-list-item>
      <v-list-subheader>本版版主</v-list-subheader>
    </v-list>
    <v-list
      item-props
      v-if="modsList.length > 0"
      :items="modsList"
      @click:select="openLink"
      density="compact"
    >
    </v-list>
  </v-card>
</template>
<script setup lang="ts">
import { ref, reactive, onMounted, watch, computed } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useStore } from "vuex";
import {
  formatDistanceToNow,
  addDays,
  addHours,
  addSeconds,
  formatDistanceStrict,
} from "date-fns";
import { zhTW } from "date-fns/locale";

interface BoardData {
  id: number;
  name: string;
  boardAbout: string;
  boardHeaderCoverImgUrl: string;
  isFollowed: boolean;
  isFavorite: boolean;
  isMod: boolean;
  isBucket: boolean;
  bucketEndTime: Date;
  memberFollowCount: number;
  postTotalCount: number;
  productLinks: object[];
}

const boardData = ref<BoardData>();
const iconUrl = ref("");
const productData = ref<any>([]);
const modsList = ref<any>([]);
const props = defineProps({
  boardId: {
    type: String,
    required: true,
  },
});
const store = useStore();
const incrememtCount = () => {
  store.commit("boardListRefresh");
};
const getBoardData = async () => {
  const res = await axios
    .get(`https://localhost:7081/api/Boards/${props.boardId}`, {
      withCredentials: true,
    })
    .then((res) => {
      boardData.value = res.data;
      iconUrl.value =
        boardData.value?.boardHeaderCoverImgUrl ??
        "https://pbs.twimg.com/media/F32EcZxbYAI5Oml.jpg";
      productData.value = boardData.value?.productLinks.map((item) => {
        return {
          value: item.id,
          text: item.platformName,
        };
      });
      modsList.value = boardData.value?.mods.map((item) => {
        return {
          value: item.account,
          title: item.name,
          subtitle: item.account,
          prependAvatar: item.iconUrl,
        };
      });
    })
    .catch((err) => {
      console.log(err.data);
    });
};
const followAction = async () => {
  const res = await axios
    .put(
      `https://localhost:7081/api/MembersBoards/${props.boardId}/Follow`,
      {},
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      getBoardData();
      incrememtCount();
    })
    .catch((err) => {
      console.log(err);
    });
};

const favoriteAction = async () => {
  const res = await axios
    .put(
      `https://localhost:7081/api/MembersBoards/${props.boardId}/Favorite`,
      {},
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      getBoardData();
      incrememtCount();
    })
    .catch((err) => {
      console.log(err);
    });
};
const openLink = (e) => {
  router.push({
    name: "GameLoungeAccount",
    params: { account: e.id },
  });
};
//set refresh
const count = computed(() => store.state.GameLoungeStore.aboutRefreshCount);

watch(count, (newValue, oldValue) => {
  getBoardData();
});

//set link
const router = useRouter();
const openProductLink = (id) => {
  console.log(id);
  router.push({
    name: "SingleProduct",
    params: { productId: id },
  });
};
const openAccountLink = (account) => {
  router.push({
    name: "GameLoungeAccount",
    params: { account: account },
  });
};

const countDownTime = (endTimeString) => {
  const endTime = new Date(endTimeString);
  const currentTime = new Date();

  if (endTime > currentTime) {
    const timeRemaining = endTime - currentTime;
    const days = Math.floor(timeRemaining / (1000 * 60 * 60 * 24));
    const hours = Math.floor(
      (timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
    );
    const minutes = Math.floor(
      (timeRemaining % (1000 * 60 * 60)) / (1000 * 60)
    );
    const seconds = Math.floor((timeRemaining % (1000 * 60)) / 1000);

    return ` ${days} 天 ${hours} 小時 ${minutes} 分鐘 ${seconds} 秒`;
  } else {
    return "已過期";
  }
};

const countDownTimeComputed = ref("");
const updateCountDownTime = () => {
  countDownTimeComputed.value = countDownTime(boardData.value.bucketEndTime);
};

onMounted(() => {
  getBoardData();
  const timer = setInterval(updateCountDownTime, 1000); // 啟動計時器，每秒更新倒數時間
  return () => clearInterval(timer);
});
</script>
<style scoped>
.v-card {
  background-color: transparent !important;
  box-shadow: 0px 0px 10px 2px #a1dfe9 !important;
}

.v-list {
  background-color: transparent !important;
}
.v-list-item:hover {
  background-color: #f9ee08;
  color: #01010f;
}
</style>
