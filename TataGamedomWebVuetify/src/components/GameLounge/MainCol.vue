<template>
  <v-col cols="12" sm="8">
    <v-sheet min-height="70vh" rounded="lg">
      <v-container>
        <ReadPostTotal></ReadPostTotal>
      </v-container>
    </v-sheet>
  </v-col>
</template>
<script setup lang="ts">
import { onMounted, ref } from "vue";
import ReadPostTotal from "./ReadPostTotal.vue";
</script>
<style scoped></style>
