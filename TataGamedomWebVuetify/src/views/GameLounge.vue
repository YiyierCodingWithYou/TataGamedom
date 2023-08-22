<template>
  <v-tabs v-model="tab" color="yellow-darken-3" align-tabs="center">
    <v-tab :value="1">🏠</v-tab>
    <v-tab :value="2" v-if="isLogin">🦦</v-tab>
    <v-tab :value="3">🔍</v-tab>
    <transition name="slide-fade">
      <t-tab v-if="tab === 3" class="w-50">
        <v-row>
          <search-bar></search-bar>
        </v-row>
      </t-tab>
    </transition>
  </v-tabs>
  <v-window v-model="tab">
    <v-window-item :value="1">
      <v-container>
        <v-row>
          <LeftCol>
            <template #container>
              <BoardList></BoardList>
            </template>
          </LeftCol>
          <MainCol>
            <template #container>
              <ReadPostTotal
                :memberAccount="loginMemberAccount"
              ></ReadPostTotal>
            </template>
          </MainCol>
          <RightCol></RightCol>
        </v-row>
      </v-container>
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
              <AboutAccount :memberAccount="loginMemberAccount"></AboutAccount>
            </template>
          </RightCol>
        </v-row>
      </v-container>
    </v-window-item>
    <v-window-item :value="3">
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
                :memberAccount="memberAccount"
                :boardId="boardId"
                :keyword="keyword"
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

console.log(isLogin.value);
console.log(loginMemberAccount.value);

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

console.log(account.value);
console.log(isSearch.value);
</script>

<style scoped>
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
</style>
