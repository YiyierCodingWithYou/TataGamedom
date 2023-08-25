<template>
  <v-container>
    <v-sheet v-if="cartData?.cartItems?.length > 0">
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
          <tr v-for="item in cartData.cartItems" :key="item.product.id">
            <td>
              <img :src="imgLink + item.product.gameCoverImg" height="150" cover />
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
            <td v-if="item.product.price != item.product.specialPrice" class="text-end">
              <div>
                <s>NT${{ item.product.price }}</s>
              </div>
              <div>NTS{{ item.product.specialPrice }}</div>
            </td>
            <td v-else>NT${{ item.product.price }}</td>
            <td>
              <v-row>
                <v-col class="d-flex" cols="3">
                  <v-btn @click="decreaseQuantity(item)" :max="limit"><v-icon>mdi-minus</v-icon></v-btn>
                </v-col>
                <v-col cols="6">
                  <v-text-field v-model="item.qty" min="0" :max="limit" variant="outlined" readonly></v-text-field>
                </v-col>
                <v-col cols="3">
                  <v-btn @click="increaseQuantity(item)" :max="limit"><v-icon>mdi-plus</v-icon></v-btn>
                </v-col>
              </v-row>
            </td>
            <td class="text-end">{{ item.subTotal }}{{ item.product.subTotal }}</td>
            <td class="text-end">
              <v-icon @click="removeItem(item.product.id)">mdi-cart-remove</v-icon>
            </td>
          </tr>
          <tr>
            <td>優惠活動</td>
            <td>
              <span class="me-auto" v-for="(item, index) in cartData.distinctCoupons" :key="index">
                {{ item }} {{ cartData.distinctCouponsDescription[index]
                }}<br />
              </span>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
        </tbody>
      </v-table>
      <v-row>
        <v-col cols="8">
          <v-card class="mt-3">
            <v-card-title class="d-flex">選擇送貨及付款方式</v-card-title>
            <hr />
            <v-card-subtitle>送貨地點</v-card-subtitle>
            <v-select v-model="selectLocation" :items="shipLocation" item-title="label" item-value="item" return-object
              single-line variant="solo"></v-select>
            <v-card-subtitle>送貨方式</v-card-subtitle>
            <v-select v-model="selectShipMethod" :items="shipMethod" item-title="label" item-value="item" return-object
              single-line variant="solo"></v-select>
            <v-card-subtitle>付款方式</v-card-subtitle>
            <v-select v-model="selectPayment" :items="payment" item-title="label" item-value="item" return-object
              single-line variant="solo"></v-select>
          </v-card>
        </v-col>
        <v-col cols="4">
          <v-card class="mt-3">
            <v-card-title class="d-flex">訂單資訊</v-card-title>
            <hr />
            <v-card-subtitle>小計：{{ cartData.subTotal }}</v-card-subtitle>
            <v-card-subtitle>運費：{{ freight }}</v-card-subtitle>
            <div v-if="!isLogin">
              <v-card-subtitle v-if="finalTotal.value !== cartData.total + freight">合計：{{ finalTotal
              }}</v-card-subtitle>
            </div>
            <div v-else><v-card-subtitle>合計：{{ cartData.total + freight
            }}</v-card-subtitle></div>
            <br />
            <hr />
            <br />
            <div class="d-flex justify-center">
              <v-btn v-if="isLogin" width="300" color="primary" @click="returnSelectedHandler">前往結帳</v-btn>
              <v-btn v-else width="300" color="primary" @click="returnLogin">請登入後結帳</v-btn>

            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-sheet>
    <v-sheet v-else class="text-center">您的購物車為空，<a href="/eCommerce">點我到商城逛逛！</a></v-sheet>

  </v-container>
</template>
    
<script setup>
import { ref, watch, watchEffect, computed, onMounted } from "vue";
import store from '@/store';
import { useRouter } from "vue-router";

onMounted(() => {
  getCart();
})

const router = useRouter();
const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const limit = ref(0);
const total = ref(0);
const freight = ref(0);
const finalTotal = ref(0);
const isLogin = computed(() => store.state.isLoggedIn);
const selectLocation = ref({ loc: "taiwan", label: "台灣" });
const selectShipMethod = ref({
  id: "1",
  method: "payAt711",
  label: "7-11超商🏣 - 取貨付款",
});
const selectPayment = ref({
  id: "1",
  method: "cash711",
  label: "7-11超商 - 貨到付款💌",
});

const emit = defineEmits(["getreturnSelected"]);

const returnSelectedHandler = () => {
  const selectedData = {
    location: selectLocation.value,
    shipMethod: selectShipMethod.value,
    payment: selectPayment.value,
    freight: freight.value,
    totalAmount: total.value + freight.value,
  };

  emit("getreturnSelected", selectedData);
};

