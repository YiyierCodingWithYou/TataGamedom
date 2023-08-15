import { createStore } from 'vuex';
import axios from 'axios';

const BASE_URL = 'https://localhost:7081';

export default createStore({
    state: {
        orders: [],
        orderDetails: {}
    },
    mutations: {
        setOrders(state, orders) {
            state.orders = orders;
        },
        setOrderDetails(state, { orderId, details }) {
            state.orderDetails[orderId] = details;
        }
    },
    actions: {
        async fetchOrders({ commit }) {
            try {
                const response = await axios.get(`${BASE_URL}/api/Orders`);
                commit('setOrders', response.data);
            } catch (error) {
                console.error('Failed to fetch orders:', error.message);
            }
        },
        async fetchOrderDetails({ commit }, orderId) {
            try {
                const response = await axios.get(`${BASE_URL}/api/OrderItems/order/${orderId}`);
                commit('setOrderDetails', { orderId, details: response.data });
            } catch (error) {
                console.error('Failed to fetch order details:', error.message);
            }
        }
    }
});
