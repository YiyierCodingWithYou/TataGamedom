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
    <div v-if="showDetails" class="detail-container bg-brown-lighten-5">
      <div class="order-detailsCardsCardsCards">
        <OrderDetailsCards :orderId="shownOrder" />
      </div>
      <div class="order-DetailsList">
        <OrderDetailsList :orderId="shownOrder" />
      </div>
      <div>
        <v-layout column class="buttons">
          <v-tooltip text="聯繫客服">
            <template v-slot:activator="{ props }">
              <v-btn class="ma-2" variant="text" icon="mdi-chat-alert-outline" color="blue-grey-darken-2" size="x-large">
                <v-icon @click="" v-bind="props" size="x-large">
                  {{ 'mdi-chat-alert-outline' }}
                </v-icon>
              </v-btn>
            </template>
          </v-tooltip>
          <v-tooltip text="貨態追蹤">
            <template v-slot:activator="{ props }">
              <v-btn class="ma-2" variant="text" icon="mdi-crosshairs-gps" color="blue-grey-darken-2" size="x-large">
                <v-icon @click="" v-bind="props" size="x-large">
                  {{ 'mdi-crosshairs-gps' }}
                </v-icon>
              </v-btn>
            </template>
          </v-tooltip>
          <v-tooltip text="退貨">
            <template v-slot:activator="{ props }">
              <v-btn class="ma-2" variant="text" icon="mdi-package-variant-closed-remove" color="blue-grey-darken-2"
                size="x-large">
                <v-icon @click="" v-bind="props" size="x-large">
                  {{ 'mdi-package-variant-closed-remove' }}
                </v-icon>
              </v-btn>
            </template>
          </v-tooltip>
        </v-layout>
      </div>
    </div>

  </transition>
</template>

  
<script>
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
import OrderDetailsCards from './OrderDetailsCards.vue';
import OrderDetailsList from './OrderDetailsList.vue';


export default {
  components: {
    OrderDetailsCards,
    OrderDetailsList
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

.detail-container {
  display: flex;
}

.order-detailsCardsCardsCards,
.order-DetailsList {
  flex: 5;
}

.buttons {
  flex: 2;
  display: flex;
  flex-direction: column;
  /* 讓按鈕垂直排列 */
  align-items: center;
  /* 使按鈕水平居中 */
  justify-content: space-between;
  /* 在按鈕之間加入空間 */
}
</style>
