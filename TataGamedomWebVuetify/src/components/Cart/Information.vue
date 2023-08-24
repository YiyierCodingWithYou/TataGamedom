<template>
  <v-expansion-panels v-if="cartData.allowCheckout">
    <v-expansion-panel>
      <v-expansion-panel-title>合計：NT${{ selectedData.totalAmount }}<br />購物車（{{
        count
      }}件）</v-expansion-panel-title>
      <v-expansion-panel-text>
        <v-sheet v-if="cartData.allowCheckout == true">
          <v-table>
            <thead class="text-center">
              <tr>
                <th></th>
                <th>商品名稱</th>
                <th class="text-end">單件價格</th>
                <th class="text-end">數量</th>
                <th class="text-end">小計</th>
              </tr>
            </thead>

            <tbody>
              <tr v-for="item in cartItems" :key="item.product.id">
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
                <td class="text-end">
                  {{ item.qty }}
                </td>
                <td class="text-end" v-text="item.subTotal"></td>
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
              <tr>
                <td></td>
                <td></td>
                <td></td>
                <td class="text-end">運費：<br />總計：</td>
                <td class="text-end">
                  NT${{ selectedData.freight }}<br />NT${{
                    selectedData.totalAmount
                  }}
                </td>
              </tr>
            </tbody>
          </v-table>
        </v-sheet>
      </v-expansion-panel-text>
    </v-expansion-panel>
  </v-expansion-panels>
  <v-form v-model="valid" v-if="cartData.allowCheckout">
    <v-container>
      <v-row>
        <v-col cols="6">
          <v-card class="mt-3">
            <v-card-title>✨顧客資料</v-card-title>
            <v-divider></v-divider>
            <v-card-title>姓名</v-card-title>
            <v-text-field v-model="name" variant="solo" required density="compact"></v-text-field>
            <v-card-title>電話號碼</v-card-title>
            <v-text-field density="compact" v-model="phoneNumber" variant="solo" required></v-text-field>
            <v-card-title>E-mail</v-card-title>
            <v-text-field density="compact" v-model="email" variant="solo" readonly class="mb-5"></v-text-field>
          </v-card>
        </v-col>

        <v-col cols="6"><v-card class="mt-3">
            <v-card-title>✨收件人資料</v-card-title>
            <v-divider></v-divider>
            <p>已選擇的送貨方式：{{ selectedData.shipMethod.label }}</p>
            <v-checkbox v-model="fillRecipient" @input="handleFillRecipient" label="收件人資料與顧客資料相同"></v-checkbox>
            <v-card-subtitle>收件人名稱</v-card-subtitle>
            <v-text-field density="compact" v-model="buyerName" :rules="[rules.required]" hide-details="auto"
              variant="solo" required></v-text-field>
            <v-card-subtitle class="mb-5">請填入收件人真實姓名，以確保順利收件</v-card-subtitle>
            <v-card-subtitle>收件人電話號碼</v-card-subtitle>
            <v-text-field density="compact" v-model="buyerPhone" :rules="[rules.required]" hide-details="auto"
              variant="solo" required class="mb-5"></v-text-field>
            <v-card-subtitle>E-mail</v-card-subtitle>
            <v-text-field density="compact" v-model="buyerEmail" :rules="[rules.required, rules.email]"
              hide-details="auto" variant="solo" required></v-text-field>
            <v-divider></v-divider>
            <div v-if="selectedData.shipMethod.id == 1 ||
              selectedData.shipMethod.id == 2
              ">
              <p class="mb-5">
                <img src="https://localhost:7081/Files/Uploads/seven-eleven.png" width="30" />
                選擇門市
              </p>
              <div v-if="singleSpot && singleSpot.storeNumber" class="mb-5">
                <p>門市編號：{{ singleSpot.storeNumber }}</p>
                <p>門市名稱：{{ singleSpot.storeName }}</p>
                <p>門市地址：{{ singleSpot.address }}</p>
              </div>
              <v-row justify="center" class="mb-3">
                <v-dialog v-model="dialog" persistent width="auto">
                  <template v-slot:activator="{ props }">
                    <v-btn color="primary" v-bind="props"> 搜尋門市 </v-btn>
                  </template>
                  <v-card width="850" height="500">
                    <v-row class="d-flex">
                      <v-col cols="10" class="d-flex">
                        <v-card-title>以路名查詢：</v-card-title>
                        <v-text-field v-model="keyword" single-line variant="solo" label="請輸入道路名稱"></v-text-field>
                      </v-col>
                      <v-col cols="10" class="d-flex">
                        <v-card-title>以門市查詢：</v-card-title>
                        <v-text-field v-model="branch" single-line variant="solo" label="請輸入門市名稱"></v-text-field>
                      </v-col>
                      <v-col cols="6" class="d-flex">
                        <v-card-title>以縣市查詢：</v-card-title>
                        <v-select v-model="city" :items="cityList" item-value="item" return-object single-line
                          variant="solo" label="---"></v-select>
                        <v-col cols="2" @click="spotSearch"><v-btn>搜尋</v-btn></v-col>
                      </v-col>
                      <v-col cols="12">
                        <v-card-title>請選擇門市：</v-card-title>
                        <v-select v-if="spotList && spotList.length" v-model="spot" :items="spotList"
                          :item-title="displayItem" item-value="id" single-line variant="solo"></v-select>
                      </v-col>
                    </v-row>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="green-darken-1" variant="text" @click="dialog = false">
                        取消
                      </v-btn>
                      <v-btn color="green-darken-1" variant="text" @click="spotHandler(spot)">
                        確認
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
              </v-row>
            </div>

            <div v-else-if="selectedData.shipMethod.id == 3 ||
              selectedData.shipMethod.id == 4
              ">
              <p>
                <img src="https://localhost:7081/Files/Uploads/family_mart.jpg" width="30" />
                選擇門市
              </p>
              <div class="d-flex justify-center"></div>
            </div>

            <p v-else>
              <v-card-title>地址</v-card-title>
              <v-text-field density="compact" :rules="[rules.required]" hide-details="auto" variant="solo"
                required></v-text-field>
            </p>
          </v-card>
        </v-col>
      </v-row>
      <div class="d-flex mt-5">
        <v-btn class="me-auto">繼續購物</v-btn>
        <form ref="ecpayForm" action="https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5" method="POST">
          <input type="hidden" v-for="(value, key) in ecPayparams" :key="key" :name="key" :value="value" />
          <v-btn @click.prevent="handleSubmit">送出訂單</v-btn>
        </form>
      </div>
    </v-container>
  </v-form>
