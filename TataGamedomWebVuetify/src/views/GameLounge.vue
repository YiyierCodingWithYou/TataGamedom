<template>
  <div class="m-0 p-0">
    <v-tabs
      v-model="tab"
      color="yellow-darken-3"
      bg-color="black"
      align-tabs="center"
    >
      <v-tab :value="1">🏠</v-tab>
      <v-tab :value="2" v-if="isLogin">🦦</v-tab>
      <v-tab :value="3">🔍</v-tab>
      <transition name="slide-fade">
        <div v-if="tab === 3" class="w-50">
          <v-row>
            <search-bar></search-bar>
          </v-row>
        </div>
      </transition>
    </v-tabs>
    <v-window v-model="tab">
      <v-window-item :value="1">
        <v-container-fluid>
          <GameLoungeHome @goTab3="goTab3"></GameLoungeHome>
        </v-container-fluid>
      </v-window-item>
      <v-window-item :value="2" v-if="isLogin">
        <v-container>
          <v-row>
            <LeftCol>
              <template #container>
                <BoardListPersonal
                  :memberAccount="loginMemberAccount"
                ></BoardListPersonal>
              </template>
            </LeftCol>
            <MainCol>
              <template #container>
                <ReadPostPersonalize
                  :memberAccount="loginMemberAccount"
                ></ReadPostPersonalize>
              </template>
            </MainCol>
            <RightCol>
              <template #container>
                <AboutAccount
                  :memberAccount="loginMemberAccount"
                ></AboutAccount>
              </template>
            </RightCol>
          </v-row>
        </v-container>
      </v-window-item>
      <v-window-item
        v-if="!isSearchBoard && !isSearchAccount"
        :value="3"
        class="bg-black h100vh"
      >
        <GameLoungeSearchPage></GameLoungeSearchPage>
      </v-window-item>
      <v-window-item v-if="isSearchAccount || isSearchBoard" :value="3">
        <v-container>
          <v-row>
            <LeftCol>
              <template #container>
                <BoardListPersonal
                  v-if="isLogin"
                  :memberAccount="loginMemberAccount"
                ></BoardListPersonal>
                <BoardList></BoardList>
              </template>
            </LeftCol>
            <MainCol>
              <template #container>
                <ReadPostTotal
                  v-if="isSearch"
                  :memberAccount="account"
                  :boardId="boardId"
                ></ReadPostTotal>
              </template>
            </MainCol>
            <RightCol>
              <template #container>
                <AboutAccount
                  v-if="isSearchAccount"
                  :memberAccount="account"
                ></AboutAccount>
                <AboutBoard
                  v-if="isSearchBoard && boardId !== undefined"
                  :boardId="boardId"
                ></AboutBoard>
              </template>
            </RightCol>
          </v-row>
        </v-container>
      </v-window-item>
    </v-window>
  </div>
</template>

<script setup>
import { ref, watch, computed } from "vue";
import LeftCol from "@/components/GameLounge/LeftCol.vue";
import RightCol from "@/components/GameLounge/RightCol.vue";
import MainCol from "@/components/GameLounge/MainCol.vue";
import SearchBar from "@/components/GameLounge/SearchBar.vue";
import ReadPostTotal from "@/components/GameLounge/ReadPostTotal.vue";
import ReadPostPersonalize from "@/components/GameLounge/ReadPostPersonalize.vue";
import BoardList from "@/components/GameLounge/LeftBoardList/BoardList.vue";
import BoardListPersonal from "@/components/GameLounge/LeftBoardList/BoardListPersonal.vue";
import AboutAccount from "@/components/GameLounge/RightBoardList/AboutAccount.vue";
import AboutBoard from "@/components/GameLounge/RightBoardList/AboutBoard.vue";
import GameLoungeHome from "@/components/GameLounge/Main/GameLoungeHome.vue";
import GameLoungeSearchPage from "@/components/GameLounge/Main/GameLoungeSearchPage.vue";
import { useRoute } from "vue-router";
import store from "@/store";

const tab = ref(1);
const route = useRoute();
const isSearch = ref(false);
const isSearchAccount = ref(false);
const isSearchBoard = ref(false);
const account = ref("");
const boardId = ref("");
const isLogin = computed(() => store.state.isLoggedIn);
const loginMemberAccount = computed(() => store.state.account);
const keyword = computed(() => store.state.GameLoungeStore.keyword);
const goTab3 = () => {
  console.log("goTab3");
  tab.value = 3;
};

account.value = route.params.account;
boardId.value = route.params.boardId;
if (account.value !== undefined || boardId.value !== undefined) {
  isSearch.value = true;
  tab.value = 3;
}
if (account.value !== undefined) {
  isSearchAccount.value = true;
}
if (boardId.value !== undefined) {
  isSearchBoard.value = true;
}
</script>

<style scoped>
.v-card {
  background-color: transparent !important;
  color: #fff;
}
.v-sheet {
  background-color: #01010f;
  color: #fff;
}
.slide-fade-enter-active {
  transition: opacity 0.5s;
}
.slide-fade-leave-active {
  transition: opacity 0.5s;
}

.slide-fade-enter {
  opacity: 0;
}
.slide-fade-leave-to {
  opacity: 0;
}
.slide-fade-enter-to {
  opacity: 1;
}

.h100vh {
  min-height: calc(100vh - 64px - 48px);
}
</style>
