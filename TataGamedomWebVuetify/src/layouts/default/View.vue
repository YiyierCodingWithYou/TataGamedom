<template>
  <v-main>
    <router-view :key="$route.fullPath" />
  </v-main>
</template>

<script setup></script>
<style>
.v-main {
  background-color: #01010f;
  color: #f9ee08;
}
</style>
