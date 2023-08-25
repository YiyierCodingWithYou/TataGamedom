<template>
  <div>
    <table>
      <thead>
        <tr>
          <th colspan="2">測試商品</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td colspan="2">
            <img src="https://static.accupass.com/org/2011051025162614811630.jpg" />
          </td>
        </tr>
        <tr>
          <td colspan="2">價格 : 1999</td>
        </tr>
        <tr>
          <td colspan="2">購買數量 : 2</td>
        </tr>
        <tr>
          <td colspan="2" style="text-align: right">總金額 : 3998</td>
        </tr>
        <tr>
          <td colspan="2">
            <button @click="confirmPayment">確認付款</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="Container">
      <a> 交易狀態 : {{ paymentStatus }} </a>
    </div>
  </div>
</template>
  
<script>
import { ref, onMounted } from "vue";

export default {
  setup() {
    const baseLoginPayUrl = "https://localhost:7081/api/LinePay/";
    const paymentStatus = ref("交易已授權，等待確認");
    let transactionId = "";
    let orderId = "";

    onMounted(() => {
      const params = new URLSearchParams(window.location.search);
      transactionId = params.get("transactionId");
      orderId = params.get("orderId");
    });

    const confirmPayment = async () => {
      const payment = {
        amount: 5850,  
        currency: "TWD",
      };

      try {
        const response = await fetch(
          `${baseLoginPayUrl}Confirm?transactionId=${transactionId}&orderId=${orderId}`,
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(payment),
          }
        );

        if (response.ok) {
          paymentStatus.value = "交易狀態 : 成功";
          setTimeout(() => {
            window.location = "https://localhost:3000/Cart?paymentSuccess=true";
          }, 2000);
        } else {
          console.error("Failed to confirm payment");
        }
      } catch (error) {
        console.error(error);
      }
    };

    return {
      paymentStatus,
      confirmPayment,
    };
  },
};
</script>

<style scoped>
.centered {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}
</style>