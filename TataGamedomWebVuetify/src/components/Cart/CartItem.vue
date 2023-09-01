<template>
  <v-container>
    <v-sheet v-if="cartData?.cartItems?.length > 0" class="mySheet">
      <v-table>
        <thead class="text-center justify-center align-center">
          <tr>
            <th class="myTh"></th>
            <th class="myTh">遊戲平台</th>
            <th class="myTh">商品名稱</th>
            <th class="myTh">單件價格</th>
            <th class="myTh">數量</th>
            <th class="myTh">小計</th>
            <th class="myTh"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in cartData.cartItems" :key="item.product.id" class="mb-3">
            <td class="myTd">
              <img :src="imgLink + item.product.gameCoverImg" height="100" cover />
            </td>
            <td class="myTd">
              <v-chip color="#a1dfe9" label>
                <v-icon start icon="mdi-gamepad-right"></v-icon>
                {{ item.product.gamePlatformName }}
              </v-chip>
              <div v-if="item.product.isVirtual" style="font-size: 12px;">※虛擬商品</div>
            </td>
            <td class="myTd">
              <div style="text-align: left;">{{ item.product.chiName }}</div>
            </td>
            <td v-if="item.product.price != item.product.specialPrice" class="myTd">
              <div>
                <s>{{ unitExchange(item.product.price) }}</s>
              </div>
              <div>{{ unitExchange(item.product.specialPrice) }}</div>
            </td>
            <td v-else class="myTd">{{ unitExchange(item.product.price) }}</td>
            <td class="myTd">
              <v-row class="d-flex justify-center align-center">
                <v-col cols="4" class="d-flex justify-center align-center">
                  <v-btn @click="decreaseQuantity(item)" class="plusMinBtn">
                    <v-icon>mdi-minus</v-icon>
                  </v-btn>
                </v-col>
                <v-col cols="4" class="d-flex justify-center align-center">
                  <input type="number" :value="item.qty" min="0" :max="limit" style="color:#a1dfe9" class="text-center"
                    readonly />
                </v-col>
                <v-col cols="4" class="d-flex justify-center align-center">
                  <v-btn @click="increaseQuantity(item)" class="plusMinBtn">
                    <v-icon>mdi-plus</v-icon>
                  </v-btn>
                </v-col>
              </v-row>
            </td>
            <td class="text-end">
              <span v-if="item.subTotal">{{ unitExchange(item.subTotal) }}</span>
              <span v-else>{{ unitExchange(item.product.subTotal) }}</span>
            </td>
            <td class="text-end">
              <v-icon @click="removeItem(item.product.id)">mdi-cart-remove</v-icon>
            </td>
          </tr>
          <tr>
            <td colspan="7">
              <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
            </td>
          </tr>
          <tr>
            <td>優惠活動</td>
            <td>
              <span v-for="(item, index) in cartData.distinctCoupons" :key="index">
                {{ item }} {{ cartData.distinctCouponsDescription[index]
                }}<br />
              </span>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr>
            <td colspan="7">
              <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
            </td>
          </tr>
        </tbody>
      </v-table>
      <v-row>
        <v-col cols="7">
          <v-card class="mt-3 mySheet" height="430">
            <v-card-title class="d-flex">🚛 選擇送貨及付款方式</v-card-title>
            <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
            <v-card-title class="textYellow">送貨地點</v-card-title>
            <v-select v-model="selectLocation" :items="shipLocation" item-title="label" item-value="item" return-object
              single-line theme="dark" style="background-colorr:#01010f;color:white"></v-select>
            <v-card-title class="textYellow">送貨方式</v-card-title>
            <v-select v-model="selectShipMethod" :items="shipMethod" item-title="label" item-value="item" return-object
              single-line theme="dark" style="background-colorr:#01010f;color:white"></v-select>
            <v-card-title class="textYellow">付款方式</v-card-title>
            <v-select v-model="selectPayment" :items="payment" item-title="label" item-value="item" return-object
              single-line theme="dark" style="background-colorr:#01010f;color:white"></v-select>
          </v-card>
        </v-col>
        <v-col cols="5">
          <v-card class="mt-3 mySheet" height="430"
            style="display: flex; flex-direction: column; justify-content: space-between;">
            <v-card-title class="d-flex">💬 訂單資訊</v-card-title>
            <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
            <v-card-title class="textYellow">小計：{{ unitExchange(cartData.subTotal) }}</v-card-title>
            <v-card-title class="textYellow">運費：{{ unitExchange(freight) }}</v-card-title>
            <div v-if="!isLogin">
              <v-card-title class="textYellow">合計：{{ unitExchange(finalTotal) }}</v-card-title>
            </div>
            <div v-else>
              <v-card-title class="textYellow">合計：{{ unitExchange(cartData.total + freight) }}</v-card-title>
            </div>
            <div class="d-flex align-center justify-end" style="margin-left: auto;">
              <img src="https://localhost:7081/Files/Uploads/icons/tataUserIcon.jpg" alt="" height="150">
            </div>
            <div style="margin-top: auto;">
              <v-btn v-if="isLogin" width="100%" class="myBtn mb-5" @click="returnSelectedHandler">前往結帳</v-btn>
              <v-btn v-else width="100%" class="myBtn" @click="returnLogin">請登入後結帳</v-btn>
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-sheet>
    <v-sheet v-else class="text-center myComment">您的購物車為空，<a href="/eCommerce"
        style="color:#a1dfe9">點我到商城逛逛！</a></v-sheet>
  </v-container>
