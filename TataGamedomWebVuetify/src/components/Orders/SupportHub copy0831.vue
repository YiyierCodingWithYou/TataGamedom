<template>
  <nav>
    <div>
      <h1><strong>Tata</strong>客服中心</h1>
      <v-container>
        <div class="container-sm mt-20">
          <div class="mx-5">
            <Message
              v-for="(message, index) in messages"
              :key="index"
              :name="message.account"
              :photoUrl="''"
              :senderAccount="true"
            >
              {{ message.memberName }}: {{ message.content }}
            </Message>
          </div>
        </div>

        <!-- todo 移除 -->
        <!-- <v-text-field label="Sender" hide-details="auto" v-model="senderAccount" placeholder="請輸入姓名"></v-text-field> -->
        <!--  -->

        <v-text-field
          label="傳給誰"
          hide-details="auto"
          v-model="receiverAccount"
          placeholder="將訊息傳給:"
        ></v-text-field>

        <v-text-field
          label="輸入訊息"
          hide-details="auto"
          v-model="chatMessage"
          placeholder="你的訊息"
          :disabled="isButtonDisabled"
          @keyup.enter="sendPrivateMessage"
        ></v-text-field>

        <v-col cols="auto">
          <v-btn
            density="compact"
            icon="mdi-plus"
            :disabled="isButtonDisabled"
            @click.prevent="sendPrivateMessage"
            value="Send Message"
          ></v-btn>
        </v-col>
      </v-container>
    </div>
  </nav>
</template>
  
<script>
import { ref, onMounted, onUnmounted } from "vue";
import * as signalR from "@microsoft/signalr";
import axios from "axios";

import SendIcon from "./SendIcon.vue";
import Message from "./Message.vue";

export default {
  components: { Message, SendIcon },

  setup() {
    //const senderAccount = ref("");
    const receiverAccount = ref("");
    const chatMessage = ref("");
    const isButtonDisabled = ref(false);
    const messages = ref([]);

    //API Get
    const memberAndChatInfo = ref({});
    const fetchMemberAndChatInfo = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7081/api/ChatRoom/MemberAndChatInfo",
          { withCredentials: true }
        );
        memberAndChatInfo.value = response.data;
        console.log(memberAndChatInfo.value);
      } catch (error) {
        console.error(error);
      }
    };

    // SignalR
    let connectionToChatHub = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7081/ChatHub")
      .build();

    onMounted(() => {
      connectionToChatHub.start().catch((err) => console.error(err.toString()));
      connectionToChatHub.on("ReceiveMessage", receiveMessageHandler);

      //API
      fetchMemberAndChatInfo();
    });

    onUnmounted(() => {
      connectionToChatHub.off("ReceiveMessage", receiveMessageHandler);
      connectionToChatHub.stop();
    });

    const receiveMessageHandler = (account, content, memberName) => {
      messages.value.push({ account, content, memberName });
    };

    const sendMessage = () => {
      connectionToChatHub
        .send(
          "SendMessageToAll",
          memberAndChatInfo.value.memberAccount,
          chatMessage.value,
          memberAndChatInfo.value.memberName
        )
        .catch((err) => console.error(err.toString()));
      chatMessage.value = "";
    };

    return {
      //senderAccount,
      chatMessage,
      receiverAccount,
      isButtonDisabled,
      messages,
      sendMessage,
      memberAndChatInfo,
    };
  },
};
</script>
  
<style scoped></style>
  