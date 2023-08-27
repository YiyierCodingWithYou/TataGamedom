<template>
  <v-text-field v-model="keyword" @keyup.enter="inputHandler" density="compact" placeholder="請輸入產品名稱" append-inner-icon="mdi-magnify"
  variant="plain">
  </v-text-field>
</template>
    
<script setup>
import { ref } from "vue";
const keyword = ref("");

//定義父元件傳到子元件的事件名稱
const emit = defineEmits(["searchInput"]);

const inputHandler = () => {
  //引發事件 子將資料傳給父
  emit("searchInput", keyword.value);
  keyword.value = "";
};
</script>
    
<style></style>