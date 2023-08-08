<template>
  <div class="d-flex align-center flex-column">


    <v-card v-for="orderItem in results" :key="orderItem.id" class="mx-auto" max-width="344" variant="outlined">
      <v-img :src="orderItem.gameGameCoverImg" height="200px" cover></v-img>
      <v-card-title>
        {{ orderItem.gameChiName }}
      </v-card-title>

      <v-card-subtitle>
        金額: {{ orderItem.discountedPrice }}
      </v-card-subtitle>

      <v-card-subtitle>
        類型: {{ orderItem.productIsVirtual }}
      </v-card-subtitle>


      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn :icon="show ? 'mdi-chevron-up' : 'mdi-chevron-down'" @click="show = !show">
        </v-btn>
      </v-card-actions>

      <v-expand-transition>
        <div v-show="show">
          <v-divider></v-divider>

          <v-btn color="orange-lighten-2" variant="text">
            <router-view></router-view>
            <router-link to="/Orders/id/OrderItemReturn">申請退貨</router-link>
          </v-btn>

          <v-btn color="orange-lighten-2" variant="text">
            聯絡客服
          </v-btn>
        </div>
      </v-expand-transition>
    </v-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      results: [],
      show: false
    }
  },
  methods: {
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
              gameChiName: data[id].gameChiName,
              gameGameCoverImg: data[id].gameGameCoverImg,
              discountedPrice: data[id].discountedPrice,
              productIsVirtual: data[id].productIsVirtual === true ? '序號' : '遊戲片'
            });
          }
          this.results = results;
        })
        .catch((error) => {
          this.isLoading = false;
          console.log(error);
          this.error = 'Failed to fetch data - please try again later.';
        });
    },

  },
  mounted() {
    this.loadData();
  },
}
</script>

<style></style>