const returnLogin = () => {
  router.push({
    name: "Login",
  });
}

const shipLocation = ref([
  { loc: "taiwan", label: "台灣" },
  { loc: "singapore", label: "新加坡" },
  { loc: "hong", label: "香港" },
  { loc: "mac", label: "澳門" },
  { loc: "mal", label: "馬來西亞" },
]);
const shipMethod = ref([
  { id: "1", method: "payAt711", label: "7-11超商🏣 - 取貨付款" },
  { id: "2", method: "payFirstAt711", label: "7-11超商🏣 - 純取貨" },
  { id: "3", method: "payAtFam", label: "全家超商🏣 - 取貨付款" },
  { id: "4", method: "payFirstAtFam", label: "全家超商🏣 - 純取貨" },
  { id: "5", method: "payFirstAtHome", label: "宅配🚛 - 黑貓宅急便" },
  { id: "6", method: "payAtHome", label: "宅配🚛 - 黑貓宅急便 貨到付款" },
  { id: "7", method: "oversea", label: "海外 - 運費到付" },
]);
const payment = ref([
  { id: "1", method: "linePay", label: "LinePay📱" },
  { id: "2", method: "creditCard", label: "信用卡💳(Visa, Master, JCB)" },
  { id: "3", method: "cash711", label: "7-11超商 - 貨到付款💌" },
  { id: "4", method: "cashFam", label: "全家超商 - 貨到付款💌" },
  { id: "5", method: "cashBlackCat", label: "黑貓宅急便 - 貨到付款💸" },
]);

const loadData = async () => {
  if (isLogin.value) {
    await getCart();
  } else {
    await getLocalCart();
  }
};

const getLocalCart = async () => {
  cartData.value = {
    cartItems: [],
    subTotal: 0,
    total: 0,
    distinctCoupons: [],
    distinctCouponsDescription: []
  };

  const localCart = JSON.parse(localStorage.getItem("localCart") || "[]");

  for (const localItem of localCart) {
    try {
      const response = await fetch(
        `https://localhost:7081/api/Products/${localItem.productId}?page=1&pageSize=5`
      );
      const productDetail = await response.json();
      const subTotal = productDetail.specialPrice * localItem.qty;

      console.log(localItem.qty)
      console.log(subTotal)

      cartData.value.cartItems.push({
        product: {
          id: localItem.productId,
          specialPrice: productDetail.specialPrice,
          subTotal: subTotal,
          couponDescription: productDetail.couponDescription,
          gameCoverImg: productDetail.gameCoverImg,
          chiName: productDetail.chiName,
          coupons: productDetail.coupons,
          gamePlatformName: productDetail.gamePlatformName,
        },
        qty: localItem.qty,
      });

      for (let i = 0; i < productDetail.coupons.length; i++) {
        const coupon = productDetail.coupons[i];
        const couponDescription = productDetail.couponDescription[i];

        if (!cartData.value.distinctCoupons.includes(coupon)) {
          cartData.value.distinctCoupons.push(coupon);
          cartData.value.distinctCouponsDescription.push(couponDescription);
        }
      }
      console.log(cartData.value);

      calculateShippingFee();

      cartData.value.subTotal += subTotal;

      total.value = cartData.value.subTotal;

      finalTotal.value = total.value >= 3000 ? total.value - 300 : total.value + freight.value;
    } catch (error) {
      console.error("Error fetching product details:", error);
    }
  }
}

const getCart = async () => {
  const response = await fetch(`https://localhost:7081/api/Carts`, {
    method: "GET",
    credentials: "include",
  });
  const datas = await response.json();
  cartData.value = datas;
  cartItems.value = datas.cartItems;
  total.value = datas.total;
}

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
watch([() => selectLocation.value, () => selectShipMethod.value], () => {
  updateShipmentOptions();
  calculatePaymentOption();
});
const loading = ref(false);


watch([() => total.value, () => selectShipMethod.value], () => {
  calculateShippingFee();
  //   loadData();
});

watch([() => selectShipMethod.value, () => selectPayment.value], () => {
  calculatePaymentOption();
});

