<template>
    <div class="container">
      <div class="row">&nbsp;</div>
      <div class="row">
          <div class="col-3">Sender</div>
          <div class="col-4"><input type="text" v-model="senderEmail" /></div>
      </div>
      <div class="row">
          <div class="col-3">Receiver</div>
          <div class="col-4"><input type="text" v-model="receiverEmail" /></div>
      </div>
      <div class="row">
          <div class="col-3">Message</div>
          <div class="col-4"><input type="text" v-model="chatMessage" /></div>
      </div>
      <div class="row">&nbsp;</div>
      <div class="row">
          <div class="col-6">
              <input type="button" :disabled="isButtonDisabled" @click="sendMessage" value="Send Message" />
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
                  <li v-for="(message, index) in messages" :key="index">{{ message }}</li>
              </ul>
          </div>
      </div>
    </div>
  </template>
  
<script>
  import { ref, onMounted } from 'vue';
  import * as signalR from '@microsoft/signalr'

  export default {
    name: 'ChatComponent',
    setup() {
      const userName = ref(''); 
      const senderEmail =ref('');
      const receiverEmail = ref('');
      const chatMessage = ref('');
      const isButtonDisabled = ref(true);
      const messages = ref([]);
  
      let conntionToChatHub = new signalR.HubConnectionBuilder().withUrl("https://localhost:7081/ChatHub").build();
  
      onMounted(() => {
        conntionToChatHub.on("RecieveMessage", (user, message) => {
          messages.value.push(`${user} : ${message}`);
        });
  
        conntionToChatHub.start().then(() => {
        isButtonDisabled.value = false;}).catch(err => {
        console.error("Error while establishing connection: ", err);
        });

      });
  
      const sendMessage = () => {
        conntionToChatHub.send('SendMessage', senderEmail.value, chatMessage.value).catch(err => {
          console.error(err.toString());
        });
      };
  
      return {
        userName,
        senderEmail,
        receiverEmail,
        chatMessage,
        isButtonDisabled,
        messages,
        sendMessage
      };
    }
  }
  </script>
  
  <style scoped>
  </style>
  