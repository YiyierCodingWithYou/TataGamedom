<template>
  <p v-if="isLoading">Loading...</p>
  <p v-else-if="!isLoading && error">{{ error }}</p>
  <p v-else-if="!isLoading && (!results || results.length === 0)">無訂單紀錄</p>

  <v-table v-else fixed-header hover="true" h-screen>
    <thead>
      <tr>
        <th class="text-left">日期<v-icon>{{ 'mdi-table-clock' }}</v-icon></th>
        <th class="text-left">遊戲及類型<v-icon>{{ 'mdi-google-downasaur' }}</v-icon></th>
        <th class="text-left">總額<v-icon>{{ 'mdi-sack' }}</v-icon></th>
        <th class="text-left">狀態<v-icon>{{ 'mdi-pokeball' }}</v-icon></th>
        <th class="text-left"></th>
      </tr>
    </thead>
    <tbody class="bg-brown-lighten-5">
      <transition v-for="order in results" :key="order.orderId" name="fade-slide">
        <tr v-show="!shownOrder || shownOrder === order.orderId" height="150px">
          <td>{{ relativeTime(order.createdAt) }}</td>
          <td v-html="combinedGameAndType(order.gameChiName, order.productIsVirtual)"></td>
          <td>{{ order.total }}</td>
          <td>{{ order.orderStatusCodeName }}</td>
          <td>
            <v-tooltip text="訂單詳情">
              <template v-slot:activator="{ props }">
                <v-btn icon size="large" variant="plain">
                  <v-icon :key="shownOrder" @click="toggleOrderDetail(order.orderId)" v-bind="props">
                    {{ shownOrder === order.orderId ? 'mdi-gamepad-round-up' : 'mdi-gamepad-round-down' }}
                  </v-icon>
                </v-btn>
              </template>
            </v-tooltip>



          </td>
        </tr>
      </transition>

    </tbody>
  </v-table>
  <transition name="fade-slide">
    <div v-if="showDetails">
      <OrderDetailsCards :orderId="shownOrder" />
    </div>
  </transition>
</template>

  
<script>
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
import OrderDetailsCards from './OrderDetailsCards.vue';


export default {
  components: {
    OrderDetailsCards
  },
  data() {
    return {
      results: [],
      shownOrder: null,
      showDetails: false,
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
        this.showDetails = false;
      } else {
        this.shownOrder = null;
        this.showDetails = false;
        this.$nextTick(() => {
          this.shownOrder = orderId;
          setTimeout(() => {
            this.showDetails = true;
          }, 1000); // 在n秒後顯示詳細信息
        });
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
/* 指定進入動畫的起始和結束狀態 */
.fade-slide-enter-from,
.fade-slide-leave-to {
  opacity: 0;
  transform: translateY(30px);
}

/* 指定進入動畫的結束狀態 */
.fade-slide-enter-to,
.fade-slide-leave-from {
  opacity: 1;
  transform: translateY(0);
}

/* 指定動畫持續時間和效果 */
.fade-slide-enter-active,
.fade-slide-leave-active {
  transition: opacity 1s, transform 0.7s ease-in-out;

}
</style>
