<template>
    <p v-if="isLoading">Loading...</p>
    <p v-else-if="!isLoading && error">{{ error }}</p>
    <p v-else-if="!isLoading && (!results || results.length === 0)">無訂單紀錄</p>

    <v-table v-else fixed-header density="comfortable" hover="true" height="800" >
        <thead>
            <tr>
                <th class="text-left">
                    遊戲
                </th>
                <th class="text-left">
                    類型
                </th>
                <th class="text-left">
                    日期
                </th>
                <th class="text-left">
                    總額
                </th>
                <th class="text-left">
                    訂單狀態
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in results" :key="order.id" @click="navigateToOrderDetail(order)">
                <td v-html="gameNamesWithBreaks(order.gameChiName)"></td>
                <td v-html="productIsVirtualWithBreaks(order.productIsVirtual)"></td>
                <td>{{ order.createdAt }}</td>
                <td>{{ order.total }}</td>
                <td>{{ order.orderStatusCodeName }}</td>
            </tr>
        </tbody>
    </v-table>
</template>
  
<script>
export default {
    data() {
        return {
            results: []
        }
    },
    methods: {
        loadData() {
            fetch('https://localhost:7081/api/Orders',{
                credentials: "include"
            })
                .then((response) => {
                    if (response.ok) {
                        return response.json();
                    }
                })
                .then((data) => {
                    this.isLoading = false;
                    const results = [];
                    for (const id in data) {
                        results.push({
                            id: id,
                            orderId: data[id].id,
                            gameChiName: data[id].gameChiName,
                            productIsVirtual: data[id].productIsVirtual,
                            createdAt: data[id].createdAt,
                            total: data[id].total,
                            orderStatusCodeName: data[id].orderStatusCodeName,
                        });
                    }
                    this.results = results;
                })
                .catch((error) => {
                    this.isLoading = false;
                    console.log(error);
                    this.error = 'Failed to fetch data - please try again later.';
                });
        },
        gameNamesWithBreaks(gameNames) {
            return gameNames.join('<br><br>');
        },
        productIsVirtualWithBreaks(productIsVirtual) {
            const transformedNames = productIsVirtual.map(productIsVirtual => productIsVirtual ? '序號' : '遊戲片');
            return transformedNames.join('<br><br>');
        },
        navigateToOrderDetail(order) {
            this.$router.push({ name: 'OrderDetails', params: { id: order.orderId } })
        }
    },
    mounted() {
        this.loadData();
    },
}
</script>

<style scoped>
</style>