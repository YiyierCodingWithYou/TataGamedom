<template>
  <v-expansion-panels v-if="cartData.allowCheckout">
    <v-expansion-panel>
      <v-expansion-panel-title
        >合計：NT${{ selectedData.totalAmount }}<br />購物車（{{
          count
        }}件）</v-expansion-panel-title
      >
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
                <td class="text-end">
                  {{ item.qty }}
                </td>
                <td class="text-end" v-text="item.subTotal"></td>
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
  <v-form v-model="order" v-if="cartData.allowCheckout">
    <v-container>
      <v-row>
        <v-col cols="6">
          <v-card class="mt-3">
            <v-card-title>✨顧客資料</v-card-title>
            <v-divider></v-divider>
            <v-card-title>姓名</v-card-title>
            <v-text-field
              v-model="name"
              variant="solo"
              required
              density="compact"
            ></v-text-field>
            <v-card-title>電話號碼</v-card-title>
            <v-text-field
              density="compact"
              v-model="phoneNumber"
              variant="solo"
              required
            ></v-text-field>
            <v-card-title>E-mail</v-card-title>
            <v-text-field
              density="compact"
              v-model="email"
              variant="solo"
              readonly
              class="mb-5"
            ></v-text-field>
          </v-card>
        </v-col>

        <v-col cols="6"
          ><v-card class="mt-3">
            <v-card-title>✨收件人資料</v-card-title>
            <v-divider></v-divider>
            <p>已選擇的送貨方式：{{ selectedData.shipMethod.label }}</p>
            <v-checkbox
              v-model="fillRecipient"
              @input="handleFillRecipient"
              label="收件人資料與顧客資料相同"
            ></v-checkbox>
            <v-card-subtitle>收件人名稱</v-card-subtitle>
            <v-text-field
              density="compact"
              v-model="buyerName"
              hide-details="auto"
              variant="solo"
              required
            ></v-text-field>
            <v-card-subtitle class="mb-5"
              >請填入收件人真實姓名，以確保順利收件</v-card-subtitle
            >
            <v-card-subtitle>收件人電話號碼</v-card-subtitle>
            <v-text-field
              density="compact"
              v-model="buyerPhone"
              :rules="[rules.required]"
              hide-details="auto"
              variant="solo"
              required
              class="mb-5"
            ></v-text-field>
            <v-card-subtitle>E-mail</v-card-subtitle>
            <v-text-field
              density="compact"
              v-model="buyerEmail"
              :rules="[rules.required, rules.email]"
              hide-details="auto"
              variant="solo"
              required
            ></v-text-field>
            <v-divider></v-divider>
            <div
              v-if="
                selectedData.shipMethod.id == 1 ||
                selectedData.shipMethod.id == 2
              "
            >
              <p>
                <img
                  src="https://localhost:7081/Files/Uploads/seven-eleven.png"
                  width="30"
                />
                選擇門市
              </p>
              <div class="d-flex justify-center">
                <v-btn width="300" color="primary" @click="chooseShop"
                  >搜尋門市</v-btn
                >
              </div>
            </div>
            <div
              v-else-if="
                selectedData.shipMethod.id == 3 ||
                selectedData.shipMethod.id == 4
              "
            >
              <p>
                <img
                  src="https://localhost:7081/Files/Uploads/family_mart.jpg"
                  width="30"
                />
                選擇門市
              </p>
              <div class="d-flex justify-center">
                <v-btn width="300" color="primary" @click="chooseShop"
                  >搜尋門市</v-btn
                >
              </div>
            </div>

            <p v-else>
              <v-card-title>地址</v-card-title>
              <v-text-field
                density="compact"
                :rules="[rules.required]"
                hide-details="auto"
                variant="solo"
                required
              ></v-text-field>
            </p>
          </v-card>
        </v-col>
      </v-row>

      <form
        ref="ecpayForm"
        action="https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5"
        method="POST"
      >
        <input
          type="hidden"
          v-for="(value, key) in ecPayparams"
          :key="key"
          :name="key"
          :value="value"
        />
        <v-btn @click.prevent="handleSubmit">送出訂單</v-btn>
      </form>
    </v-container>
  </v-form>
</template>
    
<script setup>
import { ref, defineProps, computed, watch } from "vue";
import Payment from "@/components/Cart/Payment.vue";

const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const count = ref(0);
const total = ref(0);
const member = ref({});
const name = ref("");
const email = ref("");
const phoneNumber = ref("");
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
const rules = {
  required: (value) => !!value || "此欄位必填",
  email: (value) => {
    const pattern =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return pattern.test(value) || "E-mail格式不正確";
  },
};

const handleFillRecipient = () => {
  console.log(fillRecipient.value);
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
  count.value = datas.cartItems.length;
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
  console.log(member.value);
};

const chooseShop = async () => {
  const response = await fetch("https://emap.pcsc.com.tw/ecmap/default.aspx", {
    method: "POST",
    mode: "no-cors",
    body: {
      esshopid: "112",
      servicetype: "1",
      url: "https://localhost:3000/",
    },
  });
};

// const createOrder = async () => {
//   const response = await fetch(`https://localhost:7081/api/Orders`, {
//     method: "POST",
//     credentials: "include",
//     headers: {
//       "Content-Type": "application/json",
//     },
//     body: {
//
//     },
//   });
// };

const checkout = async () => {
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
const handleSubmit = async () => {
  //await createOrder();
  await checkout();
  ecpayForm.value.submit();
};
loadData();
getMember();
</script>
    
<style>
</style>