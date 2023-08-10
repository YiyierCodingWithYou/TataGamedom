<template>
  <v-card
    v-for="orderItem in results"
    :key="orderItem.id"
    class="mx-auto mb-3 overflow-auto"
    max-width="500"
    variant="outlined"
  >
    <v-img :src="orderItem.gameGameCoverImg" height="200px"></v-img>
    <v-card-title>
      {{ orderItem.gameChiName }}
    </v-card-title>

    <v-card-subtitle> 金額: {{ orderItem.discountedPrice }} </v-card-subtitle>

    <v-card-subtitle> 類型: {{ orderItem.productIsVirtual }} </v-card-subtitle>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn
        :icon="shownItems[orderItem.id] ? 'mdi-chevron-up' : 'mdi-chevron-down'"
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
</template>

<script>
export default {
  data() {
    return {
      results: [],
      shownItems: {},
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

      fetch(`https://localhost:7081/api/OrderItems/order/${orderId}`)
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
          }
          this.results = results;
          this.shownItems[id] = false;
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
