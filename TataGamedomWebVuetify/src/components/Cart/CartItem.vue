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
            <td>
              <span
                class="me-auto"
                v-for="item in cartData.distinctCoupons"
                :key="item"
              >
                {{ item }}　</span
              ><span
                v-for="item in cartData.distinctCouponsDescription"
                :key="item"
                >{{ item }}<br
              /></span>
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
            <td class="text-end">NT${{ cartData.total }}</td>
          </tr>
        </tbody>
      </v-table>
    </v-sheet>
    <v-sheet v-else class="text-center"
      >您的購物車為空，<a href="/eCommerce">點我到商城逛逛！</a></v-sheet
    >
    <v-row>
      <v-col cols="8">
        <v-card class="mt-3">
          <v-card-title class="d-flex"
            >選擇送貨及付款方式
            <v-card-subtitle>運費：NT${{}}</v-card-subtitle></v-card-title
          >
          <hr />
          <v-card-subtitle>送貨地點</v-card-subtitle>
          <v-select
            v-model="selectLocation"
            :items="shipLocation"
            variant="solo"
          ></v-select>
          <v-card-subtitle>送貨方式</v-card-subtitle>
          <v-select
            v-model="selectShipMethod"
            :items="shipMethod"
            variant="solo"
          ></v-select>
          <v-card-subtitle>付款方式</v-card-subtitle>
          <v-select
            v-model="selectPayment"
            :items="payment"
            variant="solo"
          ></v-select>
        </v-card>
      </v-col>
      <v-col cols="4">
        <v-card class="mt-3">
          <v-card-title class="d-flex">訂單資訊</v-card-title>
          <hr />
          <v-card-subtitle>小計：</v-card-subtitle>
          <v-card-subtitle>折扣：</v-card-subtitle>
          <v-card-subtitle>運費：</v-card-subtitle>
          <v-card-subtitle>合計：</v-card-subtitle>
          <div class="d-flex justify-center">
            <v-btn width="300" color="">前往結帳</v-btn>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
    
<script setup lang='ts'>
import { ref, watch } from "vue";

const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const limit = ref(0);
const quantity = ref();
const selectLocation = ref("台灣");
const selectShipMethod = ref("7-11超商🏣 - 取貨付款");

const shipLocation = ref(["台灣", "新加坡", "香港", "澳門", "馬來西亞"]);
const shipMethod = ref([
  "7-11超商🏣 - 取貨付款",
  "7-11超商🏣 - 純取貨",
  "全家超商🏣 - 取貨付款",
  "全家超商🏣 - 純取貨",
  "宅配🚛 - 黑貓宅急便",
  "宅配🚛 - 黑貓宅急便 貨到付款",
]);
const payment = ref([
  "LinePay📱",
  "信用卡💳(Visa, Master, JCB)",
  "7-11超商🏣 - 取貨付款",
  "全家超商🏣 - 取貨付款",
  "黑貓宅急便💸 - 貨到付款",
]);

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
    
<style></style>