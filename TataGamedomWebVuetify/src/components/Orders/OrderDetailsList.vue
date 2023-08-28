<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <v-card class="mx-auto" max-width="auto">
      <v-card-item class="bg-brown-lighten-5">
        <v-card-title>
          <span class="text-h5"></span>
        </v-card-title>

        <template v-slot:append>
          <v-defaults-provider
            :defaults="{
              VBtn: {
                variant: 'text',
                density: 'comfortable',
              },
            }"
          >
            <v-btn icon="mdi-pencil"></v-btn>
          </v-defaults-provider>
        </template>
      </v-card-item>

      <v-list>
        <v-list-item prepend-icon="mdi-music-accidental-sharp" title="訂單編號:"
          >{{ order.orderIndex }}
        </v-list-item>
        <v-divider inset></v-divider>
        <v-list-item
          prepend-icon="mdi-calendar-today-outline"
          title="成立日期:"
        >
          {{ relativeTime(order.createdAt) }}
        </v-list-item>
        <v-divider inset></v-divider>
        <v-list-item prepend-icon="mdi-calendar-today" title="完成日期:"
          >{{ relativeTime(order.orderCompletedAt) }}
        </v-list-item>
        <div v-if="order.orderShipmemtMethod">
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-cube-send" title="寄送方式:">{{
            order.orderShipmemtMethod
          }}</v-list-item>
        </div>

        <v-divider inset></v-divider>
        <v-list-item
          prepend-icon="mdi-account-arrow-left-outline"
          title="收件人:"
          >{{ order.orderRecipientName }}</v-list-item
        >
        <div v-if="order.contactEmails">
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-email-fast-outline" title="信箱:"
            >{{ order.contactEmails }}
          </v-list-item>
        </div>

        <div v-if="order.toAddress">
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-map-marker-outline" title="收件地址:"
            >{{ order.toAddress }}
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

<style></style>