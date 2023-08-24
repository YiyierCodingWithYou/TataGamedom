import axios from 'axios';

const BASE_URL = 'https://localhost:7081';

const ECpayStore = {
    state: () => ({
        MerchantTradeNo: '',
        logisticsStatus: ''
    }),
    getters: {
        getMerchantTradeNo: state => state.MerchantTradeNo,
        getLogisticsStatus: state => state.logisticsStatus
    },
    mutations: {
        setMerchantTradeNo: (state, tradeNo) => {
            state.MerchantTradeNo = tradeNo;
        },
        setLogisticsStatus: (state, status) => {
            state.logisticsStatus = status;
        }
    },
    actions: {
        async createLogisticsOrder({ commit }, payload) {
            try {
                const response = await axios.post(`${BASE_URL}/api/ECPay/LogisticsOrder`, payload);
                commit('setMerchantTradeNo', response.data.MerchantTradeNo);
                return response.data;
            } catch (error) {
                throw error;
            }
        },
        async navigateToLogisticsSelection(_, payload) {
            try {
                const response = await axios.post(`${BASE_URL}/api/ECPay/LogisticsSelection`, payload);

                const url = response.data.url;
                window.location = `${BASE_URL}${url}`;

            } catch (error) {
                throw error;
            }
        },
        async getLogisticsTradeInfo({ commit }, payload) {
            try {
                const response = await axios.post(`${BASE_URL}/api/ECPay/LogisticsTradeInfo`, payload);
                commit('setLogisticsStatus', response.data.decodedData.logisticsStatus);
                return response.data;
            } catch (error) {
                throw error;
            }
        }
    }
};

export default ECpayStore;
