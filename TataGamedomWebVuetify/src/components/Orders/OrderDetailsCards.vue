<template>
  <v-carousel :model-value="carouselIndex" height="680px" width="80%" show-arrows="hover" progress="grey-darken-1"
    hide-delimiters>
    <template v-slot:prev="{ props }">
      <v-icon icon="mdi-menu-left" size="x-large" style="font-size: 70px" color="#a1dfe9" @click="props.onClick"></v-icon>
    </template>
    <template v-slot:next="{ props }">
      <v-icon icon="mdi-menu-right" size="x-large" style="font-size: 70px" color="#a1dfe9"
        @click="props.onClick"></v-icon>
    </template>

    <v-carousel-item v-for="orderItem in orderDetails" :key="orderItem.id">
      <v-card class="mx-auto mb-1 overflow-auto text-center bg-tata" max-width="auto" height="auto">
        <v-img :src="orderItem.gameGameCoverImg" height="520px" class="mt-10"></v-img>
        <v-card-title>
          {{ orderItem.gameChiName }}
        </v-card-title>

        <div class="d-flex justify-center ">
          <hr class="w-50 color-y mb-2">
        </div>

        <v-card-subtitle>
          金額: {{ unitExchange(orderItem.discountedPrice) }}
        </v-card-subtitle>
        <v-card-subtitle v-if="orderItem.inventoryItemGameKey">
          序號: {{ orderItem.inventoryItemGameKey }}</v-card-subtitle>
        <v-card-subtitle>
          類型: {{ orderItem.productIsVirtual === true ? "序號" : "遊戲片" }}
        </v-card-subtitle>

        <!-- OrderItemIndex -->

      </v-card>
    </v-carousel-item>
  </v-carousel>
</template>

<script>
import { ref, onMounted, computed } from "vue";
import { useStore } from "vuex";

export default {
  name: "OrderDetailsCard",
  props: {
    orderId: {
      type: Number,
      required: true,
    },
  },

  setup(props) {
    const store = useStore();

    const orderDetails = computed(() => {
      return store.getters.getOrderDetailsById(props.orderId);
    });

    const fetchDetails = () => {
      store.dispatch("fetchOrderDetails", props.orderId);
    };

    //NTD 千分位
    const unitExchange = (total) => {
      return 'NT$ ' + total.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }

    onMounted(() => {
      //console.log("orderId:" + props.orderId);
      fetchDetails();
    });

    const carouselIndex = ref(0);

    return {
      orderDetails,
      carouselIndex,
      unitExchange
    };
  },
};
</script>


<style scoped>
.bg-tata {
  background-color: #01010f;
}

.color-y {
  border: #f9ee08 1px solid;
}
</style>