</template>
    
<script setup>
import { ref, defineProps, computed, watch } from "vue";
import Payment from "@/components/Cart/Payment.vue";
import { useRoute, useRouter } from "vue-router";
import { useStore } from "vuex";
const store = useStore();
const router = useRouter();
const route = useRoute();
const dialog = ref(false);
const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const count = ref(0);
const total = ref(0);
const member = ref({});
const name = ref("");
const email = ref("");
const phoneNumber = ref("");
const keyword = ref("");
const branch = ref("");
const city = ref("");
const cityList = ref([]);
const spot = ref("");
const singleSpot = ref({});
const spotList = ref([]);
const props = defineProps({
  selectedData: Object,
});
const ecpayForm = ref(null);
const ecPayparams = ref({});
const productId = ref();
const fillRecipient = ref(false);
const buyerName = ref("");
const buyerPhone = ref("");
const buyerEmail = ref("");
const payload = ref({});
const createOrderCommand = ref({});
const createOrderItemCommandList = [];

const rules = {
  required: (value) => !!value || "此欄位必填",
  email: (value) => {
    const pattern =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return pattern.test(value) || "E-mail格式不正確";
  },
};

const getCity = async () => {
  const response = await fetch(`https://localhost:7081/api/Carts/Shop/City`);
  const datas = await response.json();
  cityList.value = datas;
};

const spotSearch = async () => {
  if (city.value) {
    keyword.value = city.value;
  }
  const response = await fetch(
    `https://localhost:7081/api/Carts/Shop?keyword=${keyword.value}&branch=${branch.value}`
  );
  const datas = await response.json();
  spotList.value = datas;
};

const displayItem = (item) => {
  if (item && item.storeName && item.address) {
    return `${item.storeName}門市 - ${item.address}`;
  } else {
    return "---";
  }
};

const spotHandler = async (value) => {
  const response = await fetch(
    `https://localhost:7081/api/Carts/SingleShop?id=${value}`
  );
  const datas = await response.json();
  singleSpot.value = datas;
  dialog.value = false;
  keyword.value = "";
  branch.value = "";
  spotList.value = [];
  createOrderCommand.value.toAddress = datas.address;
  createOrderCommand.value.shipmentMethodId = props.selectedData.shipMethod.id;
  createOrderCommand.value.recipientName = buyerName;
};

