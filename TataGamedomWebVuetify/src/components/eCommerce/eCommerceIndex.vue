<template>
  <div class="shopContainer">
    <div>
      <carousel ref="bookmark" @getProductInput="GetSingleProduct"></carousel>
      <div class="myDraw">
        <CartDrawer v-model="drawer" ref="drawerComponent"></CartDrawer>
      </div>
    </div>
    <v-container>
      <div class="mt-10">
        <v-row class="row">
          <v-col cols="3">
            <SideBar @searchInput="inputHandler" @classificationInput="classificationHandler"
              @getProductInput="GetSingleProduct"></SideBar>
          </v-col>
          <v-col cols="9">
            <Typed :options="option2">
              <p class="typing ml-3" style="display:inline-block;"></p>
            </Typed>
            <div class="d-flex">
              <v-col cols="6" class="me-auto">
                <v-btn-toggle v-model="inputPlatform" rounded="0.5" group
                  style="border:2px solid #fbf402; color:#fbf402 !important;" @update:model-value="sortPlatform"
                  color="#fbf402">
                  <v-btn :class="{ 'myBtn': true, 'selectedBtn': inputPlatform === '' }" value="" rounded="0"> 所有遊戲
                  </v-btn>
                  <v-btn :class="{ 'myBtn': true, 'selectedBtn': inputPlatform === 'PC' }" value="PC"> PC </v-btn>
                  <v-btn :class="{ 'myBtn': true, 'selectedBtn': inputPlatform === 'PS4' }" value="PS4"> PS4 </v-btn>
                  <v-btn :class="{ 'myBtn': true, 'selectedBtn': inputPlatform === 'Switch' }" value="Switch" rounded="0">
                    Switch
                  </v-btn>
                </v-btn-toggle>
              </v-col>
              <v-col cols="4">
                <v-select v-model="select" :items="items" item-title="label" item-value="item" item-color="#f9ee08"
                  bg-color="#01010f" persistent-hint return-object single-line @update:model-value="sortItems"
                  theme="dark">
                </v-select>
              </v-col>
            </div>

            <v-row>
              <v-col cols="4" v-for="product in products" :key="product.id">
                <v-card height="410" class="myCard ma-1" density="compact">
                  <v-img class="align-end text-white pointer" height="200" :src="img + product.gameCoverImg" cover
                    @click="GetSingleProduct(product.id)"></v-img>
                  <v-divider class="border-opacity-100" color="#a1dfe9"></v-divider>
                  <div class="d-flex justify-center align-center mt-2">
                    <v-chip class="mt-1 mr-1 d-flex justify-center" style="background-color:transparent; font-size: 12px;"
                      label>
                      <v-icon start icon="mdi-gamepad-right "></v-icon>
                      {{ product.gamePlatformName }}
                    </v-chip>
                    <div class="mt-1 justify-center text-center pointer" @click="GetSingleProduct(product.id)"
                      style="color:white">
                      {{ product.chiName }}<span v-if="product.isVirtual"><v-icon size="x-small" color="#fbf402"
                          icon="mdi-information" class="ml-1"></v-icon></span>
                    </div>
                  </div>
                  <v-card-text class="d-flex justify-center">
                    <div v-if="product.price != product.specialPrice">
                      <span style="color:grey; font-size: 16px;"><s>{{ unitExchange(product.price) }}</s>　</span>
                      <span style="font-size: 20px; color:white">{{ unitExchange(product.specialPrice) }}</span>
                    </div>
                    <div v-else>
                      <div style="font-size: 20px; color:white">{{ unitExchange(product.price) }}</div>
                    </div>
                  </v-card-text>

                  <v-rating v-model="product.score" class="d-flex justify-center" density="compact" half-increments
                    readonly size="small"></v-rating>

                  <v-card-actions class="justify-center">
                    <v-btn @click.stop="Add2Cart(product.id)" class="mt-3 add2cart" size="large">加入購物車</v-btn>
                  </v-card-actions>
                </v-card>
              </v-col>
            </v-row>

            <div class="text-center">
              <v-pagination v-model="thePage" :length="totalPages" :total-visible="5"
                @update:model-value="clickHandler"></v-pagination>
            </div>
          </v-col>
        </v-row>
      </div>
    </v-container>
  </div>
</template>
  
