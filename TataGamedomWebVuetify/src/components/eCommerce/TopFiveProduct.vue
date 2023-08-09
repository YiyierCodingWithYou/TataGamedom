<template>
  <div>
    <ul>
      <li v-for="product in topFive" :key="product.id" class="mt-8">
        <div class="d-flex">
          <img :src="imgLink + product.gameGameCoverImg" width="150" cover />
          <div class="d-flex flex-column">
            <v-chip class="ma-2 w100 justify-center" color="primary">
              {{ product.gamePlatformName }}
            </v-chip>
            {{ product.gameChiName }}
          </div>
        </div>
      </li>
    </ul>
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
</script>
    
<style>
.w100 {
  width: 50px;
  text-align: center;
}
</style>