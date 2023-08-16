<template>
  <v-expansion-panels>
    <v-expansion-panel>
      <v-expansion-panel-title
        >合計：NT${{ cartData.total }}<br />購物車（{{
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
                <td class="text-end">運費：<br>總計：</td>
                <td class="text-end">
                  NT${{ selectedData.freight }}<br>NT${{ selectedData
.totalAmount }}</td>
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
              v-model="firstname"
              variant="solo"
              required
            ></v-text-field>
            <v-card-subtitle>電話號碼</v-card-subtitle>
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
      <v-btn @click="checkout">送出訂單</v-btn>
      <Payment :paymentData="getLinePayData" />
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
  selectedData: Object
});

watch(props, (newProps) => {
  if (newProps) {
    console.log(newProps);
  }
});

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

const getLinePayData = computed(() => {
  return {
    amount: total.value,
    currency: "TWD",
    packages: [
      //object
    ],
    redirectUrls: {
      confirmUrl: "https://localhost:3000/LinePayConfirmPayment",
      cancelUrl: "",
    },
  };
});

loadData();
</script>
    
<style>
</style>