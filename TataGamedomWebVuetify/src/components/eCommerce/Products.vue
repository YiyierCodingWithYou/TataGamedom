<template>
  <div>
    <carousel></carousel>
  </div>
  <!-- 之後把左側欄切出去 -->
  <div class="container mt-10">
    <v-row class="row">
      <v-col cols="2">
        <div>🎮 關鍵字搜尋</div>
        <hr />
        <SearchTextBox
          @searchInput="inputHandler"
          class="mb-10"
        ></SearchTextBox>
        <div>🎮 依遊戲分類瀏覽</div>
        <hr />
        <ClassificationList
          @classificationInput="classificationHandler"
          class="mb-10"
        ></ClassificationList>
        <div>🎮 熱賣遊戲TOP 5</div>
        <hr />
        <div>
          <TopFiveProduct
            class="mb-10"
            @getProductInput="GetSingleProduct"
          ></TopFiveProduct>
        </div>
      </v-col>
      <v-col cols="10">
        <div class="d-flex">
          <v-col cols="4" class="me-auto">
            <v-btn-toggle
              v-model="inputPlatform"
              rounded="0"
              color="#ffbf5d"
              group
              @update:model-value="sortPlatform"
            >
              <v-btn value=""> 所有遊戲 </v-btn>

              <v-btn value="PC"> PC </v-btn>

              <v-btn value="PS4"> PS4 </v-btn>

              <v-btn value="Switch"> Switch </v-btn>
            </v-btn-toggle>
          </v-col>
          <v-col cols="4">
            <v-select
              v-model="select"
              :items="items"
              item-title="label"
              item-value="item"
              persistent-hint
              return-object
              single-line
              @update:model-value="sortItems"
            >
            </v-select>
          </v-col>
        </div>
        <v-row>
          <v-col cols="4" v-for="product in products" :key="product.id">
            <v-card height="550">
              <v-img
                class="align-end text-white"
                height="350"
                :src="img + product.gameCoverImg"
                cover
                @click="GetSingleProduct(product.id)"
              ></v-img>
              <div class="d-flex justify-center">
                <v-chip
                  class="mt-3 d-flex justify-center"
                  color="primary"
                  label
                  text-color="white"
                >
                  <v-icon start icon="mdi-label"></v-icon>
                  {{ product.gamePlatformName }}
                </v-chip>
                <v-card-title
                  class="mt-1 justify-center text-center"
                  @click="GetSingleProduct(product.id)"
                >
                  {{ product.chiName }}
                </v-card-title>
              </div>
              <v-card-text class="d-flex justify-center">
                <div v-if="product.price != product.specialPrice">
                  <span
                    ><s>${{ product.price }}</s
                    >　</span
                  >
                  <span>${{ product.specialPrice }}</span>
                </div>
                <div v-else>
                  <div>${{ product.price }}</div>
                </div>
              </v-card-text>

              <v-rating
                v-model="product.score"
                class="ma-2 d-flex justify-center"
                density="compact"
                half-increments
                readonly
              ></v-rating>

              <v-card-actions class="justify-center">
                <v-btn color="orange" @click="Add2Cart(product.id)"
                  >加入購物車</v-btn
                >
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </div>
  <div class="text-center">
    <v-pagination
      v-model="thePage"
      :length="totalPages"
      :total-visible="5"
      @update:model-value="clickHandler"
    ></v-pagination>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from "vue";
import SearchTextBox from "../eCommerce/SearchTextBox.vue";
import ClassificationList from "../eCommerce/ClassificationList.vue";
import Carousel from "../eCommerce/Carousel.vue";
import TopFiveProduct from "../eCommerce/TopFiveProduct.vue";
import { useRoute, useRouter } from "vue-router";

const router = useRouter();
const route = useRoute();
const keyword = ref("");
const classification = ref("");
const sortBy = ref("");
const isAscending = ref("");
const platform = ref("");
const products = ref([]);
const totalPages = ref();
const thePage = ref(1);
let img = "https://localhost:7081/Files/Uploads/";

// if (route.params.classification) {
//   classification = route.params.classification;
//   // 在这里进行你的操作
// } else {
//   classification = "";
// }
const select = ref({
  sort: "",
  ascending: "",
  label: "請選擇排序方式",
});
const items = ref([
  { sort: "", ascending: "", label: "預設" },
  { sort: "SaleDate", ascending: "true", label: "依日期排序：由舊到新" },
  { sort: "SaleDate", ascending: "false", label: "依日期排序：由新到舊" },
  { sort: "Price", ascending: "true", label: "依售價排序：由低到高" },
  { sort: "Price", ascending: "false", label: "依售價排序：由高到低" },
]);

const inputPlatform = ref("");
const API = "https://localhost:7081/api/";

const loadProducts = async () => {
  const response = await fetch(
    `${API}Products?keyword=${keyword.value}&platform=${platform.value}&classification=${classification.value}&sortBy=${sortBy.value}&isAscending=${isAscending.value}&page=${thePage.value}`,
    {
      method: "GET",
    }
  );
  const datas = await response.json();
  products.value = datas.products;
  totalPages.value = datas.totalPages;
};

//排序
const sortItems = () => {
  sortBy.value = select.value.sort;
  isAscending.value = select.value.ascending;
  loadProducts();
};

//平台
const sortPlatform = () => {
  if (inputPlatform.value != undefined) {
    platform.value = inputPlatform.value;
  }
  loadProducts();
};

//搜尋
const inputHandler = (value) => {
  keyword.value = value;
  loadProducts();
};

//遊戲分類
const classificationHandler = (value) => {
  if (value === "所有遊戲") {
    classification.value = "";
  } else {
    classification.value = value;
  }
  loadProducts();
};

//分頁
const clickHandler = (nextPage) => {
  thePage.value = nextPage;
  loadProducts();

  window.scrollTo({
    top: 500,
    behavior: "smooth",
  });
};

//加入購物車
const Add2Cart = async (productId) => {
  const response = await fetch(`${API}Carts`, {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      productId: productId,
      qty: 1,
    }),
  });
  let result = await response.json();
  if (result.isFail) {
    router.push({
      name: "Login",
    });
  }
  alert(result.message);
};

onMounted(() => {
  loadProducts();
});

//跳轉到商品頁面
const GetSingleProduct = async (productId) => {
  router.push({
    name: "SingleProduct",
    params: { productId: productId },
  });
};
</script>

<style>
</style>