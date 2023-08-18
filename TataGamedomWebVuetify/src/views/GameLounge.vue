<template>
  <v-tabs v-model="tab" color="yellow-darken-3" align-tabs="center">
    <v-tab :value="1">🏠</v-tab>
    <v-tab :value="2">🦦</v-tab>
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
    <v-window-item :value="1"> </v-window-item>
    <v-window-item :value="2">
      <v-container>
        <v-row>
          <LeftCol> </LeftCol>
          <MainCol>
            <template #container>
              <ReadPostPersonalize></ReadPostPersonalize>
            </template>
          </MainCol>
          <RightCol></RightCol>
        </v-row>
      </v-container>
    </v-window-item>
    <v-window-item :value="3" v-if="isSearch">
      <v-container>
        <v-row>
          <LeftCol> </LeftCol>
          <MainCol>
            <template #container>
              <ReadPostTotal></ReadPostTotal>
            </template>
          </MainCol>
          <RightCol></RightCol>
        </v-row>
      </v-container>
    </v-window-item>
    <v-window-item :value="3" v-if="!isSearch"> </v-window-item>
  </v-window>
</template>

<script setup>
import { ref } from "vue";
import LeftCol from "@/components/GameLounge/LeftCol.vue";
import RightCol from "@/components/GameLounge/RightCol.vue";
import MainCol from "@/components/GameLounge/MainCol.vue";
import SearchBar from "@/components/GameLounge/SearchBar.vue";
import ReadPostTotal from "@/components/GameLounge/ReadPostTotal.vue";
import ReadPostPersonalize from "@/components/GameLounge/ReadPostPersonalize.vue";
import { useRoute } from "vue-router";

const tab = ref(1);
const route = useRoute();
const isSearch = ref(false);
const account = ref("");
const boardId = ref("");

account.value = route.params.account;
boardId.value = route.params.boardId;
if (account.value !== undefined || boardId.value !== undefined) {
  isSearch.value = true;
  tab.value = 3;
}
console.log(account.value);
console.log(isSearch.value);
</script>

<style scoped>
.slide-fade-enter-active,
.slide-fade-leave-active {
  transition: opacity 0.5s;
}

.slide-fade-enter,
.slide-fade-leave-to {
  opacity: 0;
}

.slide-fade-enter-to {
  opacity: 1;
}
</style>
