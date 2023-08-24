<template>
  <v-btn @click="handleClick">Test Logistics Selection</v-btn>
</template>

<script>
import { ref } from "vue";
import { useStore } from "vuex";

export default {
  name: "RedirectToLogisticsSelection_Url",

  setup() {
    const store = useStore();

    const handleClick = async () => {
      try {
        const payload = {
          goodsAmount: 100,
          receiverAddress: "桃園市中壢區新生路二段421號",
          receiverCellPhone: "0916224867",
          receiverName: "lisi",
        };
        await store.dispatch("navigateToLogisticsSelection", payload);
      } catch (error) {
        console.error("Error calling navigateToLogisticsSelection:", error);
      }
    };

    return {
      handleClick,
    };
  },
};
</script>
