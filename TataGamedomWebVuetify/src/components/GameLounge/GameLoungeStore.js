const BASE_URL = "https://localhost:7081";

const GameLoungeStore = {
  state: () => ({
    personalList: [],
    boardListRefreshCount: 0,
    aboutRefreshCount: 0,
    keyword: "",
  }),
  mutations: {
    boardListRefresh(state) {
      state.boardListRefreshCount++;
      console.log("boardListRefresh", state.boardListRefreshCount);
    },
    aboutRefresh(state) {
      state.aboutRefreshCount++;
      console.log("aboutRefresh", state.aboutRefreshCount);
    },
    setKeyword(state, keyword) {
      state.keyword = keyword;
      console.log("setKeyword", state.keyword);
    },
  },
  getters: {},
  actions: {},
};

export default GameLoungeStore;
