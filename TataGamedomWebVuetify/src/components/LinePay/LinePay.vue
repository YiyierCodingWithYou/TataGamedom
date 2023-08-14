<template>
  <div>
    <div class="centered">
      <table>
        <thead>
          <tr>
            <th>測試商品</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <img
                src="https://static.accupass.com/org/2011051025162614811630.jpg"
              />
            </td>
          </tr>
          <tr>
            <td>價格 : 1999</td>
          </tr>
          <tr>
            <td>購買數量 : 2</td>
          </tr>
          <tr>
            <td style="text-align: right">總金額 : 3998</td>
          </tr>
          <tr>
            <td><v-btn @click="requestPayment">Line Pay 付款</v-btn></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
  
  <script>
export default {
  name: "PaymentComponent",
  data() {
    return {
      baseLoginPayUrl: "https://localhost:7081/api/LinePay/",
    };
  },
  methods: {
    async requestPayment() {
      const payment = {
        amount: 100,
        currency: "TWD",
        orderId: "MKSI_S_20180904_1000001",
        packages: [
          {
            id: "1",
            amount: 100,
            Name: "test",
            products: [
              {
                id: "PEN-B-001",
                name: "Pen Brown",
                imageUrl: "https://pay-store.line.com/images/pen_brown.jpg",
                quantity: 2,
                price: 50,
              },
            ],
          },
        ],
        redirectUrls: {
          confirmUrl: "https://localhost:3000/LinePayConfirmPayment",
          cancelUrl: "",
        },
      };

      try {
        const response = await fetch(this.baseLoginPayUrl + "Create", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(payment),
        });

        if (response.ok) {
          const data = await response.json();
          window.location = data.info.paymentUrl.web;
        }
      } catch (error) {
        console.log(error);
      }
    },
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
  