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
import { ref } from "vue";

const barRef = ref(null);

const reload = () => {
  console.log("defaultOk");
};
</script>

