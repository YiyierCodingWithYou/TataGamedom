<template>
  <div>
      <v-list-item
        v-for="product in topFive"
        :key="product.id"
        class="mt-8"
        @click="handleProductClick(product.id)"
      >
      
        <div class="d-flex">
          <v-avatar :image="imgLink + product.gameGameCoverImg" size="x-large" class="ml-5"></v-avatar>
          <div class="d-flex flex-column ml-5 ">
            <div class="justify-center" style="color:#a1dfe9">
              <v-icon start icon="mdi-gamepad-right"></v-icon>
              {{ product.gamePlatformName }}
            </div>
            {{ product.gameChiName }}
          </div>
        </div>
        <v-divider class="border-opacity-50 mt-3" color="#f9ee08"></v-divider>
      </v-list-item>
      
  </div>
</template>
    
<script setup>
import { ref, reactive, onMounted } from "vue";
const topFive = ref([]);
const API = "https://localhost:7081/api/";
const imgLink = "https://localhost:7081/Files/Uploads/";

const loadTopFive = async () => {
  const response = await fetch(`${API}OrderItems/ProductTopFiveSales`);
  const datas = await response.json();
  topFive.value = datas;
};
onMounted(() => {
  loadTopFive();
});

//定義父元件傳到子元件的事件名稱
const emit = defineEmits(["getProductInput"]);

const handleProductClick = (productId) => {
  emit("getProductInput", productId);
};
</script>
    
<style scoped>


</style>