<template>
  <v-app>
    <default-bar></default-bar>
    <default-view class="mt64"></default-view>
  </v-app>
</template>

<script setup>
import DefaultBar from "./AppBar.vue";
import DefaultView from "./View.vue";
</script>

<style>
.mt64 {
  margin-top: 64px;
}
</style>
