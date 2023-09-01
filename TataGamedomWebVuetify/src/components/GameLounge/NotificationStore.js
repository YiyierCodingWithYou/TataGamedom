import * as signalR from "@microsoft/signalr";
import { log } from "async";
const BASE_URL = "https://localhost:7081";
const Notification = {
  state: () => ({
    connectionToChatHub: new signalR.HubConnectionBuilder()
      .withUrl(`${BASE_URL}/NotificationHub`)
      .build(),
  }),
  mutations: {},
  getters: {},
  actions: {
    async sendNotification(
      { state },
      { account, loginMember, message, postId }
    ) {
      try {
        if (
          state.connectionToChatHub.state ===
          signalR.HubConnectionState.Disconnected
        ) {
          await state.connectionToChatHub.start();
        }

        await state.connectionToChatHub.send(
          "SendNotificationToSpecificlMember",
          account,
          loginMember,
          message,
          postId
        );
      } catch (error) {
        console.error(error);
      }
    },
  },
};

export default Notification;
