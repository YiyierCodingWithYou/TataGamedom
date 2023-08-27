<template>
  <div class="ml-2 mb-3 font-color" >🦦 關鍵字搜尋</div>
  <v-divider class="border-opacity-100" color="#a1dfe9"></v-divider>

  <SearchTextBox @searchInput="value => forwardEvent('searchInput', value)" class="mb-10"></SearchTextBox>

  <div class="ml-2 mb-3 font-color">🦦 依遊戲分類瀏覽</div>
  <v-divider class="border-opacity-100" color="#a1dfe9"></v-divider>
  <ClassificationList @classificationInput="value => forwardEvent('classificationInput', value)" class="mb-10">
  </ClassificationList>

  <div class="ml-2 mb-3 font-color">🦦 熱賣遊戲TOP 5</div>
  <v-divider class="border-opacity-100" color="#a1dfe9"></v-divider>
  <div>
    <TopFiveProduct class="mb-10" @getProductInput="value => forwardEvent('getProductInput', value)"></TopFiveProduct>
  </div>
</template>

<script setup>
import SearchTextBox from "@/components/eCommerce/SearchTextBox.vue";
import ClassificationList from "@/components/eCommerce/ClassificationList.vue";
import TopFiveProduct from "@/components/eCommerce/TopFiveProduct.vue";

const emit = defineEmits(["searchInput", "classificationInput", "getProductInput"]);

const forwardEvent = (eventName, value) => {
  emit(eventName, value);
};

</script>

<style>
.font-color{
  color:#a1dfe9 !important;
}
</style>