<template>
  <v-card class="w-100 my-5">
    <v-img cover max-height="250" :src="iconUrl"></v-img>
    <v-card-item>
      <v-card-title>{{ boardData?.name }}</v-card-title>
    </v-card-item>
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
</template>
<script setup lang="ts">
import { ref, reactive, onMounted, defineProps } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useStore } from "vuex";

interface BoardData {
  id: number;
  name: string;
  boardAbout: string;
  boardHeaderCoverImgUrl: string;
  isFollowed: boolean;
  isFavorite: boolean;
  isMod: boolean;
  memberFollowCount: number;
  postTotalCount: number;
  productLinks: object[];
}

const boardData = ref<BoardData>();
const iconUrl = ref("");

const props = defineProps({
  boardId: {
    type: String,
    required: true,
  },
});

const store = useStore();
const incrememtCount = () => {
  store.commit("increment");
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

onMounted(() => {
  getBoardData();
});
</script>
<style lang=""></style>
