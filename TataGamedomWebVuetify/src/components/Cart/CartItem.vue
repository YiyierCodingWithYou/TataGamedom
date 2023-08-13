<template>
    <v-container>
        <v-sheet>
            <v-table>
                <thead>
                    <tr>
                        <th></th>
                        <th>商品名稱</th>
                        <th class="text-end">單件價格</th>
                        <th class="text-end">數量</th>
                        <th class="text-end">小計</th>
                        <th class="text-end"></th>
                    </tr>
                </thead>

                <tbody>
                    <tr v-for="item in cartItems" :key="item.product.id">
                        <td><img :src="imgLink + item.product.gameCoverImg" height="150" cover></td>
                        <td v-text="item.product.chiName"></td>
                        <td class="text-end" v-text="item.product.price"></td>
                        <td class="text-end" v-text="item.qty"></td>
                        <td class="text-end" v-text="item.subTotal"></td>
                        <td class="text-end">
                            <v-icon @click="removeItem(item.product.id)">mdi-cart-remove</v-icon>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th>總計：</th>
                        <th class="text-end">
                            NT${{ calculateTotal }}
                        </th>
                    </tr>
                    <tr>
                        <th>Total</th>
                        <th></th>
                        <th></th>
                        <th class="text-end">
                            ${{ calculateTotal }}
                        </th>
                        <th></th>
                    </tr>
                </tbody>
            </v-table>
        </v-sheet>
    </v-container>
</template>
    
<script setup lang='ts'>
import { ref, computed } from 'vue';

const cartData = ref({});
const cartItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";


const loadData = async () => {
    const response = await fetch(
        `https://localhost:7081/api/Carts`, {
        method: "GET",
        credentials: "include",
    });
    const datas = await response.json();
    cartData.value = datas;
    cartItems.value = datas.cartItems
    console.log(cartItems.value);
};

const calculateTotal = computed(() => {
    return cartItems.value.reduce((total, item) => total + item.subTotal, 0);
});

const removeItem = async (value) => {
    console.log(value);

    //   const response = await fetch(
    //         `https://localhost:7081/api/Carts`, {
    //         method: "DELETE",
    //         credentials: "include",
    //         headers: {
    //         "Content-Type": "application/json",
    //       },
    //       body: JSON.stringify({
    //         productId: value,
    //         qty: 1,
    //       }),
    //     });
    //     const result = await response.json();
};

loadData();
</script>
    
<style></style>