</template>
    
<script setup>
import { ref, watch, watchEffect, computed, onMounted } from "vue";
import store from '@/store';
import { useRouter } from "vue-router";
import Swal from 'sweetalert2';

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
const hasVirtualItem = ref(false);
const hasPhysicalItem = ref(false);

const unitExchange = (x) => {
  return 'NT$ ' + x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

const finalTotal = computed(() => {
  const computedTotal = cartData.value.subTotal + freight.value
  return computedTotal >= 3000 ? computedTotal - 300 : computedTotal;
})
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
  { id: "8", method: "gameCode", label: "虛擬商品不須寄送" },
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


const fee = ref(0);
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
          price: productDetail.price,
          specialPrice: productDetail.specialPrice,
          subTotal: subTotal,
          couponDescription: productDetail.couponDescription,
          gameCoverImg: productDetail.gameCoverImg,
          chiName: productDetail.chiName,
          coupons: productDetail.coupons,
          gamePlatformName: productDetail.gamePlatformName,
          isVirtual: productDetail.isVirtual
        },
        qty: localItem.qty,
      });

      if (productDetail.isVirtual) {
        hasVirtualItem.value = true;
      } else {
        hasPhysicalItem.value = true;
      }

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

  hasVirtualItem.value = false;
  hasPhysicalItem.value = false;

  for (const cartItem of cartItems.value) {
    if (cartItem.product.isVirtual) {
      hasVirtualItem.value = true;
    } else {
      hasPhysicalItem.value = true;
    }
  }
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

watch(
  [selectLocation, hasVirtualItem, hasPhysicalItem],
  ([newLocation, newHasVirtual, newHasPhysical]) => {
    updateShipmentOptions();
    calculatePaymentOption();
  }
);

watch([() => total.value, () => selectShipMethod.value], () => {
  calculateShippingFee();
});

watch([() => selectShipMethod.value, () => selectPayment.value], () => {
  calculatePaymentOption();
});

