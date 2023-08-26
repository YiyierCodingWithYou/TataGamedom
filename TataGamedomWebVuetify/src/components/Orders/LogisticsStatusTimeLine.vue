<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-theme-provider theme="dark" with-background class="pa-10">
      <div class="text-h6">
        <div>物流訂單編號: {{ logisticsTradeInfoData.merchantTradeNo }}</div>
        <div>
          狀態:
          {{ logisticsTradeInfoData.logisticsStatus == 300 ? "處理中" : "" }}
        </div>
        <div>
          寄送方式:
          {{
            logisticsTradeInfoData.logisticsType == "CVS_UNIMART"
              ? "7-11取貨"
              : ""
          }}
        </div>
        <div v-if="logisticsTradeInfoData.shipmentNo">
          配送編號(B2C): {{ logisticsTradeInfoData.shipmentNo }}
        </div>
        <div v-if="logisticsTradeInfoData.bookingNote">
          託運單號(宅配): {{ logisticsTradeInfoData.bookingNote }}
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
            <strong class="me-4">{{
              relativeTime(logisticsTradeInfoData.tradeDate)
            }}</strong>
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
            <div class="text-h6">出貨</div>
          </div>
        </v-timeline-item>

        <v-timeline-item>
          <template v-slot:opposite>
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
import { ref, onMounted, computed } from "vue";
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
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
    const order = computed(() => store.getters.getOrderById(props.orderId));
    const dialog = ref(false);
    const MerchantTradeNo = order.value.orderIndex;
    const logisticsTradeInfo = ref({});
    const logisticsTradeInfoData = ref({});

    const fetchLogisticsTradeInfo = async () => {
      try {
        logisticsTradeInfo.value = await store.dispatch(
          "getLogisticsTradeInfo",
          { MerchantTradeNo }
        );
        logisticsTradeInfoData.value = logisticsTradeInfo.value.decodedData;
        console.log(
          "綠界物流查詢:",
          "查詢用訂單編號: " + MerchantTradeNo,
          "傳回結果:" + logisticsTradeInfoData.value.rtnMsg
        );
      } catch (error) {
        console.error("Failed to fetch logistics trade info:", error);
      }
    };

    const relativeTime = (datetime) => {
      const date = new Date(datetime);
      return format(date, "yyyy/MM/dd HH:mm", { locale: zhTW });
    };

    onMounted(() => {
      fetchLogisticsTradeInfo();
    });

    return {
      dialog,
      order,
      logisticsTradeInfo,
      logisticsTradeInfoData,
      relativeTime,
    };
  },
};
</script>