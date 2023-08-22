const BASE_URL = "https://localhost:7081";

const GameLoungeStore = {
  state: () => ({
    personalList: [],
    count: 0,
  }),
  mutations: {
    increment(state) {
      state.count++;
      console.log("increment", state.count);
    },
  },
  getters: {},
  actions: {},
};

export default GameLoungeStore;
