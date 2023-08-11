<template>
  <v-main>
    <router-view :key="$route.fullPath" @login-ok="loginOk" />
  </v-main>
</template>

<script setup>
import { defineEmits } from "vue";
const emit = defineEmits(["loginOk"]);

const loginOk = () => {
  console.log("viewOk");
  emit("loginOk");
};
</script>
