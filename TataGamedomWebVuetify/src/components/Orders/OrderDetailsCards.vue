<template>
  <v-carousel
    height="680px"
    width="80%"
    v-model="carouselIndex"
    show-arrows="hover"
    progress="grey-darken-1"
    hide-delimiters
  >
    <!-- delimiter-icon="mdi-pac-man" -->
    <template v-slot:prev="{ props }">
      <v-icon
        icon="mdi-menu-left"
        size="x-large"
        style="font-size: 70px"
        color="brown-lighten-1"
        @click="props.onClick"
      ></v-icon>
    </template>
    <template v-slot:next="{ props }">
      <v-icon
        icon="mdi-menu-right"
        size="x-large"
        style="font-size: 70px"
        color="brown-lighten-1"
        @click="props.onClick"
      ></v-icon>
    </template>

    <v-carousel-item v-for="orderItem in results" :key="orderItem.id">
      <v-card
        class="mx-auto mb-1 overflow-auto bg-brown-lighten-5 text-center"
        max-width="auto"
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
      </v-card>
    </v-carousel-item>
  </v-carousel>
</template>

<script>
import { da } from "date-fns/locale";
import { computed } from "vue";
import { useStore } from "vuex";

export default {
  props: {
    orderId: {
      required: true,
    },
  },
  setup(props) {
    const store = useStore();
    const results = computed(() => store.state.results);

    // ...其他邏輯...

    return {
      results,
      // ...其他返回的屬性或方法...
    }
  }
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
          console.log(data);
          this.isLoading = false;
          const results = [];
          for (const id in data) {
            results.push({
              id: id,
              index: data[id].index,
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
  },
  mounted() {
    this.loadData();
  },
};
</script>

<style></style>
