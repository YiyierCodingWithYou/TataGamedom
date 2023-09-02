<template>
  <v-col cols="12" order="1" order-lg="3" lg="3" class="scroll m-0 p-0">
    <v-container>
      <slot name="container"></slot>
    </v-container>
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

@media (max-width: 1024px) {
  .scroll {
    height: calc(80dvh - 64px - 48px);
  }
}
</style>
