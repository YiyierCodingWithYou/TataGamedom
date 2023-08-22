<template>
    <v-dialog v-model="dialog" activator="parent" width="auto">
        <v-theme-provider theme="dark" with-background class="pa-10">
            <v-timeline direction="horizontal">
                <v-timeline-item>
                    <template v-slot:opposite>
                        Opposite content
                    </template>
                    <div>
                        <div class="text-h6">交易編號: {{ logisticsTradeInfoData.merchantTradeNo }}</div>
                        <div class="text-h6">狀態: {{ logisticsTradeInfoData.logisticsStatus }}</div>
                        <div class="text-h6">方式: {{ logisticsTradeInfoData.logisticsType }}</div>
                        <div class="text-h6">物流費用: {{ logisticsTradeInfoData.handlingCharge }}</div>
                        <div class="text-h6">物流訂單成立日期: {{ logisticsTradeInfoData.tradeDate }}</div>
                        <div class="text-h6">配送編號(B2C): {{ logisticsTradeInfoData.shipmentNo }}</div>
                        <div class="text-h6">託運單號(宅配): {{ logisticsTradeInfoData.bookingNote }}</div>
                        <div class="text-h6">寄貨編號(C2C): {{ logisticsTradeInfoData.cvsPaymentNo }}</div>
                        <div class="text-h6">7-11驗證碼(C2C): {{ logisticsTradeInfoData.cvsValidationNo }}</div>
                        <div class="text-h6">7-11交貨便代碼(C2C): {{ logisticsTradeInfoData.cvsPaymentNo
                        }}{{ logisticsTradeInfoData.cvsValidationNo }}</div>

                    </div>
                </v-timeline-item>

                <v-timeline-item>
                    <template v-slot:opposite>
                        Opposite content
                    </template>
                    <div>
                        <div class="text-h6">Content title</div>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
                            labore
                            et
                            dolore magna aliqua.
                        </p>
                    </div>
                </v-timeline-item>

                <v-timeline-item>
                    <template v-slot:opposite>
                        Opposite content
                    </template>
                    <div>
                        <div class="text-h6">Content title</div>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
                            labore
                            et
                            dolore magna aliqua.
                        </p>
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
                logisticsTradeInfo.value = await store.dispatch("getLogisticsTradeInfo", { MerchantTradeNo });
                logisticsTradeInfoData.value = logisticsTradeInfo.value.decodedData;
                console.log("logisticsTradeInfo:", logisticsTradeInfo.value);
            } catch (error) {
                console.error("Failed to fetch logistics trade info:", error);
            }
        }

        onMounted(() => {
            fetchLogisticsTradeInfo();
        });

        return {
            dialog,
            logisticsTradeInfo,
            logisticsTradeInfoData
        };
    },
};
</script>