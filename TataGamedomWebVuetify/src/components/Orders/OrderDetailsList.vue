<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-card class="mx-auto" min-width="30vw" min-height="50vh">
      <v-card-item class="bg-tata-yellow">
        <v-card-title>
          <p class="text-h5 bg-tata-yellow mb-2">訂單明細</p>
        </v-card-title>
      </v-card-item>

      <v-list density="comfortable" class="text-h5">
        <v-list-item prepend-icon="mdi-music-accidental-sharp" class="my-3" title="訂單編號">{{ order.orderIndex }}
        </v-list-item>
        <v-divider inset></v-divider>
        <v-list-item prepend-icon="mdi-calendar-today-outline" class="my-3" title="成立日期">
          {{ relativeTime(order.createdAt) }}
        </v-list-item>
        <v-divider inset></v-divider>
        <v-list-item prepend-icon="mdi-calendar-today" class="my-3" title="完成日期">{{ relativeTime(order.orderCompletedAt)
        }}
        </v-list-item>
        <div v-if="order.orderShipmemtMethod">
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-cube-send" class="my-3" title="寄送方式">{{
            order.orderShipmemtMethod
          }}</v-list-item>
        </div>

        <v-divider inset></v-divider>
        <v-list-item prepend-icon="mdi-account-arrow-left-outline" class="my-3" title="收件人">{{ order.orderRecipientName
        }}</v-list-item>
        <div v-if="order.contactEmails">
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-email-fast-outline" class="my-3" title="信箱">{{ order.contactEmails }}
          </v-list-item>
        </div>

        <div v-if="order.toAddress">
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-map-marker-outline" class="my-3" title="收件地址">{{ order.toAddress }}
          </v-list-item>
        </div>
      </v-list>
    </v-card>
  </v-dialog>
</template>

<script>
import { ref, computed, onMounted } from "vue";
import { useStore } from "vuex";
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";

export default {
  name: "OrderDetailsList",
  props: {
    orderId: {
      type: Number,
      required: true,
    },
  },
  setup(props) {
    const store = useStore();
    const order = computed(() => store.getters.getOrderById(props.orderId));

    const dialog = ref(false);

    const relativeTime = (datetime) => {
      const date = new Date(datetime);
      return datetime == null
        ? "未完成"
        : format(date, "yyyy/MM/dd", { locale: zhTW });
    };

    onMounted(() => {
      console.log("DetailsList.vue => order from getter:", order.value);
    });

    return {
      order,
      dialog,
      relativeTime,
    };
  },
};
</script>

<style scoped>
.bg-tata-yellow {
  background-color: #f9ee08;
  display: inline-block;
  font-size: 2rem;
  font-weight: 600;
  font-family: "Digi-font";
  color: black;
  letter-spacing: 15px;
}

.v-list-item-title {
  letter-spacing: 12px;
}
</style>