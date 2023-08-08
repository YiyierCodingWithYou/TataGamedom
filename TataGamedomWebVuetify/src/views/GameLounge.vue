<template>
  <v-app id="inspire">
    <v-app-bar class="px-3" color="amber-lighten-5" flat density="comfortable">
      <v-tabs centered color="blue-grey-darken-3">
        <v-tab v-for="link in links" :key="link">
          {{ link }}
        </v-tab>
      </v-tabs>
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-main class="bg-grey-lighten-3">
      <v-container>
        <v-row>
          <LeftCol></LeftCol>
          <MainCol></MainCol>
          <RightCol></RightCol>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<style scoped></style>

<script setup>
import LeftCol from "@/components/GameLounge/LeftCol.vue";
import RightCol from "@/components/GameLounge/RightCol.vue";
import MainCol from "@/components/GameLounge/MainCol.vue";
const links = ["大廳首頁", "我的追蹤", "獺獺檔案"];
</script>
