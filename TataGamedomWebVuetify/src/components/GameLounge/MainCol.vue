<template>
  <v-col cols="12" lg="7" order="3" order-lg="2" class="scroll m-0 p-0">
    <v-sheet min-height="70vh" rounded="lg">
      <v-container>
        <slot name="container"></slot>
      </v-container>
    </v-sheet>
  </v-col>
</template>
<script setup lang="ts">
import { onMounted, ref } from "vue";
import ReadPostTotal from "./ReadPostTotal.vue";
</script>
<style scoped>
.v-sheet {
  background-color: transparent !important;
}

.scroll {
  /* 給一個高度 */
  height: calc(100dvh - 64px - 48px);
  /* 設定滾動 */
  overflow: scroll;
  /* background-color: red; */
}
.scroll::-webkit-scrollbar {
  display: none;
}
</style>
