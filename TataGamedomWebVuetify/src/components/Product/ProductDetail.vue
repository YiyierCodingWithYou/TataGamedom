<template>
  <div>
    <v-row>
      <div class="d-flex flex-no-wrap">
        <div class="ma-3">
          <v-img :src="imgLink + productData.gameCoverImg" width="450" cover></v-img>
        </div>
        <div class="d-flex flex-column mt-3">
          <v-card-title class="text-h5">
            {{ productData.chiName }}
          </v-card-title>
          <div class="d-flex text-h3">
            <v-card-subtitle class="me-auto" v-for="item in productData.coupons" :key="item">
              {{ item }}
            </v-card-subtitle>
            <v-card-subtitle v-for="item in productData.couponDescription" :key="item">
              {{ item }}
            </v-card-subtitle>
          </div>
          <v-card-subtitle v-if="productData.specialPrice === productData.price">${{ productData.price
          }}</v-card-subtitle>
          <v-card-subtitle v-else><s>${{ productData.price }}</s>${{ productData.specialPrice }}</v-card-subtitle>
          <div class="d-flex">
            <v-rating v-model="productData.score" class="ma-2 d-flex me-auto" density="compact" readonly></v-rating>｜
            <v-card-subtitle>{{ productData.commentCount }}個評論</v-card-subtitle>
          </div>
          <div>
            <v-row>
              <v-col cols="4">
                <v-btn icon @click="decreaseQuantity" :max="limit" v-model="quantity">
                  <v-icon>mdi-minus</v-icon>
                </v-btn>
              </v-col>
              <v-col cols="4">
                <v-text-field v-model="quantity" min="1" :max="limit" outlined readonly></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-btn icon @click="increaseQuantity" v-model="quantity">
                  <v-icon>mdi-plus</v-icon>
                </v-btn>
              </v-col>
            </v-row>
          </div>
          <v-btn v-if="limit > 0" class="mt-auto ma-3" @click="Add2Cart(productData.id)">加入購物車</v-btn>
          <v-btn v-else-if="limit === 0" class="mt-auto ma-3" disabled>售完</v-btn>
          <p v-if="limit > 0 && limit <= 10" class="text-center">現庫存剩餘{{ limit }}件</p>
          <p v-else-if="limit === 0" class="text-center">無庫存</p>
        </div>
      </div>
    </v-row>
    <div>
      <h3>🕹 遊戲簡介</h3>
      <p>{{ productData.description }}</p>
    </div>
    <div>
      <h3>🕹 系統需求</h3>
      <p>{{ productData.systemRequire }}</p>
    </div>
    <div class="d-flex">
      <div v-for="item in productData.classification">
        <v-chip>#{{ item }}</v-chip>
      </div>
      
    </div>
  </div>
</template>
    
<script setup>
import { ref, onMounted, defineProps, watch } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const props = defineProps({ productData: Object });
const quantity = ref(1);
const limit = ref(null);
const imgLink = "https://localhost:7081/Files/Uploads/";

watch(props, (newProps) => {
  if (newProps.productData.id) {
    fetchQuantityLimit();
  }
});

const fetchQuantityLimit = async () => {
  const response = await fetch(
    `https://localhost:7081/api/InventoryItems/RemainingQuantity/${props.productData.id}`
  );
  const datas = await response.json();
  limit.value = datas; // Update the limit value
  console.log(props.productData.id);
  console.log(limit.value);
};

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

const Add2Cart = async (productId) => {
  const response = await fetch(`https://localhost:7081/api/Carts`, {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      productId: productId,
      qty: quantity.value,
    }),
  });
  let result = await response.json();
  if (result.isFail) {
    alert(result.message);
    router.push({
      name: "Login"
    });
  }
  alert(result.message);
};
</script>
    
<style></style>