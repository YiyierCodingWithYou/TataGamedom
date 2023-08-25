import { createStore } from "vuex";
import OrderStore from "./components/Orders/OrderStore";
import ECpayStore from "./components/ECpay/ECpayStore";
import GameLoungeStore from "./components/GameLounge/GameLoungeStore";

const img = "https://localhost:7081/Files/Uploads/Icons/"
const store = createStore({
  //類似namespace
  modules: {
    OrderStore,
    ECpayStore,
    GameLoungeStore,
  },
  state: {
    isLoggedIn: null,
    name: "",
    account: "",
    age: "",
    iconImg: img + "",
  },
  mutations: {
    SET_LOGIN(state, value) {
      state.isLoggedIn = value.isLoggedIn;
      state.name = value.name;
      state.account = value.account;
      state.age = value.age;
      state.iconImg = img + value.iconImg;
      console.log("StoreLogin", value);
    },
    SET_UPDATEIMG(state, value) {
      state.iconImg = img + value;
    },
  },
});

export default store;
