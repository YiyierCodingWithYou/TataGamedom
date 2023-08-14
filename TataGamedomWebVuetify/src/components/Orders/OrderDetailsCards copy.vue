<template>
  <v-carousel
    height="680px"
    width="80%"
    v-model="carouselIndex"
    show-arrows="hover"
    progress="grey-darken-1"
    hide-delimiter-background
    delimiter-icon="mdi-pac-man"
  >
    <template v-slot:prev="{ props }">
      <v-btn
        icon="mdi-menu-left"
        size="x-large"
        variant="text"
        color="brown-lighten-1"
        @click="props.onClick"
      ></v-btn>
    </template>
    <template v-slot:next="{ props }">
      <v-btn
        icon="mdi-menu-right"
        size="x-large"
        variant="text"
        color="brown-lighten-1"
        @click="props.onClick"
      ></v-btn>
    </template>

    <v-carousel-item v-for="orderItem in results" :key="orderItem.id">
      <v-card
        class="mx-auto mb-1 overflow-auto bg-brown-lighten-5 text-center"
        max-width="auto"
        variant="outline"
        height="auto"
      >
        <v-img :src="orderItem.gameGameCoverImg" height="520px"></v-img>
        <v-card-title>
          {{ orderItem.gameChiName }}
        </v-card-title>

        <v-card-subtitle>
          金額: {{ orderItem.discountedPrice }}
        </v-card-subtitle>

        <v-card-subtitle> 優惠: //Todo </v-card-subtitle>

        <v-card-subtitle>
          類型: {{ orderItem.productIsVirtual }}
        </v-card-subtitle>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            :icon="
              shownItems[orderItem.id] ? 'mdi-chevron-up' : 'mdi-chevron-down'
            "
            @click="toggleShow(orderItem.id)"
          >
          </v-btn>
        </v-card-actions>

        <v-expand-transition>
          <div v-if="shownItems[orderItem.id]">
            <v-divider></v-divider>

            <v-btn
              color="orange-lighten-2"
              variant="text"
              @click="navigateToOrderItemReturn(orderItem)"
            >
              申請退貨
            </v-btn>

            <v-btn color="orange-lighten-2" variant="text"> 聯絡客服 </v-btn>
          </div>
        </v-expand-transition>
      </v-card>
    </v-carousel-item>
  </v-carousel>
</template>

<script>
export default {
  props: {
    orderId: {
      required: true,
    },
  },
  data() {
    return {
      results: [],
      shownItems: {},
      carouselIndex: 0,
    };
  },
  methods: {
    toggleShow(orderItemId) {
      if (this.shownItems[orderItemId] === undefined) {
        this.shownItems[orderItemId] = true;
      } else {
        this.shownItems[orderItemId] = !this.shownItems[orderItemId];
      }
    },
    loadData() {
      const orderId = this.$route.params.id;

      fetch(`https://localhost:7081/api/OrderItems/order/${this.orderId}`)
        .then((response) => {
          if (response.ok) {
            return response.json();
          }
        })
        .then((data) => {
          this.isLoading = false;
          const results = [];
          for (const id in data) {
            results.push({
              id: id,
              orderItemId: data[id].id,
              gameChiName: data[id].gameChiName,
              gameGameCoverImg: data[id].gameGameCoverImg,
              discountedPrice: data[id].discountedPrice,
              productIsVirtual:
                data[id].productIsVirtual === true ? "序號" : "遊戲片",
            });
            this.shownItems[id] = false;
          }
          this.results = results;
        })
        .catch((error) => {
          this.isLoading = false;
          console.log(error);
          this.error = "Failed to fetch data - please try again later.";
        });
    },
    navigateToOrderItemReturn(orderItem) {
      this.$router.push({
        name: "OrderItemReturn",
        params: {
          id: orderItem.orderItemId,
          gameChiName: orderItem.gameChiName,
        },
      });
    },
  },
  mounted() {
    this.loadData();
  },
};
</script>

<style></style>
