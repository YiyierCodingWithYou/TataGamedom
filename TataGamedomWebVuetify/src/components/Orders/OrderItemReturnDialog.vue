<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-spacer></v-spacer>
    <v-sheet width="1000" class="mx-auto">
      <v-form validate-on="submit lazy" @submit.prevent="submit">
        <div class="d-flex pa-4 justify-center">
          <v-checkbox v-model="selectAll" label="全選/取消"></v-checkbox>
        </div>
        <v-card v-for="orderDetail in orderDetails" :key="orderDetail.id">
          <v-card-text>
            <div class="d-flex pa-4">
              <v-checkbox-btn
                v-model="orderDetail.enabled"
                class="pe-2"
              ></v-checkbox-btn>
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
        <v-btn block class="mt-2" text="取消" @click="closeDialog"></v-btn>
        <v-btn
          :loading="loading"
          block
          class="mt-2"
          text="送出"
          type="submit"
          @click="closeDialog"
        ></v-btn>
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

    const dialog = ref(false);
    const selectAll = ref(false);
    const loading = ref(false);

    watch(selectAll, (newValue) => {
      if (orderDetails.value && orderDetails.value.length > 0) {
        orderDetails.value.forEach((detail) => {
          detail.enabled = newValue;
        });
      }
    });

    const createOrderItemReturnCommandList = ref([]);
    const submit = () => {
      this.store.dispatch(
        "postOrderItemReturns",
        createOrderItemReturnCommandList
      );
    };

    const closeDialog = () => {
      dialog.value = false;
    };

    onMounted(() => {
      if (orderDetails.value && orderDetails.value.length > 0) {
        orderDetails.value.forEach((detail) => {
          detail.enabled = false;
        });
      }
      console.log("OrderItemReturn Test => order from getter:", order.value);
      console.log(
        "OrderItemReturn Test => orderDetails from getter:",
        orderDetails.value
      );
    });

    return {
      order,
      orderDetails,
      dialog,
      selectAll,
      loading,
      submit,
      closeDialog,
    };
  },
};
</script> 
