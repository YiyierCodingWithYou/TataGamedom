<template>
  <p v-if="isLoading">Loading...</p>
  <p v-else-if="!isLoading && error">{{ error }}</p>
  <p v-else-if="!isLoading && (!results || results.length === 0)">無訂單紀錄</p>

  <v-table v-else fixed-header hover="true" height="800" class="bg-brown-lighten-5">
    <thead>
      <tr>
        <th class="text-left">日期</th>
        <th class="text-left">遊戲及類型</th>
        <th class="text-left">總額</th>
        <th class="text-left">狀態</th>
        <th class="text-left">詳細</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="order in results" :key="order.id">
        <td>{{ relativeTime(order.createdAt) }}</td>
        <td v-html="combinedGameAndType(order.gameChiName, order.productIsVirtual)"></td>
        <td>{{ order.total }}</td>
        <td>{{ order.orderStatusCodeName }}</td>
        <td>
          <v-btn @click="toggleOrderDetail(order.id)">詳細</v-btn>
          <v-expansion-panels v-if="shownOrder === order.id">
            <v-expansion-panel>
              <v-expansion-panel-content>
                <OrderDetails :orderId="order.orderId" />
              </v-expansion-panel-content>
            </v-expansion-panel>
          </v-expansion-panels>
        </td>
      </tr>
    </tbody>
  </v-table>
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

    toggleShow(order) {
      if (this.shownItems[order] === undefined) {
        this.shownItems[order] = true;
      } else {
        this.shownItems[order] = !this.shownItems[order];
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
    navigateToOrderDetail(order) {
      this.$router.push({
        name: "OrderDetails",
        params: { id: order.orderId },
      });
    },
  },

  mounted() {
    this.loadData();
  },
};
</script>

<style scoped></style>
