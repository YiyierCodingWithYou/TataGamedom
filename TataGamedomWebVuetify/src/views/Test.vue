<template lang="">
  <!-- <BoardList></BoardList> -->
  <!-- <BoardListPersonal></BoardListPersonal> -->
  <!-- <AboutAccount></AboutAccount> -->
  <!-- <AboutBoard></AboutBoard> -->
  <GameLoungeHome></GameLoungeHome>
</template>
<script setup lang="ts">
import { ref } from "vue";
import BoardList from "@/components/GameLounge/LeftBoardList/BoardList.vue";
import BoardListPersonal from "@/components/GameLounge/LeftBoardList/BoardListPersonal.vue";
import AboutAccount from "@/components/GameLounge/RightBoardList/AboutAccount.vue";
import AboutBoard from "@/components/GameLounge/RightBoardList/AboutBoard.vue";
import GameLoungeHome from "@/components/GameLounge/Main/GameLoungeHome.vue";
</script>

<style></style>
