<template>
  <div class="container">
    <div class="row">&nbsp;</div>
    <div class="row">
      <div class="col-3">Sender</div>
      <div class="col-4"><input type="text" v-model="senderAccount" /></div>
    </div>
    <div class="row">
      <div class="col-3">Message</div>
      <div class="col-4"><input type="text" v-model="chatMessage" /></div>
    </div>
    <div class="row">&nbsp;</div>
    <div class="row">
      <div class="col-6">
        <input type="button" :disabled="isButtonDisabled" @click.prevent="sendMessage" value="Send Message" />
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <hr />
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <ul>
          <li v-for="(message, index) in messages" :key="index">{{ message.account }} : {{ message.content }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>
  
<script>
import { ref, onMounted, onUnmounted } from 'vue';
import * as signalR from '@microsoft/signalr'

export default {
  setup() {
    const senderAccount = ref('');
    const chatMessage = ref('');
    const isButtonDisabled = ref(false);
    const messages = ref([]);

    let connectionToChatHub = new signalR.HubConnectionBuilder().withUrl("https://localhost:7081/ChatHub").build();

    onMounted(() => {
      connectionToChatHub.start().catch(err => console.error(err.toString()));
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
      connectionToChatHub.send('SendMessageToAll', senderAccount.value, chatMessage.value)
        .catch(err => console.error(err.toString()));
    };

    return {
      senderAccount,
      chatMessage,
      isButtonDisabled,
      messages,
      sendMessage
    };
  }
}
</script>
  
<style scoped></style>
  