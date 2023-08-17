<template>
  <v-expansion-panels>
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
                <td>已享用優惠༼ つ ◕_◕ ༽つ</td>
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
  <v-form v-model="valid">
    <v-container>
      <v-row>
        <v-col cols="6">
          <v-card class="mt-3">
            <v-card-title>顧客資料</v-card-title>
            <hr />
            <v-card-subtitle>姓名</v-card-subtitle>
            <v-text-field
              v-model="buyerName"
              variant="solo"
              required
            ></v-text-field>
            <v-card-subtitle>電話號碼</v-card-subtitle>
            <v-text-field
              v-model="phoneNumber"
              variant="solo"
              required
            ></v-text-field>
            <v-card-subtitle>E-mail</v-card-subtitle>
            <v-text-field
              v-model="email"
              :rules="emailRules"
              variant="solo"
              required
            ></v-text-field>
          </v-card>
        </v-col>

        <v-col cols="6"
          ><v-card class="mt-3">
            <v-card-title>收件人資料</v-card-title>
            <!-- 加個btn可以一鍵帶入顧客資料 -->
            <hr />
            <v-card-subtitle>收件人名稱</v-card-subtitle>
            <v-text-field
              v-model="firstname"
              variant="solo"
              required
            ></v-text-field>
            <v-card-subtitle>收件人電話號碼</v-card-subtitle>
            <v-text-field
              v-model="firstname"
              variant="solo"
              required
            ></v-text-field>
            <v-card-subtitle>E-mail</v-card-subtitle>
            <v-text-field
              v-model="email"
              :rules="emailRules"
              variant="solo"
              required
            ></v-text-field>
          </v-card>
        </v-col>
        <v-col cols="6"> </v-col>

        <v-col cols="6"> </v-col>
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
const props = defineProps({
  selectedData: Object,
});

const ecpayForm = ref(null);
const ecPayparams = ref({});

// watch(props, (newProps) => {
//   if (newProps) {
//     console.log(newProps);
//   }
// });

const productId = ref();
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
    console.log(ecPayparams.value);
  } catch (error) {
    console.log("Error:", error);
  }
};
const handleSubmit = async () => {
  await checkout();
  ecpayForm.value.submit();
};

loadData();
</script>
    
<style>
</style>