//寄送方式
const updateShipmentOptions = () => {
  if (hasVirtualItem.value && !hasPhysicalItem.value && selectLocation.value.loc === "taiwan") {
    shipMethod.value = [
      { id: "8", method: "gameCode", label: "虛擬商品不須寄送" }
    ];
    payment.value = [
      { id: "1", method: "linePay", label: "LinePay📱" },
      { id: "2", method: "creditCard", label: "信用卡💳(Visa, Master, JCB)" }
    ];
    selectShipMethod.value = { id: "8", method: "gameCode", label: "虛擬商品不須寄送" };
    selectPayment.value = { id: "1", method: "linePay", label: "LinePay📱" };

  } else {
    if (selectLocation.value.loc !== "taiwan") {
      shipMethod.value = [
        { id: "7", method: "oversea", label: "海外 - 運費到付" }
      ];
      payment.value = [
        { id: "2", method: "creditCard", label: "信用卡💳(Visa, Master, JCB)" }
      ];
      selectShipMethod.value = {
        id: "7",
        method: "oversea",
        label: "海外 - 運費到付"
      };
      selectPayment.value = {
        id: "2",
        method: "creditCard",
        label: "信用卡💳(Visa, Master, JCB)"
      };
    } else {
      if (hasVirtualItem.value && hasPhysicalItem.value && selectLocation.value.loc === "taiwan") {
        shipMethod.value = [
          { id: "2", method: "payFirstAt711", label: "7-11超商🏣 - 純取貨" },
          { id: "4", method: "payFirstAtFam", label: "全家超商🏣 - 純取貨" },
          { id: "5", method: "payFirstAtHome", label: "宅配🚛 - 黑貓宅急便" },
        ];
        selectShipMethod.value = { id: "2", method: "payFirstAt711", label: "7-11超商🏣 - 純取貨" };
        selectPayment.value = { id: "1", method: "linePay", label: "LinePay📱" };
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
            label: "7-11超商🏣 - 取貨付款"
          };
        }
      }

    }
  }
};


const calculatePaymentOption = () => {
  if (selectLocation.value.loc === "taiwan") {
    if (
      selectShipMethod.value.method === "payFirstAt711" ||
      selectShipMethod.value.method === "payFirstAtFam" ||
      selectShipMethod.value.method === "payFirstAtHome" ||
      selectShipMethod.value.method === "gameCode"
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
  if (total.value >= 2000 || selectShipMethod.value.method === "oversea" || (hasVirtualItem.value && !hasPhysicalItem.value)) {
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
  console.log("calculateShippingFee")
};

const fetchQuantityLimit = async (productId) => {
  const response = await fetch(
    `https://localhost:7081/api/InventoryItems/RemainingQuantity/${productId}`
  );
  const datas = await response.json();
  limit.value = datas;
  console.log(limit.value);
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
        console.log(item.qty);
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
      Swal.fire('錯誤', '購物車中無此商品', 'error');
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
  Swal.fire({
    title: '確認刪除此商品？',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: ' #a1dfe9',
    cancelButtonColor: '#f9ee08',
    cancelButtonText: '取消',
    confirmButtonText: '確認'
  }).then(async (result) => {
    if (result.isConfirmed) {
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
    }
  })







};

loadData();
updateShipmentOptions();
calculatePaymentOption();
</script>
    
<style scoped>
.v-container {
  max-width: 90% !important;
}

.myComment {
  background-color: #01010f;
  color: white
}

.mySheet {
  width: 100%;
  background-color: #01010f;
  color: #a1dfe9;
  font-size: 16px;
}

.v-table {
  background-color: #01010f;
  color: white !important;
}

.myTh {
  text-align: center !important;
  color: #f9ee08 !important;
  width: auto;
}

.myTd {
  text-align: center !important;
  justify-items: center !important;
  align-items: center !important;
  width: auto;
}

.myBtn {
  font-size: 18px;
  border: 1px solid #a1dfe9;
  background-color: #01010f;
  color: #a1dfe9;
}

.myBtn:hover {
  background-color: #a1dfe9;
  color: #01010f;
  box-shadow: 2px 2px 10px #a1dfe9;
}

.textYellow {
  color: #f9ee08 !important;
  font-size: 16px;
}

.v-table td {
  border-bottom: none !important;
}

.v-table th {
  border-bottom: none !important;
}
</style>