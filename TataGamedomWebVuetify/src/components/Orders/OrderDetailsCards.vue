<template>
  <v-carousel :model-value="carouselIndex" height="680px" width="80%" show-arrows="hover" progress="grey-darken-1"
    hide-delimiters>
    <template v-slot:prev="{ props }">
      <v-icon icon="mdi-menu-left" size="x-large" style="font-size: 70px" color="brown-lighten-1"
        @click="props.onClick"></v-icon>
    </template>
    <template v-slot:next="{ props }">
      <v-icon icon="mdi-menu-right" size="x-large" style="font-size: 70px" color="brown-lighten-1"
        @click="props.onClick"></v-icon>
    </template>

    <v-carousel-item v-for="orderItem in orderDetails" :key="orderItem.id">
      <v-card class="mx-auto mb-1 overflow-auto bg-brown-lighten-5 text-center" max-width="auto" height="auto">
        <v-img :src="orderItem.gameGameCoverImg" height="520px"></v-img>
        <v-card-title>
          {{ orderItem.gameChiName }}
        </v-card-title>

        <v-card-subtitle>
          金額: {{ orderItem.discountedPrice }}
        </v-card-subtitle>

        <v-card-subtitle> 優惠: //Todo </v-card-subtitle>
        <v-card-subtitle> 序號: //Todo </v-card-subtitle>

        <v-card-subtitle>
          類型: {{ orderItem.productIsVirtual === true ? "序號" : "遊戲片" }}
        </v-card-subtitle>
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

    onMounted(() => {
      //console.log("orderId:" + props.orderId);
      fetchDetails();
    });

    const carouselIndex = ref(0);

    return {
      orderDetails,
      carouselIndex,
    };
  },
};
</script>


<style></style>
