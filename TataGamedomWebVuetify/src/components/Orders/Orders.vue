<template>
  <p v-if="isLoading">Loading...</p>
  <p v-else-if="!isLoading && error">{{ error }}</p>
  <p v-else-if="!isLoading && (!results || results.length === 0)">無訂單紀錄</p>

  <v-table v-else fixed-header hover="true" height="auto">
    <thead>
      <tr>
        <th class="text-left">日期<v-icon>{{ 'mdi-script-text-outline' }}</v-icon></th>
        <th class="text-left">遊戲及類型<v-icon>{{ 'mdi-google-downasaur' }}</v-icon></th>
        <th class="text-left">總額<v-icon>{{ 'mdi-sack' }}</v-icon></th>
        <th class="text-left">狀態<v-icon>{{ 'mdi-pokeball' }}</v-icon></th>
        <th class="text-left"></th>
      </tr>
    </thead>
    <tbody class="bg-brown-lighten-5">
      <tr v-for="order in results" :key="order.id" height="150px">
        <td>{{ relativeTime(order.createdAt) }}</td>
        <td v-html="combinedGameAndType(order.gameChiName, order.productIsVirtual)"></td>
        <td>{{ order.total }}</td>
        <td>{{ order.orderStatusCodeName }}</td>
        <td>
          <v-icon :key="shownOrder" @click="toggleOrderDetail(order.orderId)">
            {{ shownOrder === order.orderId ? 'mdi-gamepad-round-up' : 'mdi-gamepad-round-down' }}
          </v-icon>
        </td>
      </tr>
    </tbody>
  </v-table>
  <transition name="fade-slide">
    <div v-if="shownOrder != null">
      <OrderDetails :orderId="shownOrder" />
    </div>
  </transition>
</template>

  
<script>
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
import OrderDetails from './OrderDetails.vue';


export default {
  components: {
    OrderDetails
  },
  data() {
    return {
      results: [],
      shownOrder: null
    };
  },
  methods: {
    loadData() {
      fetch("https://localhost:7081/api/Orders", {
        credentials: "include",
      })
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
              orderId: data[id].id,
              gameChiName: data[id].gameChiName,
              productIsVirtual: data[id].productIsVirtual,
              createdAt: data[id].createdAt,
              total: data[id].total,
              orderStatusCodeName: data[id].orderStatusCodeName,
            });
          }
          this.results = results;
        })
        .catch((error) => {
          this.isLoading = false;
          console.log(error);
          this.error = "Failed to fetch data - please try again later.";
        });
    },
    toggleOrderDetail(orderId) {
      if (this.shownOrder === orderId) {
        this.shownOrder = null;
      } else {
        this.shownOrder = orderId;
      }
    },

    relativeTime(datetime) {
      const date = new Date(datetime);
      return format(date, 'yyyy/MM/dd', { locale: zhTW });
    },

    combinedGameAndType(gameNames, productIsVirtual) {
      return gameNames.map((name, index) => {
        const type = productIsVirtual[index] ? "序號" : "遊戲片";
        return `${name} (${type})`;
      }).join("<br>");
    },
  },

  mounted() {
    this.loadData();
  },
};
</script>

<style scoped>
.fade-slide-enter-active,
.fade-slide-leave-active {
  transition: opacity 0.5s, transform 0.5s;
}

.fade-slide-enter,
.fade-slide-leave-to {
  opacity: 0;
  transform: translateY(30px);
}
</style>
