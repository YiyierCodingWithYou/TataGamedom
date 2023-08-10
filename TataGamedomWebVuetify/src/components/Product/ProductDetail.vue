<template>
  <v-row>
    <div class="d-flex flex-no-wrap">
      <div class="ma-3">
        <v-img
          :src="imgLink + productData.gameCoverImg"
          width="450"
          cover
        ></v-img>
      </div>
      <div class="d-flex flex-column mt-3">
        <v-card-title class="text-h5">
          {{ productData.chiName }}
        </v-card-title>
        <div class="d-flex text-h3">
          <v-card-subtitle
            class="me-auto"
            v-for="item in productData.coupons"
            :key="item"
          >
            {{ item }}
          </v-card-subtitle>
          <v-card-subtitle
            v-for="item in productData.couponDescription"
            :key="item"
          >
            {{ item }}
          </v-card-subtitle>
        </div>
        <v-card-subtitle v-if="productData.specialPrice === productData.price"
          >${{ productData.price }}</v-card-subtitle
        >
        <v-card-subtitle v-else
          ><s>${{ productData.price }}</s
          >${{ productData.specialPrice }}</v-card-subtitle
        >
        <div class="d-flex">
          <v-rating
            v-model="productData.score"
            class="ma-2 d-flex me-auto"
            density="compact"
            readonly
          ></v-rating
          >｜
          <v-card-subtitle>{{ commentCount }}個評論</v-card-subtitle>
        </div>
        <div>
          <v-row>
            <v-col cols="4">
              <v-btn
                icon
                @click="decreaseQuantity"
                :max="limit"
                v-model="quantity"
              >
                <v-icon>mdi-minus</v-icon>
              </v-btn>
            </v-col>
            <v-col cols="4">
              <v-text-field
                v-model="quantity"
                min="1"
                :max="limit"
                outlined
              ></v-text-field>
            </v-col>
            <v-col cols="4">
              <v-btn icon @click="increaseQuantity" v-model="quantity">
                <v-icon>mdi-plus</v-icon>
              </v-btn>
            </v-col>
          </v-row>
        </div>
        <v-btn class="mt-auto ma-3">加入購物車</v-btn>
      </div>
    </div>
  </v-row>
</template>
    
<script setup>
import { ref, onMounted, defineProps, watch } from "vue";

const props = defineProps({ productData: Object, commentCount: Number });
const quantity = ref(1);
const limit = ref(null);
const imgLink = "https://localhost:7081/Files/Uploads/";
console.log(props.productData.id);

const fetchQuantityLimit = async () => {
  const response = await fetch(
    `https://localhost:7081/api/InventoryItems/RemainingQuantity/${props.productData.id}`
  );
  const datas = await response.json();
  limit.value = datas; // Update the limit value
  console.log(datas);
};

onMounted(() => {
  fetchQuantityLimit();
});

watch(quantity, () => {
  fetchQuantityLimit();
});

const increaseQuantity = () => {
  if (quantity.value < limit.value) {
    quantity.value++;
  }
};

const decreaseQuantity = () => {
  if (quantity.value > 1) {
    quantity.value--;
  }
};
</script>
    
<style></style>