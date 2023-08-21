<template>
  <v-app>
    <default-bar ref="barRef"></default-bar>
    <Button-Nav />
    <default-view style="margin-top: 64px"></default-view>
  </v-app>
</template>

<script setup>
import DefaultBar from "./AppBar.vue";
import DefaultView from "./View.vue";
</script>
