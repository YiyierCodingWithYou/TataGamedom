<template>
  <div>🎮 關鍵字搜尋</div>
  <hr />
  <SearchTextBox @searchInput="value => forwardEvent('searchInput', value)" class="mb-10"></SearchTextBox>
  <div>🎮 依遊戲分類瀏覽</div>
  <hr />
  <ClassificationList @classificationInput="value => forwardEvent('classificationInput', value)" class="mb-10"></ClassificationList>
  <div>🎮 熱賣遊戲TOP 5</div>
  <hr />
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

<style></style>