<template>
  <div>
    <v-btn class="ma-2" color="orange-darken-2" icon="mdi-cart-outline" @click.stop="toggleDrawer"></v-btn>
    <v-navigation-drawer v-model="drawer" :rail="rail" permanent location="right" class="w-25" ref="drawerRef"
      @click.stop>
      <div v-if="cartItems?.length > 0" class="cart-container">
        <div class="cart-content">
          <div v-for="item in cartItems" :key="item.product.id" class="mb-3">
            <div class="d-flex">
              <img :src="imgLink + item.product.gameCoverImg" width="150" cover />
              <div class="d-flex flex-column flex-grow-1">
                <div class="d-flex justify-between align-center">
                  <div>
                    <v-chip class="ma-2 w100 justify-center d-flex" color="primary">
                      <v-icon start icon="mdi-gamepad-right"></v-icon>
                      {{ item.product.gamePlatformName }}
                    </v-chip>
                  </div>
                </div>
                <div>
                  {{ item.product.chiName }}
                </div>
                <div class="d-flex align-center justify-between">
                  <div class="me-auto">
                    {{ item.qty }} X NT${{ item.product.specialPrice }}
                  </div>
                  <div @click.stop="deleteProduct(item.product.id)">
                    <v-icon>mdi-trash-can</v-icon>
                  </div>
                </div>
              </div>
            </div>
            <v-divider class="mt-3"></v-divider>
          </div>
        </div>
        <div class="checkout-button">
          <v-btn @click.stop="checkout">訂單結帳</v-btn>
        </div>
      </div>
      <div v-else>您的購物車是空的</div>
    </v-navigation-drawer>
  </div>
</template>
  
<script setup>
import { ref, onMounted, onUnmounted } from "vue";
import store from "@/store";
import { useRouter } from "vue-router";
import { watchEffect, watch } from "vue";
import { defineProps } from "vue";
import { defineEmits } from "vue";

import { computed } from 'vue'

const props = defineProps(['modelValue'])
const emit = defineEmits(['update:modelValue'])

const drawer = computed({
  get() {
    return props.modelValue
  },
  set(value) {
    console.log(value);
    emit('update:modelValue', value)
  }
})

const router = useRouter();
const drawerRef = ref(null);
const isLogin = computed(() => store.state.isLoggedIn);
const rail = ref(true);
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";


onMounted(() => {
  window.addEventListener("click", outsideClickListener);
});

onUnmounted(() => {
  window.removeEventListener("click", outsideClickListener);
});

const outsideClickListener = (event) => {
  // 檢查被點擊的元素是否是抽屜或其子元素
  if ((!drawerRef.value?.$el.contains(event.target)) && drawer.value) {
    closeDrawer();
  }
};

const openDrawer = () => {
  emit('update:modelValue', true)
  drawerContent();
};

const closeDrawer = () => {
  emit('update:modelValue', false)
};

const toggleDrawer = () => {
  emit('update:modelValue', !drawer.value);
}

const getCart = async () => {
  const response = await fetch(`https://localhost:7081/api/Carts`, {
    method: "GET",
    credentials: "include",
  });
  const datas = await response.json();
  cartItems.value = datas.cartItems;
};

const getLocalCart = async () => {
  cartItems.value = []; // 清空cartItems
  const localCart = JSON.parse(localStorage.getItem("localCart") || "[]");
  for (const localItem of localCart) {
    try {
      const response = await fetch(
        `https://localhost:7081/api/Products/${localItem.productId}?page=1&pageSize=5`
      );
      const productDetail = await response.json();
      cartItems.value.push({
        product: productDetail,
        qty: localItem.qty,
      });
    } catch (error) {
      console.error("Error fetching product details:", error);
    }
  }
};

const drawerContent = async () => {
  if (isLogin) {
    getCart();
  } else {
    getLocalCart();
  }
};
const checkout = async () => {
  router.push({
    name: "Cart",
  });
};

const deleteProduct = async (productId) => {
  if (isLogin) {
    const response = await fetch(
      `https://localhost:7081/api/Carts?productId=${productId}`,
      {
        method: "DELETE",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
      }
    )
      .then(() => {
        getCart();
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  } else {
    let localCart = JSON.parse(localStorage.getItem("localCart") || "[]");
    const productIndex = localCart.findIndex(
      (item) => item.productId === productId
    );
    if (productIndex > -1) {
      localCart.splice(productIndex, 1);
      localStorage.setItem("localCart", JSON.stringify(localCart));
      getLocalCart();
    }
  }
};

watchEffect(() => {
  if (store.state.isLoggedIn !== undefined) {
    drawerContent();
  }
});


</script>
  
<style>
.cart-container {
  display: flex;
  flex-direction: column;
  height: calc(100dvh - 64px);
}

.cart-content {
  flex-grow: 1;
  overflow-y: auto;
}

.checkout-button {
  flex-shrink: 0;
  padding: 10px;
  text-align: center;
  background-color: #f5f5f5;
}
</style>