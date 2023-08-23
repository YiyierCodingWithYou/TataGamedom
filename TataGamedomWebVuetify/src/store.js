import { createStore } from "vuex";
import OrderStore from './components/Orders/OrderStore';
import ECpayStore from './components/ECpay/ECpayStore';

const store = createStore({
  //類似namespace
  modules: {
    OrderStore,
    ECpayStore
    GameLoungeStore,
  },
  state: {
    isLoggedIn: false,
    name: "",
    account: "",
    age: "",
  },
  mutations: {
    SET_LOGIN(state, value) {
      state.isLoggedIn = value.isLoggedIn;
      state.name = value.name;
      state.account = value.account;
      state.age = value.age;
      console.log("StoreLogin", value);
    },
    SET_UPDATENAME(state, value) {
      state.name = value;
    },
  },
});

export default store;
