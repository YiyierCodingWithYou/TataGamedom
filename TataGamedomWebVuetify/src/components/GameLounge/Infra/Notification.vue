<template>
  <v-menu open-on-hover>
    <template v-slot:activator="{ props }">
      <v-btn class="pageBtn" icon="" @click="" v-bind="props">
        <v-badge v-if="unreadNumber > 0" :content="unreadNumber" color="error">
          <v-icon>mdi-bell-outline</v-icon>
        </v-badge>
        <v-icon v-if="unreadNumber === 0">mdi-bell-outline</v-icon>
      </v-btn>
    </template>

    <v-list :key="notificationKey">
      <v-list-item
        v-for="(item, index) in items"
        :key="index"
        v-if="items.length > 0"
      >
        <v-list-item-title
          :class="item.isReaded ? 'text-grey-darken-1' : ''"
          @click="linkTo(item.id, item.link)"
          >{{ item.content }}</v-list-item-title
        >
      </v-list-item>
    </v-list>
  </v-menu>

  <v-snackbar
    v-model="showSnackbar"
    :timeout="2000"
    color="warning"
    position="relative"
    elevation="24"
    class="m10"
    location="top right"
    max-width="50%"
  >
    {{ recipientMessage }}
  </v-snackbar>
</template>

<style scoped>
.v-list {
  max-width: 300px;
  max-height: 300px;
  overflow: scroll;
}
.vs {
  display: block;
  position: absolute;
  top: -64px;
  z-index: 100;
  background-color: red;
}
.v-icon {
  color: #01010f;
}

.v-list-item :hover {
  cursor: pointer;
  color: #f9ee08;
}

.pageBtn {
  font-family: "Digi-font";
  font-weight: 600;
  font-size: 1rem;
}

.pageBtn:hover {
  color: #f9ee08;
  background-color: #01010f;
}

.pageBtn:hover .v-icon {
  color: #f9ee08;
}
.m10 {
  margin-top: 64px;
  margin-right: 5%;
}
</style>

<script setup>
import { ref, computed, onMounted, onUnmounted, watch } from "vue";
import * as signalR from "@microsoft/signalr";
import { useRouter } from "vue-router";
import { useStore } from "vuex";
import axios from "axios";

const recipientMessage = ref("test");
const relationMemberAccount = ref("lisi");
const recipientMemberAccount = ref("wangwu");
const relationPostId = ref(1);
const messageContent = ref("TEST");
const loggedAccount = computed(() => store.state.account);
const store = useStore();
const router = useRouter();
const showSnackbar = ref(false);
const baseAddress = "https://localhost:7081/api/";
const notificationKey = ref(0);
const unreadNumber = ref(0);

const items = ref([
  {
    message: "某某人開始追蹤您了",
    memberAccount: "lisi",
    postId: "5",
    link: "/GameLounge/lisi",
  },
  {
    message: "某某人對您的貼文發表留言",
    memberAccount: "lisi",
    postId: "5",
    link: "/GameLounge/Board/7/55",
  },
]);

const fetchNotificationData = async () => {
  try {
    const response = await fetch(`${baseAddress}BoardNotifications`, {
      credentials: "include",
    });
    const datas = await response.json();
    items.value = datas;
    unreadNumber.value = datas.filter((n) => n.isReaded === false).length;
    notificationKey.value = notificationKey.value + 1;
  } catch (err) {
    console.log(err);
  }
};

const linkTo = async (id, link) => {
  try {
    const response = await fetch(`${baseAddress}BoardNotifications/${id}`, {
      method: "put",
      credentials: "include",
    });
    store.commit("postReload");
    fetchNotificationData();
    router.push(link);
  } catch (error) {
    console.error(error);
  }
};

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

const receiveNotificationHandler = (
  recipientMemberAccount,
  relationMemberAccount,
  messageContent,
  relationPostId
) => {
  if (recipientMemberAccount === loggedAccount.value) {
    recipientMessage.value = `${relationMemberAccount} ${messageContent}`;
    showSnackbar.value = true;
    fetchNotificationData();
    if (relationPostId !== 0) {
      store.commit("setPostReloadId", relationPostId);
      store.commit("postReload");
    } else {
      store.commit("reloadAccountAbout");
    }
  }
};

const sendNotification = async (account, loginMember, message, postId) => {
  await store.dispatch("sendNotification", {
    account,
    loginMember,
    message,
    postId,
  });
};

onMounted(() => {
  startTracking();
  fetchNotificationData();
});

onUnmounted(() => {
  connectionToChatHub.off("ReceiveNotification", receiveNotificationHandler);
  connectionToChatHub.stop();
});

watch(
  () => store.state.account,
  (newValue, oldValue) => {
    if (newValue !== oldValue) {
      startTracking();
      fetchNotificationData();
    }
  }
);
</script>
