<template>
  <v-app>
    <default-bar></default-bar>
    <default-view></default-view>
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
::-webkit-scrollbar {
  height: 3px;
  width: 7px;
}

::-webkit-scrollbar-thumb {
  background: linear-gradient(#f9ee08 40%, #a1dfe9);
  border-radius: 8px;
}

::-webkit-scrollbar-track {
  background-color: #e5e5e5;
  border-radius: 8px;
}
</style>
