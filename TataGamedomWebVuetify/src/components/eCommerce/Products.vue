<template>
    <div>
        <v-carousel show-arrows="hover">
            <v-carousel-item src="https://cdn.vuetifyjs.com/images/cards/docks.jpg" cover></v-carousel-item>

            <v-carousel-item src="https://cdn.vuetifyjs.com/images/cards/hotel.jpg" cover></v-carousel-item>

            <v-carousel-item src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg" cover></v-carousel-item>
        </v-carousel>
    </div>
    <div class="container mt-10">
        <v-row class="row">
            <v-col cols="2">
                <div>關鍵字搜尋</div>
                <SearchTextBox @searchInput="inputHandler" autofocus></SearchTextBox>
                <hr>
                <div>依遊戲分類瀏覽</div>
                <ClassificationList @classificationInput="classificationHandler"></ClassificationList>
            </v-col>
            <v-col cols="10">
                <v-row>
                    <v-col cols="4" v-for="product in products" :key="product.id">
                        <v-card>
                            <v-img class="align-end text-white" height="200" :src="img+product.gameCoverImg" cover></v-img>
                            <v-card-title class="pt-2 justify-center text-center">
                                {{ product.chiName }}
                            </v-card-title>
                            <v-chip class="ma-1 d-flex justify-center" color="primary" label text-color="white">
                                <v-icon start icon="mdi-label"></v-icon>
                                {{ product.gamePlatformName }}
                            </v-chip>

                            <v-card-text class="d-flex justify-center">
                                <div><s>{{ product.price }}</s></div>
                                <div>　</div>
                                <div>{{ product.specialPrice }}</div>
                            </v-card-text>

                            <v-rating v-model="product.score" class="ma-2 d-flex justify-center" density="compact"
                                readonly></v-rating>

                            <v-card-actions class="justify-center">
                                <v-btn color="orange">加入購物車</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
    </div>
    <div class="text-center">
        <v-pagination v-model="thePage" :length="totalPages" :total-visible="5" @click="clickHandler"></v-pagination>
    </div>
</template>
    
<script setup>
import { ref, reactive, onMounted } from 'vue'
import SearchTextBox from '../eCommerce/SearchTextBox.vue'
import ClassificationList from '../eCommerce/ClassificationList.vue'


const keyword = ref("")
const classification = ref("")
const sortBy = ref("")
const isAscending = ref("")
const products = ref([])
const totalPages = ref(1)  //共幾頁
const thePage = ref(1)  //第幾頁
const API = 'https://localhost:7081/api/'//import.meta.env.VITE_API_URL
const loadProducts = async () => {
    
    const response = await fetch(`${API}Products?keyword=${keyword.value}&classification=${classification.value}&sortBy=${sortBy.value}&isAscending=${isAscending.value}&page=${thePage.value}`)
    const datas = await response.json()
    products.value = datas.products
    console.log(products.value)
    totalPages.value = datas.totalPages
}

let img = 'https://localhost:7081/Files/Uploads/'

// onMounted(() => {
//     loadProducts()
// })

//搜尋
const inputHandler = value => {
    keyword.value = value
    loadProducts()
}

//遊戲分類
const classificationHandler = value => {
    classification.value = value
    loadProducts()
}

//分頁
const clickHandler = (page) => {
    thePage.value = page
    loadProducts()
}
onMounted(() => {
    loadProducts()
})
</script>
    
<style>
.currentPage {
    background-color: lightgray;
}

.pagination li {
    cursor: pointer;
}
</style>