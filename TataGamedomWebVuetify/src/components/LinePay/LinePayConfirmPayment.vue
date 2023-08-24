<script>
import { ref, onMounted } from "vue";

export default {
  setup() {
    const totalAmount = sessionStorage.getItem("totalAmount");
    const baseLoginPayUrl = "https://localhost:7081/api/LinePay/";
    let transactionId = "";
    let orderId = "";

    const confirmPayment = async () => {
      const payment = {
        amount: totalAmount,
        currency: "TWD",
      };

      try {
        const response = await fetch(
          `${baseLoginPayUrl}Confirm?transactionId=${transactionId}`,
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(payment),
          }
        );

        if (response.ok) {
          setTimeout(() => {
            window.location = "https://localhost:3000/Cart?paymentSuccess=true";
          });
        } else {
          console.error("Failed to confirm payment" + response);
        }
      } catch (error) {
        console.error(error);
      }
    };

    onMounted(() => {
      console.log(totalAmount);
      const params = new URLSearchParams(window.location.search);
      transactionId = params.get("transactionId");
      confirmPayment();
    });
  },
};
</script>
