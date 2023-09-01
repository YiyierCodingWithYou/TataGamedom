<template>
  <v-col cols="12" sm="3" class="scroll m-0 p-0">
    <slot name="container"></slot>
  </v-col>
</template>
<script setup></script>
<style scoped>
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
