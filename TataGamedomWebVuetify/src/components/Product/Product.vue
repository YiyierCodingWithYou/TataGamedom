<template>
  <SingleProductCarousel :productData="product"></SingleProductCarousel>
  <v-main class="bg-grey-lighten-2">
    <v-container>
      <v-row>
        <v-col cols="2">
          <v-sheet rounded="lg">
            <v-list rounded="lg">
              <!-- 放入左側邊攔 -->
            </v-list>
          </v-sheet>
        </v-col>

        <v-col >
          <v-sheet rounded="lg">
            <ProductDetail :productData="product" class="justify-center"></ProductDetail>
          </v-sheet>
        </v-col>
      </v-row>
    </v-container>
  </v-main>
</template>
          
<script setup>
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import SingleProductCarousel from "../Product/SingleProductCarousel.vue";
import ProductDetail from "../Product/ProductDetail.vue";


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

          
<style></style>