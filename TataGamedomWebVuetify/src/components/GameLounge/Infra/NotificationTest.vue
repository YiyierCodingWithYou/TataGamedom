<template>
  <v-container>
    {{ loggedAccount }}
    <p>{{ recipientMessage }}</p>
    <button @click="sendNotification">送出通知</button>
  </v-container>
</template>

<script setup>
import { ref, computed, onMounted, onUnmounted } from "vue";
import * as signalR from "@microsoft/signalr";
import { useRouter } from "vue-router";
import { useStore } from "vuex";

const recipientMessage = ref("test");
const relationMemberAccount = ref("lisi");
const recipientMemberAccount = ref("wangwu");
const relationPostId = ref(1);
const messageContent = ref("TEST");
const loggedAccount = computed(() => store.state.account);
const store = useStore();
const router = useRouter();

let connectionToChatHub = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7081/NotificationHub")
  .build();

const startTracking = async () => {
  if (connectionToChatHub.state === signalR.HubConnectionState.Disconnected) {
    try {
      await connectionToChatHub.start();
      connectionToChatHub.on("ReceiveNotification", receiveNotificationHandler);
    } catch (error) {
      console.error(error);
    }
  }
};

const sendNotification = async () => {
  try {
    await startTracking(); // 確保連線已經建立
    // 觸發追蹤操作並發送通知
    await connectionToChatHub.send(
      "SendNotificationToSpecificlMember",
      recipientMemberAccount.value,
      relationMemberAccount.value,
      "開始追蹤你了",
      relationPostId.value
    );
  } catch (error) {
    console.error(error);
  }
};

const receiveNotificationHandler = (
  recipientMemberAccount,
  relationMemberAccount,
  messageContent,
  relationPostId
) => {
  // 接收到通知後的處理邏輯
  if (recipientMemberAccount === loggedAccount.value)
    recipientMessage.value = `${relationMemberAccount} ${messageContent}`;
  // 在這裡您可以更新通知訊息的狀態，例如將其顯示在畫面上
};

onMounted(() => {
  startTracking();
});

onUnmounted(() => {
  connectionToChatHub.off("ReceiveNotification", receiveNotificationHandler);
  connectionToChatHub.stop();
});
</script>
<style lang=""></style>
