import { createStore } from "vuex";
import OrderStore from './components/Orders/OrderStore';


const store = createStore({
  modules: {
    OrderStore  //類似namespace
  },
  state: {
    isLoggedIn: false,
    name: "",
    account: "",
  },
  mutations: {
    SET_LOGIN(state, value) {
      state.isLoggedIn = value.isLoggedIn;
      state.name = value.name;
      state.account = value.account;
      // console.log("Updated IsLogined to:", value);
    },
  },
});

export default store;
