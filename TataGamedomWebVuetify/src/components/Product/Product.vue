<template>
  <h2>{{ product.chiName }}</h2>
  <SingleProductCarousel :productData="product"></SingleProductCarousel>
</template>
          
<script setup>
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import SingleProductCarousel from "../Product/SingleProductCarousel.vue";

const route = useRoute();
const productId = route.params.productId;
const page = ref(1);
const product = ref({});
const totalPages = ref(0);
const imageLength = ref(0);

const loadData = async () => {
  const response = await fetch(
    `https://localhost:7081/api/Products/${productId}?page=${page.value}`
  );
  const datas = await response.json();
  product.value = datas;
  console.log(product.value);
  totalPages.value = datas.totalPages;
};

onMounted(() => {
  loadData();
});
</script>

          
<style>
</style>