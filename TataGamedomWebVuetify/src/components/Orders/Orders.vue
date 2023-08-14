<template>
  <!-- <v-container class="fill-height"> -->
  <v-row no-gutters>
    <v-col cols="12">
      <p v-if="isLoading">Loading...</p>
      <p v-else-if="!isLoading && error">{{ error }}</p>
      <p v-else-if="!isLoading && (!results || results.length === 0)">
        無訂單紀錄
      </p>

      <v-table v-else fixed-header hover="true">
        <thead>
          <tr>
            <th class="text-left">
              日期<v-icon>{{ "mdi-table-clock" }}</v-icon>
            </th>
            <th class="text-left">
              遊戲及類型<v-icon>{{ "mdi-google-downasaur" }}</v-icon>
            </th>
            <th class="text-left">
              總額<v-icon>{{ "mdi-sack" }}</v-icon>
            </th>
            <th class="text-left">
              狀態<v-icon>{{ "mdi-pokeball" }}</v-icon>
            </th>
            <th class="text-left"></th>
          </tr>
        </thead>
        <tbody class="bg-brown-lighten-5">
          <transition
            v-for="order in results"
            :key="order.orderId"
            name="fade-slide"
          >
            <tr
              v-show="!shownOrder || shownOrder === order.orderId"
              height="150px"
            >
              <td>{{ relativeTime(order.createdAt) }}</td>
              <td
                v-html="
                  combinedGameAndType(order.gameChiName, order.productIsVirtual)
                "
              ></td>
              <td>{{ order.total }}</td>
              <td>{{ order.orderStatusCodeName }}</td>
              <td>
                <v-tooltip text="訂單詳情">
                  <template v-slot:activator="{ props }">
                    <v-btn icon size="large" variant="plain">
                      <v-icon
                        :key="shownOrder"
                        @click="toggleOrderDetail(order.orderId)"
                        v-bind="props"
                      >
                        {{
                          shownOrder === order.orderId
                            ? "mdi-gamepad-round-up"
                            : "mdi-gamepad-round-down"
                        }}
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
        <v-col cols="12">
          <div
            v-if="showDetails"
            class="detail-container bg-brown-lighten-5"
            style="max-height: 680px; overflow-y: auto"
          >
            <div class="order-detailsCards">
              <OrderDetailsCards :orderId="shownOrder" />
            </div>

            <div>
              <v-layout column class="buttons">
                <v-tooltip text="聯繫客服">
                  <template v-slot:activator="{ props }">
                    <v-btn
                      class="ma-2"
                      variant="text"
                      icon="mdi-chat-alert-outline"
                      color="blue-grey-darken-2"
                      size="x-large"
                    >
                      <v-icon @click="" v-bind="props" size="x-large">
                        {{ "mdi-chat-alert-outline" }}
                      </v-icon>
                    </v-btn>
                  </template>
                </v-tooltip>
                <v-tooltip text="貨態追蹤">
                  <template v-slot:activator="{ props }">
                    <v-btn
                      class="ma-2"
                      variant="text"
                      icon="mdi-crosshairs-gps"
                      color="blue-grey-darken-2"
                      size="x-large"
                    >
                      <v-icon @click="" v-bind="props" size="x-large">
                        {{ "mdi-crosshairs-gps" }}
                      </v-icon>
                    </v-btn>
                  </template>
                </v-tooltip>
                <v-tooltip text="退貨">
                  <template v-slot:activator="{ props }">
                    <v-btn
                      class="ma-2"
                      variant="text"
                      icon="mdi-package-variant-closed-remove"
                      color="blue-grey-darken-2"
                      size="x-large"
                    >
                      <OrderItemReturnDialog
                        v-model="showDialog"
                        :orderId="shownOrder"
                        activator="parent"
                        width="auto"
                      />
                    </v-btn>
                  </template>
                </v-tooltip>
              </v-layout>
            </div>
          </div>
        </v-col>
      </transition>
    </v-col>
  </v-row>
  <!-- </v-container> -->
</template>

  
<script>
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
import OrderDetailsCards from "./OrderDetailsCards.vue";
import OrderDetailsList from "./OrderDetailsList.vue";
import OrderItemReturnDialog from "./OrderItemReturnDialog.vue";
import SupportHub from "./SupportHub.vue";

export default {
  components: {
    OrderDetailsCards,
    OrderDetailsList,
    OrderItemReturnDialog,
    SupportHub,
  },
  data() {
    return {
      results: [],
      shownOrder: null,
      showDetails: false,
      showDialog: false,
      showSupportHub: false,
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
    openReturnDialog() {
      this.showDialog = true;
    },

    relativeTime(datetime) {
      const date = new Date(datetime);
      return format(date, "yyyy/MM/dd", { locale: zhTW });
    },

    combinedGameAndType(gameNames, productIsVirtual) {
      return gameNames
        .map((name, index) => {
          const type = productIsVirtual[index] ? "序號" : "遊戲片";
          return `${name} (${type})`;
        })
        .join("<br>");
    },
  },

  mounted() {
    this.loadData();
  },
};
</script>

<style scoped>
.fade-slide-enter-from,
.fade-slide-leave-to {
  opacity: 0;
  transform: translateY(30px);
}

.fade-slide-enter-to,
.fade-slide-leave-from {
  opacity: 1;
  transform: translateY(0);
}

.fade-slide-enter-active,
.fade-slide-leave-active {
  transition: opacity 1s, transform 0.7s ease-in-out;
}

.detail-container {
  display: flex;
  overflow-y: auto;
}

.order-detailsCards {
  flex: 7;
}
.order-DetailsList {
  flex: 4;
}

.buttons {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
}
</style>
