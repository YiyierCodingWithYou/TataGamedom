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
                <td class="text-end">總計：</td>
                <td class="text-end">NT${{ cartData.total }}</td>
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
        <v-col cols="6">
          <v-card class="mt-3">
            <v-card-title class="d-flex"
              >送貨資料
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
    </v-container>
  </v-form>
</template>
    
<script setup>
import { ref } from "vue";

const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";
const count = ref(0);
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
  count.value = datas.cartItems.length;
};

loadData();
</script>
    
<style>
</style>