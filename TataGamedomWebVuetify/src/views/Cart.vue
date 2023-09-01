<template>
  
    <v-container>
      <v-tabs v-model="tab" color="#a1dfe9" align-tabs="center">
        <v-tab v-for="item in flows" :key="item" :value="item" :disabled="disabledTabs[item]">
          {{ item }}
        </v-tab>
      </v-tabs>
      <v-window v-model="tab">
        <v-window-item value="購物車">
          <CartItem @getreturnSelected="returnSelectedHandler"></CartItem>
        </v-window-item>
        <v-window-item value="填寫資料">
          <Information v-if="selectedData !== undefined" :selectedData="selectedData"></Information>
        </v-window-item>
        <v-window-item value="訂單確認">
          <OrderConfirmation></OrderConfirmation>
        </v-window-item>
      </v-window>
    </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import CartItem from "@/components/Cart/CartItem.vue";
import Information from "@/components/Cart/Information.vue";
import OrderConfirmation from "@/components/Cart/Order-confirmation.vue";

const tab = ref("購物車");
const flows = ["購物車", "填寫資料", "訂單確認"];
const selectedData = ref({});
const disabledTabs = ref({
  購物車: false,
  填寫資料: true,
  訂單確認: true,
});

const returnSelectedHandler = (data: object) => {
  selectedData.value = data;
  tab.value = "填寫資料";
  disabledTabs.value["填寫資料"] = false;
  //console.log(selectedData.value);
};

const handlePaymentComplete = () => {
  const urlParams = new URLSearchParams(window.location.search);
  const paymentSuccess = urlParams.get("paymentSuccess");

  if (paymentSuccess === "true") {
    tab.value = "訂單確認";
    disabledTabs.value["填寫資料"] = true;
    disabledTabs.value["訂單確認"] = false;
  }
};

onMounted(() => {
  handlePaymentComplete();
});
</script>

<style>
.v-container {
  max-width: 90% !important;
}
</style>