<template>
  <div class="mt-3">
    <div class="d-flex justify-center">
      <v-expansion-panels v-if="cartData.allowCheckout">
        <v-expansion-panel>
          <v-expansion-panel-title class="myPanel">
            <v-spacer></v-spacer>合計：{{ unitExchange(selectedData.totalAmount) }}
            <br />
            購物車（{{ count }}件）<v-spacer></v-spacer>
          </v-expansion-panel-title>
          <v-expansion-panel-text>
            <v-sheet v-if="cartData.allowCheckout == true">
              <v-table>
                <thead class="text-center justify-center align-center">
                  <tr>
                    <th class="myTh tdImg"></th>
                    <th class="myTh tdPlatform">遊戲平台</th>
                    <th class="myTh">商品名稱</th>
                    <th class="myTh">單件價格</th>
                    <th class="myTh">數量</th>
                    <th class="myTh">小計</th>
                  </tr>
                </thead>

                <tbody>
                  <tr v-for="item in cartItems" :key="item.product.id">
                    <td class="myTd tdImg">
                      <img :src="imgLink + item.product.gameCoverImg" height="100" cover />
                    </td>
                    <td class="myTd tdPlatform">
                      <v-chip color="#a1dfe9" label>
                        <v-icon start icon="mdi-gamepad-right"></v-icon>
                        {{ item.product.gamePlatformName }}
                      </v-chip>
                      <div v-if="item.product.isVirtual" style="font-size: 12px;">※虛擬商品</div>
                    </td>
                    <td class="myTd">
                      <div>{{ item.product.chiName }}</div>
                    </td>
                    <td v-if="item.product.price != item.product.specialPrice" class="myTd">
                      <div>
                        <s>{{ unitExchange(item.product.price) }}</s>
                      </div>
                      <div>{{ unitExchange(item.product.specialPrice) }}</div>
                    </td>
                    <td class="myTd" v-else>{{ unitExchange(item.product.price) }}</td>
                    <td class="myTd">
                      {{ item.qty }}
                    </td>
                    <td class="myTd">{{ unitExchange(item.subTotal) }}</td>
                  </tr>
                  <tr>
                    <td colspan="7">
                      <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
                    </td>
                  </tr>
                  <tr class="text-center justify-center align-center">
                    <td></td>
                    <td></td>
                    <td>優惠活動</td>
                    <td class="justify-center align-center">
                      <p class="text-left" v-for="(item, index) in cartData.distinctCoupons" :key="index">
                        {{ item }} {{ cartData.distinctCouponsDescription[index]
                        }}<br />
                      </p>
                    </td>
                    <td>運費：<br />總計：</td>
                    <td class="text-left">
                      {{ unitExchange(selectedData.freight) }}<br />{{
                        unitExchange(selectedData.totalAmount)
                      }}
                    </td>
                  </tr>
                  <tr>
                    <td colspan="7">
                      <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
                    </td>
                  </tr>
                  <tr>
                    <td></td>
                    <td></td>
                    <td></td>

                  </tr>
                </tbody>
              </v-table>
            </v-sheet>
          </v-expansion-panel-text>
        </v-expansion-panel>
      </v-expansion-panels>
    </div>
    <v-form ref="form" v-if="cartData.allowCheckout">
      <v-container>
        <v-row>
          <v-col cols="6">
            <v-card class="mt-3 mySheet" height="600">
              <v-card-title>✨顧客資料</v-card-title>
              <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
              <v-card-title class="textYellow">姓名</v-card-title>
              <v-text-field v-model="name" variant="underlined" required density="compact"
                class="ml-5 textWhite"></v-text-field>
              <v-card-title class="textYellow">電話號碼</v-card-title>
              <v-text-field density="compact" v-model="phoneNumber" variant="underlined" required
                class="ml-5 textWhite"></v-text-field>
              <v-card-title class="textYellow">E-mail</v-card-title>
              <v-text-field density="compact" v-model="email" variant="underlined" readonly
                class="mb-5 ml-5 textWhite"></v-text-field>
              <p class="ml-3" style="color:white">已選擇的送貨方式：{{ selectedData.shipMethod.label }}</p>
              <v-checkbox v-model="fillRecipient" @input="handleFillRecipient" label="收件人資料與顧客資料相同"></v-checkbox>
            </v-card>
          </v-col>

          <v-col cols="6"><v-card class="mt-3 mySheet" height="600">
              <v-card-title>✨收件人資料</v-card-title>
              <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>

              <v-card-title class="textYellow">收件人名稱</v-card-title>
              <v-text-field density="compact" v-model="buyerName" :rules="[commonRules.required]" hide-details="auto"
                variant="underlined" required class="ml-5 textWhite"></v-text-field>
              <v-card-subtitle class="mb-5" style="color:grey">請填入收件人真實姓名，以確保順利收件</v-card-subtitle>
              <v-card-title class="textYellow">收件人電話號碼</v-card-title>
              <v-text-field density="compact" v-model="buyerPhone" :rules="[commonRules.required]" hide-details="auto"
                variant="underlined" required class="mb-5 ml-5 textWhite"></v-text-field>
              <v-card-title class="textYellow">E-mail</v-card-title>
              <v-text-field density="compact" v-model="buyerEmail" :rules="[commonRules.required, commonRules.email]"
                hide-details="auto" variant="underlined" required class="ml-5 textWhite"></v-text-field>
              <div v-if="selectedData.shipMethod.id == 1 ||
                selectedData.shipMethod.id == 2
                ">
                <p class="mb-5 mt-5 ml-3 textYellow">
                  <img src="https://localhost:7081/Files/Uploads/seven-eleven.png" width="30" />
                  選擇門市
                </p>
                <div v-if="singleSpot && singleSpot.storeNumber" class="mb-5 ml-5 mb-3">
                  <p style="color:white">門市編號：{{ singleSpot.storeNumber }}</p>
                  <p style="color:white">門市名稱：{{ singleSpot.storeName }}</p>
                  <p style="color:white">門市地址：{{ singleSpot.address }}</p>
                </div>
                <v-row justify="center" class="mb-3">
                  <v-dialog v-model="dialog" persistent width="auto">
                    <template v-slot:activator="{ props }">
                      <v-btn class="myBtn" v-bind="props"> 搜尋門市 </v-btn>
                    </template>
                    <v-card width="750" height="600" class="mySheet justify-center ml-3">
                      <v-card-title class="text-center" style="font-size: 26px;">✨7-11 門市選擇</v-card-title>
                      <v-divider class="border-opacity-75 mb-2 w-75 mx-auto" color="#f9ee08"></v-divider>
                      <v-row class="d-flex">
                        <v-col cols="10" class="d-flex">
                          <v-card-title>以路名查詢：</v-card-title>
                          <v-text-field v-model="keyword" single-line variant="underline" class="align-center"
                            style="background-colorr:#01010f;color:white" label="請輸入道路名稱"
                            density="compact"></v-text-field>
                        </v-col>
                        <v-col cols="10" class="d-flex">
                          <v-card-title>以門市查詢：</v-card-title>
                          <v-text-field v-model="branch" single-line variant="underline" class="align-center"
                            style="background-colorr:#01010f;color:white" label="請輸入門市名稱"
                            density="compact"></v-text-field>
                        </v-col>
                        <v-col cols="12" class="d-flex">
                          <v-card-title>以縣市查詢：</v-card-title>
                          <v-select v-model="city" :items="cityList" item-value="item" return-object single-line
                            theme="dark" style="background-colorr:#01010f;color:white" density="compact"
                            class="align-center"></v-select>
                          <v-spacer></v-spacer>
                          <v-btn class="myBtn mr-6 mb-3" @click="spotSearch">搜尋</v-btn>
                        </v-col>
                        <v-col cols="11" class="d-flex">
                          <v-card-title>請選擇門市：</v-card-title>
                          <v-select v-if="spotList && spotList.length" v-model="spot" :items="spotList"
                            :item-title="displayItem" item-value="id" single-line theme="dark"
                            style="background-colorr:#01010f;color:white" label="---" density="compact"
                            class="align-center" :rules="[commonRules.required]" required></v-select>
                        </v-col>
                      </v-row>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn class="myBtn mb-3" @click="dialog = false">
                          取消
                        </v-btn>
                        <v-btn class="myBtn mr-5 mb-3" @click="spotHandler(spot)">
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
              <div v-else-if="selectedData.shipMethod.id == 8
                ">
              </div>

              <p v-else>
                <v-card-title>地址</v-card-title>
                <v-text-field v-model="address" density="compact" :rules="[commonRules.required]" hide-details="auto"
                  variant="solo" required></v-text-field>
              </p>
            </v-card>
          </v-col>
        </v-row>
        <div class="d-flex mt-5">
          <v-btn class="me-auto myBtn" @click="toEcommerce">繼續購物</v-btn>
          <form ref="ecpayForm" action="https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5" method="POST">
            <input type="hidden" v-for="(value, key) in ecPayparams" :key="key" :name="key" :value="value" />
            <v-btn @click.prevent="handleSubmit" class="myBtn">送出訂單</v-btn>
          </form>
        </div>
      </v-container>
    </v-form>
  </div>
