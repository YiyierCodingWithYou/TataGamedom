<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-spacer></v-spacer>
    <v-sheet width="1000" class="mx-auto">
      <v-form validate-on="submit lazy" @submit.prevent="submit">
        <div class="d-flex pa-4 justify-center">
          <v-checkbox
            v-model="selectAll"
            label="全選/取消"
            :disabled="!isOrderCompleted"
            :indeterminate="!isOrderCompleted"
          ></v-checkbox>
          <p v-show="!isOrderCompleted" class="font-weight-medium">
            *訂單未完成，無法執行退貨操作
          </p>
        </div>
        <v-card v-for="orderDetail in orderDetails" :key="orderDetail.id">
          <v-card-text>
            <div class="d-flex pa-4">
              <v-checkbox-btn
                v-model="orderDetail.enabled"
                class="pe-2"
                :disabled="
                  !isOrderCompleted || isIdInReturnList(orderDetail.id)
                "
                :indeterminate="!isOrderCompleted"
              >
              </v-checkbox-btn>
              <v-chip
                class="ma-5"
                color="pink"
                v-show="isIdInReturnList(orderDetail.id)"
                ><v-icon start icon="mdi-tag-off"></v-icon>已退貨</v-chip
              >
              <v-text-field
                readonly
                hide-details
                label=""
                variant="underlined"
                class="flex-grow-1"
              >
                {{ orderDetail.index }}
                {{ orderDetail.gameChiName }}
                {{ orderDetail.productIsVirtual ? "(序號)" : "(遊戲片)" }}
              </v-text-field>
            </div>

            <v-textarea
              v-model="orderDetail.reason"
              :disabled="!orderDetail.enabled"
              clearable
              counter
              label="原因"
              maxlength="200"
              single-line
            ></v-textarea>
          </v-card-text>
        </v-card>

        <v-spacer></v-spacer>
        <v-btn block class="mt-2" text="取消" @click.stop="closeDialog"></v-btn>
        <v-btn
          :loading="loading"
          block
          class="mt-2"
          text="送出"
          type="submit"
        ></v-btn>
        <!-- click -->
      </v-form>
    </v-sheet>
  </v-dialog>
</template>


<script>
import { ref, computed, onMounted, watch } from "vue";
import { useStore } from "vuex";

export default {
  name: "OrderItemReturn",
  props: {
    orderId: {
      type: Number,
      required: true,
    },
  },

  setup(props) {
    const store = useStore();
    const order = computed(() => store.getters.getOrderById(props.orderId));
    const orderDetails = computed(() => {
      return store.getters.getOrderDetailsById(props.orderId);
    });
    const orderItemIdReturnList = computed(() => {
      return store.getters.getOrderItemIdReturnList(props.orderId);
    });

    const dialog = ref(false);
    const selectAll = ref(false);
    const loading = ref(false);

    //dialog
    const closeDialog = () => {
      dialog.value = false;
      console.log(dialog.value);
    };

    //Checkbox
    const hasOrderDetails = computed(
      () => orderDetails.value && orderDetails.value.length > 0
    );

    const isOrderCompleted = computed(() => {
      return order.value && order.value.orderStatusCodeName === "已完成";
    });

    const isIdInReturnList = (orderItemId) => {
      if (orderItemIdReturnList.value) {
        return orderItemIdReturnList.value.includes(orderItemId);
      }
      return false;
    };

    onMounted(() => {
      if (hasOrderDetails.value) {
        orderDetails.value.forEach((detail) => {
          detail.enabled = false;
        });
      }
      store.dispatch("fetchOrderItemIdReturnList", props.orderId);
      console.log("OrderItemReturn Test => order from getter:", order.value);
    });

    watch(selectAll, (newValue) => {
      if (hasOrderDetails.value) {
        orderDetails.value.forEach((detail) => {
          if (!isIdInReturnList(detail.id)) detail.enabled = newValue;
        });
      }
    });

    //HttpPost
    const createOrderItemReturnCommandList = ref([]);
    const submit = () => {
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

      store.dispatch("postOrderItemReturns", requestData);
    };

    //
    return {
      order,
      orderDetails,
      orderItemIdReturnList,
      dialog,
      selectAll,
      loading,
      isOrderCompleted,
      submit,
      closeDialog,
      isIdInReturnList,
    };
  },
};
</script> 
