<template lang="">
  <!-- <BoardList></BoardList> -->
  <!-- <BoardListPersonal></BoardListPersonal> -->
  <!-- <AboutAccount></AboutAccount> -->
  <!-- <AboutBoard></AboutBoard> -->
  <!-- <GameLoungeHome></GameLoungeHome> -->
  <!-- <FollowList :data="followData">
    <template #title> 追蹤者 </template>
    <template #clickBtn>
      <v-btn variant="text"> Open Dialog </v-btn>
    </template>
  </FollowList>
  <FollowList :data="followData">
    <template #title> 追蹤中 </template>
    <template #clickBtn>
      <v-btn variant="text"> 你好啦 </v-btn>
    </template>
  </FollowList> -->

  <Notification />
</template>
<script setup lang="ts">
import { ref } from "vue";
import BoardList from "@/components/GameLounge/LeftBoardList/BoardList.vue";
import BoardListPersonal from "@/components/GameLounge/LeftBoardList/BoardListPersonal.vue";
import AboutAccount from "@/components/GameLounge/RightBoardList/AboutAccount.vue";
import AboutBoard from "@/components/GameLounge/RightBoardList/AboutBoard.vue";
import GameLoungeHome from "@/components/GameLounge/Main/GameLoungeHome.vue";
import FollowList from "@/components/GameLounge/RightBoardList/FollowList.vue";
import Notification from "@/components/GameLounge/Infra/Notification.vue";

// const followData = ref([{}]);

// followData.value = [
//   {
//     title: "李四",
//     value: "lisi",
//     prependAvatar: "https://cdn.vuetifyjs.com/images/john.png",
//   },
//   {
//     title: "Item #2",
//     value: 2,
//   },
//   {
//     title: "Item #3",
//     value: 3,
//   },
// ];
</script>

<style></style>
