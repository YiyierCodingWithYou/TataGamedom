import * as signalR from "@microsoft/signalr";
const BASE_URL = "https://localhost:7081";
const GameLoungeStore = {
  state: () => ({
    personalList: [],
    boardListRefreshCount: 0,
    aboutRefreshCount: 0,
    keyword: "",
    postReloadKey: 0,
    postReloadId: 0,
    thisPostReloadKey: 0,
    accountAboutReloadKey: 0,
    fromNotification: false,
    isBucket: false,
  }),
  mutations: {
    setIsBucket(state, bool) {
      state.isBucket = bool;
      console.log("isBucket", state.isBucket);
    },
    fromNotification(state, bool) {
      state.fromNotification = bool;
      console.log("fromNotification", state.fromNotification);
    },
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
    postReload(state) {
      state.postReloadKey++;
      console.log("postReloadkey", state.postReloadKey);
    },
    setPostReloadId(state, id) {
      state.postReloadId = id;
      console.log("setPostReloadId", state.postReloadId);
    },
    thisPostReload(state) {
      state.thisPostReloadKey++;
      console.log("thisPostReloadKey", state.thisPostReloadKey);
    },
    reloadAccountAbout(state) {
      state.accountAboutReloadKey++;
      console.log("accountAboutReloadKey", state.accountAboutReloadKey);
    },
  },
  getters: {},
  actions: {},
};

export default GameLoungeStore;
