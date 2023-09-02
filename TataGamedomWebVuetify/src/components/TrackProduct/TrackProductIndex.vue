<template>
    <v-container>
        <v-breadcrumbs :items="['獺獺玩國', '會員中心', '最愛商品']"></v-breadcrumbs>
        <v-sheet v-if="trackList?.trackItems?.length > 0" class="mySheet">
            <v-table>
                <thead class="text-center justify-center align-center">
                    <tr>
                        <th class="myTh"></th>
                        <th class="myTh">遊戲平台</th>
                        <th class="myTh">商品名稱</th>
                        <th class="myTh">單件價格</th>
                        <th class="myTh">購買狀態</th>
                        <th class="myTh"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in trackList.trackItems" :key="item.id" class="mb-3">
                        <td class="myTd">
                            <img :src="imgLink + item.gameCoverImg" height="100" cover />
                        </td>
                        <td class="myTd">
                            <v-chip color="#a1dfe9" label>
                                <v-icon start icon="mdi-gamepad-right"></v-icon>
                                {{ item.gamePlatformName }}
                            </v-chip>
                            <div v-if="item.isVirtual" style="font-size: 12px;">※虛擬商品</div>
                        </td>
                        <td class="myTd">
                            <div style="text-align: center;">{{ item.chiName }}</div>
                        </td>
                        <td v-if="item.price != item.specialPrice" class="myTd">
                            <div>
                                <s>{{ unitExchange(item.price) }}</s>
                            </div>
                            <div>{{ unitExchange(item.specialPrice) }}</div>
                        </td>
                        <td v-else class="myTd">{{ unitExchange(item.price) }}</td>
                        <td class="myTd" v-if="item.stockQuantity > 0"><v-btn @click="Add2Cart(item.id)">加入購物車</v-btn></td>
                        <td class="myTd" v-else>無法購買</td>
                        <td class="text-end">
                            <v-icon @click="removeItem(item.id)">mdi-cart-remove</v-icon>
                        </td>

                    </tr>
                </tbody>
            </v-table>
        </v-sheet>
        <v-sheet v-else class="text-center myComment">目前無追蹤商品，<a href="/eCommerce"
                style="color:#a1dfe9">點我到商城逛逛！</a></v-sheet>
    </v-container>
</template>
    
<script setup>
import { ref, onMounted } from "vue";
import Swal from 'sweetalert2';

const trackList = ref({});
const trackItems = ref([]);
const imgLink = "https://localhost:7081/Files/Uploads/";

const loadData = async () => {
    const response = await fetch(`https://localhost:7081/api/Products/TrackProducts`,
        {
            method: "GET",
            credentials: "include",
        });
    const datas = await response.json();
    trackList.value = datas;
    console.log(trackList.value);
    trackItems.value = datas.trackItems;
}

const unitExchange = (x) => {
    return 'NT$ ' + x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

const removeItem = async (productId) => {
    Swal.fire({
        title: '確認取消追蹤此商品？',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: ' #a1dfe9',
        cancelButtonColor: '#f9ee08',
        cancelButtonText: '取消',
        confirmButtonText: '確認'
    }).then(async (result) => {
        if (result.isConfirmed) {
            const response = await fetch(
                `https://localhost:7081/api/Products/TrackProducts?productId=${productId}`,
                {
                    method: "POST",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json",
                    },
                }
            )
                .then(() => {
                    loadData();
                })
                .catch((error) => {
                    console.error("Error:", error);
                });
        }
    })
}

const Add2Cart = async (productId) => {
    const response = await fetch(`https://localhost:7081/api/Carts`, {
        method: "POST",
        credentials: "include",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            productId: productId,
            qty: 1,
        }),
    });
    let result = await response.json();
    if (result.isSuccess) {
        Swal.fire('成功', '商品已加入購物車', 'success');
    }
};



onMounted(() => {
    loadData();
})

</script>
    
<style>
.v-container {
    max-width: 90% !important;
}

.v-table {
    background-color: #01010f;
    color: white !important;
}

.myTh {
    text-align: center !important;
    color: #f9ee08 !important;
    width: auto;
}

.myTd {
    text-align: center !important;
    justify-items: center !important;
    align-items: center !important;
    width: auto;
}
</style>