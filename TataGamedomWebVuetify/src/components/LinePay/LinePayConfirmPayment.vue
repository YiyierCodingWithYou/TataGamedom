<template>
  <div>
    <p v-if="errorMessage">{{ errorMessage }}</p>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import axios from "axios";

export default {
  setup() {
    const totalAmount = sessionStorage.getItem("totalAmount");
    const baseLinePayUrl = "https://localhost:7081/api/LinePay/";
    let transactionId = "";
    const errorMessage = ref("");

    const confirmPayment = async () => {
      const payment = {
        amount: totalAmount,
        currency: "TWD",
      };

      const response = await axios.post(
        `${baseLinePayUrl}Confirm?transactionId=${transactionId}`,
        payment,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (response.data.returnCode === '0000') {
        window.location = "https://localhost:3000/Cart?paymentSuccess=true";
      }
      else {
        errorMessage.value = "交易驗證失敗，原因:" + response.data.returnMessage;
      }
    };

    onMounted(() => {
      const params = new URLSearchParams(window.location.search);
      transactionId = params.get("transactionId");
      confirmPayment();
    });

    return { errorMessage };
  },
};
</script>
