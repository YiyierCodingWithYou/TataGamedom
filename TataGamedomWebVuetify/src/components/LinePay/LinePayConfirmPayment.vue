<script>
import { ref, onMounted } from "vue";

export default {
  setup() {
    const baseLoginPayUrl = "https://localhost:7081/api/LinePay/";
    let transactionId = "";
    let orderId = "";

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

    onMounted(() => {
      const params = new URLSearchParams(window.location.search);
      transactionId = params.get("transactionId");
      orderId = params.get("orderId");

      confirmPayment();
    });

    return {
      paymentStatus,
    };
  },
};
</script>
