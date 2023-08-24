<template>
  <v-container>
    <div class="row">&nbsp;</div>

    <v-text-field
      label="Sender"
      :rules="rules"
      hide-details="auto"
      v-model="senderAccount"
      placeholder="請輸入姓名"
    ></v-text-field>

    <v-text-field
      label="Message"
      :rules="rules"
      hide-details="auto"
      v-model="chatMessage"
      placeholder="你的訊息"
      :disabled="isButtonDisabled"
      @keyup.enter="sendMessage"
    ></v-text-field>

    <v-col cols="auto">
      <v-btn
        density="compact"
        icon="mdi-plus"
        :disabled="isButtonDisabled"
        @click.prevent="sendMessage"
        value="Send Message"
      ></v-btn>
    </v-col>

    <div class="row">
      <div class="col-12">
        <hr />
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <ul>
          <li v-for="(message, index) in messages" :key="index">
            {{ message.account }} : {{ message.content }}
          </li>
        </ul>
      </div>
    </div>
    <RedirectToLogisticsSelection_Url_btn />
  </v-container>
</template>
  
<script>
import { ref, onMounted, onUnmounted } from "vue";
import * as signalR from "@microsoft/signalr";
import RedirectToLogisticsSelection_Url_btn from "@/components/ECpay/RedirectToLogisticsSelection_Url.vue";

export default {
  components: {
    RedirectToLogisticsSelection_Url_btn,
  },
  setup() {
    const senderAccount = ref("");
    const chatMessage = ref("");
    const isButtonDisabled = ref(false);
    const messages = ref([]);

    let connectionToChatHub = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7081/ChatHub")
      .build();

    onMounted(() => {
      connectionToChatHub.start().catch((err) => console.error(err.toString()));
      connectionToChatHub.on("ReceiveMessage", receiveMessageHandler);
    });

    onUnmounted(() => {
      connectionToChatHub.off("ReceiveMessage", receiveMessageHandler);
      connectionToChatHub.stop();
    });

    const receiveMessageHandler = (account, content) => {
      messages.value.push({ account, content });
    };

    const sendMessage = () => {
      connectionToChatHub
        .send("SendMessageToAll", senderAccount.value, chatMessage.value)
        .catch((err) => console.error(err.toString()));
      chatMessage.value = "";
    };

    return {
      senderAccount,
      chatMessage,
      isButtonDisabled,
      messages,
      sendMessage,
    };
  },
};
</script>
  
<style scoped></style>
  