<template>
  <v-app>
    <default-bar ref="barRef"></default-bar>
    <Button-Nav />
    <default-view @login-ok="reload"></default-view>
  </v-app>
</template>

<script setup>
import DefaultBar from "./AppBar.vue";
import DefaultView from "./View.vue";
import ButtonNav from "./ButtonNav.vue";
import { ref } from "vue";

const barRef = ref(null);

const reload = () => {
  console.log("defaultOk");

  if (barRef.value && barRef.value.reload2) {
    console.log("gooooo"); // 注意修正這裡，應該是 console.log 而不是 console
  }
};
</script>
