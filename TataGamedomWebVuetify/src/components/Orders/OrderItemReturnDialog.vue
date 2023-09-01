<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-spacer></v-spacer>

    <v-sheet width="1200" class="mx-auto">
      <v-btn class="ma-12" variant="text" icon="mdi-package-variant-closed-remove" color="blue-grey-darken-2"
        size="x-large" v-if="orderItemReturnList">
        退款紀錄查詢
        <v-icon size="x-large">
          {{ "mdi-package-variant-closed-remove" }}
        </v-icon>
        <RefundRecordList activator="parent" width="auto" :orderItemReturnList="orderItemReturnList" />
      </v-btn>

      <v-form validate-on="submit lazy" @submit.prevent="submit">
        <div class="d-flex pa-4 justify-center">
          <v-checkbox v-model="selectAll" label="全選/取消" :disabled="!isOrderCompleted"
            :indeterminate="!isOrderCompleted"></v-checkbox>
          <p v-show="!isOrderCompleted" class="font-weight-medium">
            *訂單未完成，無法執行退貨操作
          </p>
        </div>
        <v-card v-for="orderDetail in orderDetails" :key="orderDetail.id">
          <v-card-text>
            <div class="d-flex pa-4">
              <v-checkbox-btn v-model="orderDetail.enabled" class="pe-2"
                :disabled="!isOrderCompleted || isItemReturned(orderDetail.id)" :indeterminate="!isOrderCompleted">
              </v-checkbox-btn>
              <v-chip class="ma-5" color="pink" v-show="isItemReturned(orderDetail.id)"><v-icon start
                  icon="mdi-tag-off"></v-icon>已退貨</v-chip>
              <v-text-field readonly hide-details label="" variant="underlined" class="flex-grow-1">
                {{ orderDetail.index }}
                {{ orderDetail.gameChiName }}
                {{ orderDetail.productIsVirtual ? "(序號)" : "(遊戲片)" }}
              </v-text-field>
            </div>

            <v-textarea v-model="orderDetail.reason" :disabled="!orderDetail.enabled" clearable counter label="原因"
              maxlength="200" single-line></v-textarea>
          </v-card-text>
        </v-card>

        <v-spacer></v-spacer>
        <v-btn block class="mt-2" text="取消" @click.stop="closeDialog"></v-btn>
        <v-btn :loading="loading" block class="mt-2" text="送出" type="submit"></v-btn>
      </v-form>
    </v-sheet>
  </v-dialog>
</template>


<script>
import { ref, computed, onMounted, watch } from "vue";
import { useStore } from "vuex";
import RefundRecordList from "./RefundRecordList.vue";

export default {
  name: "OrderItemReturn",
  props: {
    orderId: {
      type: Number,
      required: true,
    },
  },
  components: {
    RefundRecordList,
  },
  setup(props) {
    const store = useStore();
    const order = computed(() => store.getters.getOrderById(props.orderId));
    const orderDetails = computed(() => {
      return store.getters.getOrderDetailsById(props.orderId);
    });

    //dialog
    const dialog = ref(false);
    const closeDialog = () => {
      dialog.value = false;
    };

    //Checkbox
    const hasOrderDetails = computed(
      () => orderDetails.value && orderDetails.value.length > 0
    );

    const initializeCheckBox = () => {
      orderDetails.value.forEach((detail) => {
        detail.enabled = false;
      });
    };

    const isOrderCompleted = computed(() => {
      return (
        order.value &&
        (order.value.orderStatusCodeName === "已完成" ||
          order.value.orderStatusCodeName === "退貨程序處理中")
      );
    });

    // 取得退貨表單 & 判斷是否已退貨
    const orderItemReturnList = computed(() => {
      return store.getters.getorderItemReturnList(props.orderId);
    });

    onMounted(() => {
      if (hasOrderDetails.value) {
        initializeCheckBox();
      }
      store.dispatch("fetchorderItemReturnList", props.orderId);
    });

    const isItemReturned = (orderItemId) => {
      return orderItemReturnList.value.some(
        (item) => item.orderItemId === orderItemId
      );
    };

    const selectAll = ref(false);
    watch(selectAll, (newValue) => {
      if (hasOrderDetails.value) {
        orderDetails.value.forEach((detail) => {
          if (!isItemReturned(detail.id)) detail.enabled = newValue;
        });
      }
    });

    //HttpPost + lazy loading
    const loading = ref(false);

    const createOrderItemReturnCommandList = ref([]);
    const submit = async () => {
      loading.value = true;

      createOrderItemReturnCommandList.value = orderDetails.value
        .filter((detail) => detail.enabled)
        .map((detail) => ({
          orderItemId: detail.id,
          reason: detail.reason,
        }));

      const requestData = {
        createOrderItemReturnCommandList:
          createOrderItemReturnCommandList.value,
      };
      const payload = {
        requestData: requestData,
        orderId: props.orderId,
      };

      const timeoutPromise = new Promise((resolve) =>
        setTimeout(resolve, 1000)
      );

      try {
        console.log(requestData);
        await Promise.all([
          store.dispatch("postOrderItemReturns", payload),
          timeoutPromise,
        ]);
      } catch (error) {
        console.error("錯誤:", error);
      } finally {
        loading.value = false;
        dialog.value = false;
        initializeCheckBox();
      }
    };

    return {
      order,
      orderDetails,
      orderItemReturnList,
      dialog,
      selectAll,
      loading,
      isOrderCompleted,
      submit,
      closeDialog,
      isItemReturned,
      initializeCheckBox,
    };
  },
};
</script> 
