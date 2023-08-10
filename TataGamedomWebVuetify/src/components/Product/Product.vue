<template>
  <div>
    <SingleProductCarousel :productData="product"></SingleProductCarousel>
    <v-container>
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

            <v-col>
              <v-sheet rounded="lg">
                <ProductDetail
                  v-if="product !== undefined"
                  :productData="product"
                  class="justify-center"
                ></ProductDetail>
              </v-sheet>
            </v-col>
          </v-row>
        </v-container>
      </v-main>
    </v-container>
  </div>
</template>
          
<script setup>
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";
import SingleProductCarousel from "../Product/SingleProductCarousel.vue";
import ProductDetail from "../Product/ProductDetail.vue";
import { defineEmits } from "vue";

const route = useRoute();
const productId = route.params.productId;
const page = ref(1);
const product = ref({});
const totalPages = ref(0);
//const commentsLength = ref();

const loadData = async () => {
  const response = await fetch(
    `https://localhost:7081/api/Products/${productId}?page=${page.value}`
  );
  const datas = await response.json();
  product.value = datas;
  console.log(product.value);
  ///commentsLength.value = datas.gameComments.length;
  totalPages.value = datas.totalPages;
};

onMounted(() => {
  loadData();
});
</script>

          
<style>
.eCommerceContainer {
  width: 100%;
}
</style>