</template>
    
<script setup>
import { ref, defineProps, computed, watch } from "vue";
import Payment from "@/components/Cart/Payment.vue";
import { useRoute, useRouter } from "vue-router";
import { useStore } from "vuex";
import Swal from 'sweetalert2';

const store = useStore();
const router = useRouter();
const route = useRoute();
const form = ref(null);
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
const memberId = ref();
const address = ref("");
const createOrderItemCommandList = [];

const toEcommerce = () => {
  router.push({
    name: "eCommerce",
  });
}

const unitExchange = (x) => {
  return 'NT$ ' + x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

const commonRules = {
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
  memberId.value = datas.id;
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


const checkoutLinePay = async (CreatePaymentRequestDto) => {
  const response = await fetch(`https://localhost:7081/api/LinePay/Create`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    credentials: "include",
    body: JSON.stringify(CreatePaymentRequestDto),  //todo  ShipmentMethodDto
  });
  if (response.ok) {
    const data = await response.json();
    sessionStorage.setItem("totalAmount", props.selectedData.totalAmount);
    window.location = data.info.paymentUrl.web;
  } else {
    console.log(response);
  }
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

const handleSubmit = async () => {
  if (address.value) {
    createOrderCommand.value.toAddress = address;
  }
  const valid = await form.value.validate();
  if (valid.valid) {
    createOrderCommand.value.ShipmentMethodId = props.selectedData.shipMethod.id;
    createOrderCommand.value.PaymentStatusId =
      props.selectedData.shipMethod.id == 2 || 4 || 6 ? 2 : null;  //純取貨 => 已付款
    createOrderCommand.value.RecipientName = buyerName;
    createOrderCommand.value.ReceiverEmail = buyerEmail;
    createOrderCommand.value.ReceiverCellPhone = buyerPhone;
    createOrderCommand.value.ShippingFee = props.selectedData.freight;
    try {
      const orderResult = await createOrder();

      if (props.selectedData.payment.id == 2) {
        await checkoutECPay();
        ecpayForm.value.submit();

      } else if (props.selectedData.payment.id == 1) {

        const CreatePaymentRequestDto = {
          OrderIndex: orderResult[0].orderIndex,
          shipmentMethod: props.selectedData.shipMethod.method
        };
        console.log(CreatePaymentRequestDto.OrderIndex);
        await checkoutLinePay(CreatePaymentRequestDto);

      } else {
        router.push({ name: "Cart", query: { paymentSuccess: "true" } });
      }
      //如果金流Response失敗不刪除
      await store.dispatch('deleteCartsByMemberId', memberId.value);

      if (props.selectedData.shipMethod.method != ("gameCode" || "oversea")) {
        payload.value.MerchantTradeNo = orderResult[0].orderIndex;
        payload.value.OrderId = orderResult[0].orderId;
        await createLogisticsOrder(payload.value);
      }
    } catch (error) {
      console.error("Error:", error);
    }
  } else {
    Swal.fire('', '未完整填寫收件人資訊', 'warning');
  }
};

load();
</script>
    
<style scoped>
.myComment {
  background-color: #01010f;
  color: white
}

.mySheet {
  width: 100%;
  background-color: #01010f;
  color: #a1dfe9;
  font-size: 16px
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

.myPanel {
  font-size: 18px;
}

.textWhite {
  color: white;
}

.tdPlatform {
  width: 120px !important;
}

.tdImg {
  width: 250px !important
}
</style>