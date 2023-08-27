<template>
  <v-app>
    <default-bar></default-bar>
    <default-view style="margin-top: 64px"></default-view>
  </v-app>
</template>

<script setup>
import DefaultBar from "./AppBar.vue";
import DefaultView from "./View.vue";
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=IBM+Plex+Sans+JP:wght@400;500;700&display=swap");
@import url("https://fonts.googleapis.com/css2?family=Silkscreen:wght@400;700&display=swap");

.font-comfortaa {
  font-family: "Silkscreen", cursive;
  font-weight: 700;
}
.font-IBM {
  font-family: "IBM Plex Sans JP", sans-serif;
}
.font-digit {
  font-family: "Digi-font";
}
</style>
