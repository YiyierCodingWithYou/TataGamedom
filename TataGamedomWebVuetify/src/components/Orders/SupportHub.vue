<template>
  <v-container>
    <nav>
      <div>
        <h1>Tata客服中心</h1>
        <v-divider></v-divider>
        <v-container>
          <div class="container-sm mt-20">
            <v-virtual-scroll :items="messages" height="900">
              <template v-slot="{ item, index }">
                <Message :key="index" :name="item.memberName"
                  :isSenderAccountMine="item.senderAccount === memberAndChatInfo.memberAccount">
                  {{ item.content }}
                </Message>
              </template>
            </v-virtual-scroll>
          </div>

          <div class="fixed-bottom-container">
            <v-text-field label="傳給哪個帳號" hide-details="auto" v-model="receiverAccount" placeholder="傳給誰"
              append-icon="mdi"></v-text-field>

            <v-text-field label="輸入訊息" v-model="chatMessage" placeholder="你的訊息" type="text" no-details outlined
              append-icon="mdi-comment-multiple-outline" @keyup.enter="sendPrivateMessage"
              @click:append="sendPrivateMessage"></v-text-field>
          </div>
        </v-container>
      </div>
    </nav>
  </v-container>
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
    const chatMessage = ref("");
    const receiverAccount = ref("");
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
      .withUrl("https://localhost:7081/ChatHub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    onMounted(() => {
      connectionToChatHub
        .start()
        .then(() => {
          console.log("Connection started");
        })
        .catch((err) => console.error(err.toString()));

      connectionToChatHub.on("ReceiveMessage", receiveMessageHandler);

      connectionToChatHub.on(
        "ReceivePrivateMessage",
        receivePrivateMessageHandler
      );

      //API
      fetchMemberAndChatInfo();
    });

    onUnmounted(() => {
      connectionToChatHub.off("ReceiveMessage", receiveMessageHandler);
      connectionToChatHub.off("ReceivePrivateMessage", receiveMessageHandler);
      connectionToChatHub.stop();
    });

    const receiveMessageHandler = (account, content, memberName) => {
      messages.value.push({ account, content, memberName });
    };

    const receivePrivateMessageHandler = (
      senderAccount,
      content,
      memberName,
      receiverAccount
    ) => {
      messages.value.push({
        senderAccount,
        content,
        memberName,
        receiverAccount,
      });
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

    const sendPrivateMessage = () => {
      //const receiverAccount = "apalan60@gmail.com"; //v-if  => 只要登錄的不是後台人員，receiverAccount就不能設定
      connectionToChatHub
        .invoke(
          "SendPrivateMessage",
          memberAndChatInfo.value.memberAccount,
          chatMessage.value,
          memberAndChatInfo.value.memberName,
          receiverAccount.value
        )
        .catch((err) => console.error(err.toString()));
      chatMessage.value = "";
    };

    return {
      chatMessage,
      receiverAccount,
      messages,
      sendMessage,
      sendPrivateMessage,
      memberAndChatInfo,
    };
  },
};
</script>
  
<style scoped>
.fixed-bottom-container {
  position: relative;
  bottom: 0;
  width: 100%;
  background-color: gray;
  z-index: 1000;
}
</style>
  