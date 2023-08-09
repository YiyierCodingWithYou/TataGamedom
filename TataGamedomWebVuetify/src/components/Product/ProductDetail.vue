<template>
    <v-row>

            <div class="d-flex flex-no-wrap">
                <div class="ma-3" rounded="0">
                    <v-img :src="imgLink + productData.gameCoverImg" width="450" cover></v-img>
                </div>
                <div class="d-flex flex-column mt-3">
                    <v-card-title class="text-h5">
                        {{ productData.chiName }}
                    </v-card-title>
                    <div class="d-flex text-h3">
                        <v-card-subtitle class="me-auto" v-for="item in productData.coupons" :key="item">
                            {{ item }}
                        </v-card-subtitle>
                        <v-card-subtitle v-for="item in productData.couponDescription" :key="item">
                            {{ item }}
                        </v-card-subtitle>
                    </div>
                    <v-card-subtitle v-if="productData.specialPrice != productData.price">${{ productData.specialPrice }}<s>
                            ${{ productData.price }}</s></v-card-subtitle>
                    <v-card-subtitle v-else="productData.specialPrice===productData.price">${{ productData.price
                    }}</v-card-subtitle>
                    <div class="d-flex">
                        <v-rating v-model="productData.score" class="ma-2 d-flex me-auto" density="compact"
                            readonly></v-rating>
                        <v-card-subtitle>{{ }}個評論</v-card-subtitle>
                    </div>
                    <v-btn class="mt-auto ma-3">加入購物車</v-btn>
                </div>
            </div>
       
    </v-row>
</template>
    
<script setup>
import { ref } from "vue";

const props = defineProps(["productData"]);
const imgLink = "https://localhost:7081/Files/Uploads/";
</script>
    
<style></style>