<template>
  <v-dialog v-model="dialog" activator="parent" width="auto">
    <div class="text-subtitle-2 mb-2">退款紀錄</div>
    <v-expansion-panels>
      <v-expansion-panel v-for="item in props.orderItemReturnList" :key="item.id">
        <!-- <div>退貨單編號: {{ item.id }}</div> -->
        <div>退貨單編號: {{ item.index }}</div>
        <div>退款狀態: {{ item.isRefunded ? "已退款" : "未退款" }}</div>
        <div>退貨狀態: {{ item.isReturned ? "已退貨" : "未退貨" }}</div>
        <div>申請退款時間: {{ relativeTime(item.issuedAt) }}</div>
        <div v-if="item.completedAt">完成退款時間: {{ relativeTime(item.completedAt) }}</div>
        <div>LinePay退款編號: {{ item.linePayRefundTransactionId }}</div>
        <div>原訂單品項編號: {{ item.index }}</div>
        <br />
      </v-expansion-panel>
    </v-expansion-panels>
  </v-dialog>
</template>

<script setup>
import { ref, defineProps } from "vue";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";

const props = defineProps({
  orderItemReturnList: {
    type: Array,
    required: true,
  },
});

const relativeTime = (datetime) => {
  const date = new Date(datetime);
  return format(date, "yyyy/MM/dd", { locale: zhTW });
};

const dialog = ref(false);

</script>

<style></style>
