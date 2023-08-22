<script>
import { useStore } from "vuex";

export function createLogisticsOrder{
  const store = useStore();

    const createLogisticsOrderResponse = async (payload) => {
        // const payload = {
        //     "goodsAmount": "100",
        //     "receiverName": "lisi"
        // };

        try {
            const result = await store.dispatch('createLogisticsOrder', payload);
            console.log(result);
        } catch (error) {
            console.error('Error creating logistics order:', error);
        }
    }

    return {
      createLogisticsOrderResponse
    }
};
</script>
