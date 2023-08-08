<template>
  <input
    type="search"
    v-model="keyword"
    @input="inputHandler"
    class="form-control"
    placeholder="請輸入名稱"
  />
</template>
    
<script setup>
import { ref } from "vue";
const keyword = ref("");

//定義父元件傳到子元件的事件名稱
const emit = defineEmits(["searchInput"]);

const inputHandler = () => {
  //引發事件 子將資料傳給父
  emit("searchInput", keyword.value);
};
</script>
    
<style>
</style>