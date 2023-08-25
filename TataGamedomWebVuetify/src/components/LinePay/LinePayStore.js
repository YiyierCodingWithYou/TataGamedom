export default {
    state: {
      totalAmount: 0
    },
    mutations: {
      setTotalAmount(state, amount) {
        state.totalAmount = amount;
      }
    },
    actions: {
      updateTotalAmount({ commit }, amount) {
        commit('setTotalAmount', amount);
      }
    },
    getters: {
      getTotalAmount(state) {
        return state.totalAmount;
      }
    }
  }
  