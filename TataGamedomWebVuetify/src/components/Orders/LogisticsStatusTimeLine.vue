<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-theme-provider theme="dark" with-background class="pa-10">
      <div class="text-h6">
        <div>交易編號: {{ logisticsTradeInfoData.merchantTradeNo }}</div>
        <!-- OrderIndex -->
        <div>狀態: {{ logisticsTradeInfoData.logisticsStatus }}</div>
        <div>方式: {{ logisticsTradeInfoData.logisticsType }}</div>
        <div>物流費用: {{ logisticsTradeInfoData.handlingCharge }}</div>
        <div>配送編號(B2C): {{ logisticsTradeInfoData.shipmentNo }}</div>
        <div>託運單號(宅配): {{ logisticsTradeInfoData.bookingNote }}</div>
        <div>寄貨編號(C2C): {{ logisticsTradeInfoData.cvsPaymentNo }}</div>
        <div>7-11驗證碼(C2C): {{ logisticsTradeInfoData.cvsValidationNo }}</div>
        <div>
          7-11交貨便代碼(C2C):{{ logisticsTradeInfoData.cvsPaymentNo
          }}{{ logisticsTradeInfoData.cvsValidationNo }}
        </div>
      </div>
      <v-divider
        :thickness="2"
        class="border-opacity-25 mb-10"
        color="success"
      ></v-divider>

      <v-timeline direction="horizontal">
        <v-timeline-item>
          <template v-slot:opposite>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
          </template>
          <div class="d-flex text-h6">
            <strong class="me-4">{{ logisticsTradeInfoData.tradeDate }}</strong>
            <div>
              <strong> 物流訂單成立</strong>
            </div>
          </div>
        </v-timeline-item>

        <v-timeline-item>
          <template v-slot:opposite>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
          </template>
          <div>
            <div class="text-h6">送達物流中心</div>
          </div>
        </v-timeline-item>

        <v-timeline-item>
          <template v-slot:opposite>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
          </template>
          <div>
            <div class="text-h6">出貨</div>
          </div>
        </v-timeline-item>

        <v-timeline-item>
          <template v-slot:opposite>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
          </template>
          <div>
            <div class="text-h6">送達超商門市</div>
          </div>
        </v-timeline-item>

        <v-timeline-item>
          <template v-slot:opposite>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
            <v-icon icon="mdi-pac-man" size="median"></v-icon>
          </template>
          <div>
            <div class="text-h6">取貨</div>
          </div>
        </v-timeline-item>
      </v-timeline>
    </v-theme-provider>
  </v-dialog>
</template>

<script>
import { ref, onMounted } from "vue";
import { useStore } from "vuex";

export default {
  name: "LogisticsStatusTimeLine",
  props: {
    orderId: {
      type: Number,
      required: true,
    },
  },
  setup(props) {
    const store = useStore();
    const dialog = ref(false);
    const MerchantTradeNo = "GW2308211940193466";
    const logisticsTradeInfo = ref({});
    const logisticsTradeInfoData = ref({});

    const fetchLogisticsTradeInfo = async () => {
      try {
        logisticsTradeInfo.value = await store.dispatch(
          "getLogisticsTradeInfo",
          { MerchantTradeNo }
        );
        logisticsTradeInfoData.value = logisticsTradeInfo.value.decodedData;
        console.log("logisticsTradeInfo:", logisticsTradeInfo.value);
      } catch (error) {
        console.error("Failed to fetch logistics trade info:", error);
      }
    };

    onMounted(() => {
      fetchLogisticsTradeInfo();
    });

    return {
      dialog,
      logisticsTradeInfo,
      logisticsTradeInfoData,
    };
  },
};
</script>