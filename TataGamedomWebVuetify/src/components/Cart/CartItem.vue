<template>
  <v-container>
    <v-sheet v-if="cartData.allowCheckout == true">
      <v-table>
        <thead class="text-center">
          <tr>
            <th></th>
            <th>商品名稱</th>
            <th class="text-end">單件價格</th>
            <th class="text-end">數量</th>
            <th class="text-end">小計</th>
            <th class="text-end"></th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="item in cartItems" :key="item.product.id">
            <td>
              <img
                :src="imgLink + item.product.gameCoverImg"
                height="150"
                cover
              />
            </td>
            <td>
              <div>{{ item.product.chiName }}</div>
              <div>
                <v-chip class="ma-2" color="cyan" label>
                  <v-icon start icon="mdi-gamepad-right"></v-icon>
                  {{ item.product.gamePlatformName }}
                </v-chip>
              </div>
            </td>
            <td
              v-if="item.product.price != item.product.specialPrice"
              class="text-end"
            >
              <div>
                <s>NT${{ item.product.price }}</s>
              </div>
              <div>NTS{{ item.product.specialPrice }}</div>
            </td>
            <td v-else>NT${{ item.product.price }}</td>
            <td>
              <v-row>
                <v-col class="d-flex" cols="3">
                  <v-btn @click="decreaseQuantity(item)" :max="limit"
                    ><v-icon>mdi-minus</v-icon></v-btn
                  >
                </v-col>
                <v-col cols="6">
                  <v-text-field
                    v-model="item.qty"
                    min="0"
                    :max="limit"
                    variant="outlined"
                    readonly
                  ></v-text-field>
                </v-col>
                <v-col cols="3">
                  <v-btn @click="increaseQuantity(item)" :max="limit"
                    ><v-icon>mdi-plus</v-icon></v-btn
                  >
                </v-col>
              </v-row>
            </td>
            <td class="text-end" v-text="item.subTotal"></td>
            <td class="text-end">
              <v-icon @click="removeItem(item.product.id)"
                >mdi-cart-remove</v-icon
              >
            </td>
          </tr>
          <tr>
            <td>已享用優惠</td>
            <td v-for="item in cartItems" :key="item.product.id">
              {{ item.product.coupons }}　{{ item.product.couponDescription }}
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>總計：</td>
            <td class="text-end">NT${{ calculateTotal }}</td>
          </tr>
          <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td><v-btn>結帳</v-btn></td>
          </tr>
        </tbody>
      </v-table>
    </v-sheet>
    <v-sheet v-else class="text-center"
      >您的{{ cartData.message }}，<a href="/eCommerce"
        >點我到商城逛逛！</a
      ></v-sheet
    >
  </v-container>
</template>
    
<script setup lang='ts'>
import { ref, computed, watch } from "vue";

const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const limit = ref(0);
const quantity = ref();

const loadData = async () => {
  const response = await fetch(`https://localhost:7081/api/Carts`, {
    method: "GET",
    credentials: "include",
  });
  const datas = await response.json();
  cartData.value = datas;
  console.log(cartData.value);

  cartItems.value = datas.cartItems;
};

const calculateTotal = computed(() => {
  return cartItems.value.reduce((total, item) => total + item.subTotal, 0);
});

watch(
  () => cartItems.value,
  (newCartItems) => {
    if (newCartItems) {
      newCartItems.forEach((item) => {
        fetchQuantityLimit(item.product.id);
      });
    }
  }
);

const fetchQuantityLimit = async (productId) => {
  const response = await fetch(
    `https://localhost:7081/api/InventoryItems/RemainingQuantity/${productId}`
  );
  const datas = await response.json();
  limit.value = datas;
};

const increaseQuantity = async (item) => {
  if (item.qty < limit.value) {
    item.qty++;
  }
  await fetch(
    `https://localhost:7081/api/Carts?productId=${item.product.id}&newQty=${item.qty}`,
    {
      method: "PUT",
      credentials: "include",
    }
  )
    .then((response) => {
      loadData();
    })
    .catch((error) => {
      console.error("Error:", error);
    });
};

const decreaseQuantity = async (item) => {
  if (item.qty > 0) {
    item.qty--;
  }
  await fetch(
    `https://localhost:7081/api/Carts?productId=${item.product.id}&newQty=${item.qty}`,
    {
      method: "PUT",
      credentials: "include",
    }
  )
    .then((response) => {
      loadData();
    })
    .catch((error) => {
      console.error("Error:", error);
    });
};

const removeItem = async (productId) => {
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
    .then((response) => {
      loadData();
    })
    .catch((error) => {
      console.error("Error:", error);
    });
};
loadData();
</script>
    
<style>
</style>