<script setup lang="ts">
import { ref, reactive, onMounted, watchEffect } from "vue";
import Carousel from "@/components/eCommerce/Carousel.vue";
import SideBar from "@/components/eCommerce/SideBar.vue";
import { useRoute, useRouter } from "vue-router";
import CartDrawer from "@/components/eCommerce/CartDrawer.vue";
import store from "@/store";
import { Typed } from "@duskmoon/vue3-typed-js";
import type { TypedOptions } from "@duskmoon/vue3-typed-js";

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
const bookmark = ref(null);
const cart = ref([]);
const drawer = ref(false);
let img = "https://localhost:7081/Files/Uploads/";
const drawerComponent = ref(null)

const select = ref({
  sort: "",
  ascending: "",
  label: "請選擇排序方式",
});
const items = ref([
  { sort: "", ascending: "", label: "預設" },
  { sort: "Price", ascending: "true", label: "依售價排序：由低到高" },
  { sort: "Price", ascending: "false", label: "依售價排序：由高到低" },
  { sort: "Score", ascending: "true", label: "依評分排序：由低到高" },
  { sort: "Score", ascending: "false", label: "依評分排序：由高到低" },
  { sort: "SaleDate", ascending: "true", label: "依日期排序：由舊到新" },
  { sort: "SaleDate", ascending: "false", label: "依日期排序：由新到舊" },
]);

const inputPlatform = ref("");
const API = "https://localhost:7081/api/";

const unitExchange = (x) => {
  return 'NT$ ' + x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

const option2: TypedOptions = {
  strings: [
    "🎉夏季特賣指定商品95折！",
    "🎉全館滿2000免運！",
    "🎉全館滿3000折300！",
  ],
  loop: true,
  typeSpeed: 100,
  smartBackspace: false,
};

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

const once = (func) => {
  let executed = false;
  return function (...args) {
    if (!executed) {
      executed = true;
      return func.apply(this, args);
    }
  };
};

//處理單筆商品頁傳來的參數
const searchOnce = once(function () {
  if (typeof route.query.classificationChosen !== "undefined") {
    if (route.query.classificationChosen === '所有遊戲') {
      classification.value = "";
    } else {
      classification.value = route.query.classificationChosen;
    }
  }
  if (typeof route.query.keywordInput !== "undefined") {
    keyword.value = route.query.keywordInput;
  }
});

watchEffect(() => {
  searchOnce();
});

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
  if (store.state.isLoggedIn) {
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
    autoToggleDrawer();
  } else {
    let localCart = localStorage.getItem("localCart");
    if (localCart) {
      localCart = JSON.parse(localCart);
    } else {
      localCart = [];
    }
    const existingProduct = localCart.find(
      (item) => item.productId === productId
    );
    if (existingProduct) {
      existingProduct.qty += 1;
    } else {
      localCart.push({ productId, qty: 1 });
    }
    localStorage.setItem("localCart", JSON.stringify(localCart));
  }
  autoToggleDrawer();
};

const autoToggleDrawer = () => {
  openDrawerFromParent();
  setTimeout(() => {
    closeDrawer();
  }, 1000);
};

const openDrawerFromParent = () => {
  drawerComponent.value.drawerContent();
  drawer.value = true;
};

const closeDrawer = () => {
  drawer.value = false;
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
  
<style scoped>
.v-container {
  max-width: 90%;
}

.shopContainer {
  background-color: #01010f;
  color: #f9ee08;
}

.myBtn {
  background-color: #01010f;
  color: #f9ee08;
}

.selectedBtn {
  background-color: #fbf402;
  color: #01010f !important;
}

.myCard {
  background-color: #01010f;
  color: #fbf402;
  box-shadow: 2px 2px 10px #a1dfe9;
  border-radius: 2%;
  border: 2px inset #a1dfe9;
  font-size: 18px
}

.myCard:hover {
  transform: scale(1.05);
  transition: all 0.2s ease-in-out;
}

.add2cart {
  font-size: 18px;
  border: 1px solid #a1dfe9;
  color: #a1dfe9;
}

.add2cart:hover {
  background-color: #a1dfe9;
  color: #01010f;
  box-shadow: 2px 2px 10px #a1dfe9;
}

.v-img {
  border: #a1dfe9 !important;
}

.myDraw {
  position: fixed;
  bottom: 20px;
  right: 20px;
  z-index: 20;
}

.pointer {
  cursor: pointer;
}
</style>