const handleFillRecipient = () => {
  if (fillRecipient.value) {
    buyerName.value = name.value;
    buyerPhone.value = phoneNumber.value;
    buyerEmail.value = email.value;
  }
};

const loadData = async (type) => {
  const response = await fetch(`https://localhost:7081/api/Carts`, {
    method: "GET",
    credentials: "include",
  });
  const datas = await response.json();
  cartData.value = datas;
  cartItems.value = datas.cartItems;
  total.value = datas.total;
  console.log(cartItems.value);
  count.value = datas.cartItems.length;
  payload.value.goodsAmount = props.selectedData.totalAmount;
};

const load = async () => {
  await loadData();
  await getMember();
  await getCity();

  let totalItemsCount = cartItems.value.reduce(
    (accumulator, item) => accumulator + item.qty,
    0
  );
  console.log(totalItemsCount);

  let discountPerItem = 0;
  if (total.value > 3000) {
    discountPerItem = 300 / totalItemsCount;
  }

  cartItems.value.forEach((item) => {
    let productPrice = item.product.specialPrice - discountPerItem;

    for (let i = 0; i < item.qty; i++) {
      createOrderItemCommandList.push({
        productPrice: productPrice,
        productId: item.product.id,
      });
    }
  });

  console.log(createOrderCommand.value);
  console.log(createOrderItemCommandList);
};
const getMember = async () => {
  const response = await fetch("https://localhost:7081/api/Members", {
    credentials: "include",
  });
  const datas = await response.json();
  member.value = datas;
  phoneNumber.value = datas.phone;
  name.value = datas.name;
  email.value = datas.email;
  createOrderCommand.value.memberId = datas.id;
};

const checkoutECPay = async () => {
  try {
    const response = await fetch(
      `https://localhost:7081/api/ECPay/Create?total=${props.selectedData.totalAmount}`,
      {
        method: "POST",
        body: JSON.stringify({
          total: props.selectedData.totalAmount,
        }),
      }
    );
    ecPayparams.value = await response.json();
  } catch (error) {
    console.log("Error:", error);
  }
};

const createLogisticsOrder = async (payload) => {
  {
    try {
      const result = await store.dispatch("createLogisticsOrder", payload);
      console.log(result);
    } catch (error) {
      console.error("Error creating logistics order:", error);
    }
    return {
      createLogisticsOrder,
    };
  }
};

const checkoutLinePay = async () => {
  const response = await fetch(`https://localhost:7081/api/LinePay/Create`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    credentials: "include",
    body: JSON.stringify({}),
  });
  if (response.ok) {
    const data = await response.json();
    sessionStorage.setItem("totalAmount", props.selectedData.totalAmount);
    window.location = data.info.paymentUrl.web;
  } else {
    console.log(response);
  }
};

const createOrder = async () => {
  try {
    const response = await fetch(
      `https://localhost:7081/api/Orders/OrderWithMultipleItems`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          createOrderCommand: createOrderCommand.value,
          createOrderItemCommandList: createOrderItemCommandList,
        }),
      }
    );

    if (response.ok) {
      const data = await response.json();
      return data;
    }
  } catch (error) {
    console.error("Error:", error);
  }
};

const handleSubmit = async () => {
  try {
    if (props.selectedData.payment.id == 2) {
      await checkoutECPay();
      ecpayForm.value.submit();
    } else if (props.selectedData.payment.id == 1) {
      await checkoutLinePay();
    } else {
      router.push({ name: "Cart", query: { paymentSuccess: "true" } });
    }

    const orderResult = await createOrder();

    payload.value.receiverName = buyerName.value;
    payload.value.MerchantTradeNo = orderResult[0].orderIndex;
    createLogisticsOrder(payload.value);
  } catch (error) {
    console.error("Error:", error);
  }
};


// const handleSubmit = async () => {
//   try {
//     const orderResult = await createOrder();
//     payload.value.receiverName = buyerName.value;
//     payload.value.MerchantTradeNo = orderResult[0].orderIndex;
//     createLogisticsOrder(payload.value);
//     if (props.selectedData.payment.id == 2) {
//       await checkoutECPay();
//       ecpayForm.value.submit();
//     } else if (props.selectedData.payment.id == 1) {
//       await checkoutLinePay();
//     } else {
//       router.push({ name: "Cart", query: { paymentSuccess: "true" } });
//     }
//   } catch (error) {
//     console.error("Error:", error);
//   }
// };

load();
</script>
    
<style></style>