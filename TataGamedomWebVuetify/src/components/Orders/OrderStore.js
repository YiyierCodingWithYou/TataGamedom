import axios from 'axios';

const BASE_URL = 'https://localhost:7081';

const OrderStore = {
    state: () => ({
        orders: [],
        orderDetails: {},
        orderItemIdReturnList: {},
    }),
    getters: {
        getOrderById: (state) => (orderId) => {
            return state.orders.find(order => order.id == orderId);
        },
        getOrderDetailsById: (state) => (orderId) => {
            return state.orderDetails[orderId];
        },
        getOrderItemIdReturnList: (state) => (orderId) => {
            return state.orderItemIdReturnList[orderId];
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
        setorderItemIdReturnList(state, { orderId, orderItemIdReturnList }) {
            state.orderItemIdReturnList[orderId] = orderItemIdReturnList;
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
        async fetchOrderItemIdReturnList({ commit }, orderId) {
            try {
                const response = await axios.get(`${BASE_URL}/api/OrderItemReturns/ItemIdList/${orderId}`);
                commit('setorderItemIdReturnList', { orderId, orderItemIdReturnList: response.data });
                console.log("action: fetchOrderItemIdReturnList", response)
            } catch (error) {
                console.error('Failed to fetch OrderItemIdReturnList :', error.message);
            }
        },
        async postOrderItemReturns({ commit }, createOrderItemReturnCommandList,orderId) {
            try {
                const response = await axios.post(
                    `${BASE_URL}/api/OrderItemReturns/MultipleOrderItemsReturn`,
                    createOrderItemReturnCommandList,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }
                );
                if(response.status === 200){
                    await dispatch('fetchOrderItemIdReturnList', orderId);
                }
                //todo: 
                //commit action => fetchOrderItemIdReturnList  
                //commit mutation => update order state (since order status will change after post action)
            } catch (error) {
                console.log('Failed to post order item returns:', error.message);
            }
        },
    }
};

export default OrderStore;