const updateShipmentOptions = () => {
  if (selectLocation.value.loc !== "taiwan") {
    shipMethod.value = [
      { id: "7", method: "oversea", label: "海外 - 運費到付" },
    ];
    payment.value = [
      { id: "2", method: "creditCard", label: "信用卡💳(Visa, Master, JCB)" },
    ];
    selectShipMethod.value = {
      id: "7",
      method: "oversea",
      label: "海外 - 運費到付",
    };
    selectPayment.value = {
      id: "2",
      method: "creditCard",
      label: "信用卡💳(Visa, Master, JCB)",
    };
  } else {
    shipMethod.value = [
      { id: "1", method: "payAt711", label: "7-11超商🏣 - 取貨付款" },
      { id: "2", method: "payFirstAt711", label: "7-11超商🏣 - 純取貨" },
      { id: "3", method: "payAtFam", label: "全家超商🏣 - 取貨付款" },
      { id: "4", method: "payFirstAtFam", label: "全家超商🏣 - 純取貨" },
      { id: "5", method: "payFirstAtHome", label: "宅配🚛 - 黑貓宅急便" },
      { id: "6", method: "payAtHome", label: "宅配🚛 - 黑貓宅急便 貨到付款" },
    ];

    if (
      !shipMethod.value.some(
        (method) => method.method === selectShipMethod.value.method
      )
    ) {
      selectShipMethod.value = {
        id: "1",
        method: "payAt711",
        label: "7-11超商🏣 - 取貨付款",
      };
    }
  }
};

const calculatePaymentOption = () => {
  if (selectLocation.value.loc === "taiwan") {
    if (
      selectShipMethod.value.method === "payFirstAt711" ||
      selectShipMethod.value.method === "payFirstAtFam" ||
      selectShipMethod.value.method === "payFirstAtHome"
    ) {
      payment.value = [
        { id: "1", method: "linePay", label: "LinePay📱" },
        { id: "2", method: "creditCard", label: "信用卡💳(Visa, Master, JCB)" },
      ];

      if (
        !payment.value.some(
          (method) => method.method === selectPayment.value.method
        )
      ) {
        selectPayment.value = {
          id: "1",
          method: "linePay",
          label: "LinePay📱",
        };
      }
    } else if (selectShipMethod.value.method === "payAt711") {
      payment.value = [
        { id: "3", method: "cash711", label: "7-11超商 - 貨到付款💌" },
      ];
      selectPayment.value = {
        id: "3",
        method: "cash711",
        label: "7-11超商 - 貨到付款💌",
      };
    } else if (selectShipMethod.value.method === "payAtFam") {
      payment.value = [
        { id: "4", method: "cashFam", label: "全家超商 - 貨到付款💌" },
      ];
      selectPayment.value = {
        id: "4",
        method: "cashFam",
        label: "全家超商 - 貨到付款💌",
      };
    } else {
      payment.value = [
        { id: "5", method: "cashBlackCat", label: "黑貓宅急便 - 貨到付款💸" },
      ];
      selectPayment.value = {
        id: "5",
        method: "cashBlackCat",
        label: "黑貓宅急便 - 貨到付款💸",
      };
    }
  }
};

const calculateShippingFee = () => {
  if (total.value >= 2000 || selectShipMethod.value.method === "oversea") {
    freight.value = 0;
  } else if (total.value < 2000) {
    if (
      selectShipMethod.value.method !== "payFirstAtHome" &&
      selectShipMethod.value.method !== "payAtHome"
    ) {
      freight.value = 60;
    } else {
      freight.value = 80;
    }
  }
};

const fetchQuantityLimit = async (productId) => {
  const response = await fetch(
    `https://localhost:7081/api/InventoryItems/RemainingQuantity/${productId}`
  );
  const datas = await response.json();
  limit.value = datas;
};

const increaseQuantity = async (item) => {
  if (isLogin.value) {
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
  } else {
    let localCart = JSON.parse(localStorage.getItem("localCart") || "[]");
    const productIndex = localCart.findIndex(
      (localItem) => localItem.productId === item.product.id
    );
    if (productIndex !== -1) {
      localCart[productIndex].qty += 1;
    } else {
      alert('購物車中無此商品！');
    }
    localStorage.setItem("localCart", JSON.stringify(localCart));
    console.log(localCart);
    loadData();
  }
};
const decreaseQuantity = async (item) => {
  if (isLogin.value) {
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
  }
  else {
    let localCart = JSON.parse(localStorage.getItem("localCart") || "[]");
    const productIndex = localCart.findIndex(
      (localItem) => localItem.productId === item.product.id
    );
    if (productIndex !== -1 && localCart[productIndex].qty > 0) {
      localCart[productIndex].qty -= 1;
      if (localCart[productIndex].qty === 0) {
        localCart.splice(productIndex, 1);
      }
      localStorage.setItem("localCart", JSON.stringify(localCart));
      console.log(localCart);
      loadData();
    }
  }
};

const removeItem = async (productId) => {
  if (store.state.isLoggedIn) {
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
      loadData();
    }
  }
};

loadData();
updateShipmentOptions();
calculatePaymentOption();
</script>
    
<style></style>