import axios from 'axios';

const BASE_URL = 'https://localhost:7081';

const OrderStore = {
    state: () => ({
        orders: [],
        orderDetails: {},
        orderItemReturnList: {},
    }),
    getters: {
        getOrderById: (state) => (orderId) => {
            return state.orders.find(order => order.id == orderId);
        },
        getOrderDetailsById: (state) => (orderId) => {
            return state.orderDetails[orderId];
        },
        getorderItemReturnList: (state) => (orderId) => {
            return state.orderItemReturnList[orderId];
        },
    },
    mutations: {
        setOrders(state, orders) {
            console.log("Orders received for mutation:", orders);
            state.orders = orders;
        },
        setOrderDetails(state, { orderId, details }) {
            state.orderDetails[orderId] = details;
        },
        setorderItemReturnList(state, { orderId, orderItemReturnList }) {
            state.orderItemReturnList[orderId] = orderItemReturnList;
        },
    },
    actions: {
        async fetchOrders({ commit }) {
            try {
                const response = await axios.get(`${BASE_URL}/api/Orders`, { withCredentials: true });
                commit('setOrders', response.data);
            } catch (error) {
                console.error('Failed to fetch orders:', error.message);
            }
        },
        async fetchOrderDetails({ commit }, orderId) {
            try {
                const response = await axios.get(`${BASE_URL}/api/OrderItems/order/${orderId}`);
                commit('setOrderDetails', { orderId, details: response.data });
                console.log("action: fetchOrderDetails", response)
            } catch (error) {
                console.error('Failed to fetch order details:', error.message);
            }
        },
        async fetchorderItemReturnList({ commit }, orderId) {
            try {
                const response = await axios.get(`${BASE_URL}/api/OrderItemReturns/ItemIdList/${orderId}`);
                commit('setorderItemReturnList', { orderId, orderItemReturnList: response.data });
                console.log("action: fetchorderItemReturnList", response)
            } catch (error) {
                console.error('Failed to fetch orderItemReturnList :', error.message);
            }
        },
        async postOrderItemReturns({ commit, dispatch }, payload) {
            const { requestData, orderId } = payload;
            try {
                console.log(requestData, orderId)
                const response = await axios.post(
                    `${BASE_URL}/api/OrderItemReturns/MultipleOrderItemsReturn`,
                    requestData,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }
                );
                if (response.status === 200) {
                    await dispatch('fetchorderItemReturnList', orderId);
                    await dispatch('fetchOrders');
                }
            } catch (error) {
                console.log('Failed to post order item returns:', error.message);
            }
        },
        async deleteCartsByMemberId({ commit }, memberId) {
            try {
                const response = await axios.delete(`${BASE_URL}/api/Orders/Carts/${memberId}`)
                if (response.status === 202 || response.status === 204) {
                    console.log('購物車已清空');
                }

            } catch (error) {
                console.log(memberId)
                console.log('清空購物車失敗', error.message)
            }
        }
    }
};

export default OrderStore;