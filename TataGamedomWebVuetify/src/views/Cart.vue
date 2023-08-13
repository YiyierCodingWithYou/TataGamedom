<template>
    <v-container>
        <v-tabs v-model="tab" color="deep-purple-accent-4" align-tabs="center">
            <v-tab v-for="item in flows" :key="item" :value="item">
                {{ item }}
            </v-tab>
        </v-tabs>
        <v-window v-model="tab">
            <v-window-item value="購物車">
                <CartItem></CartItem>
            </v-window-item>
            <v-window-item value="填寫資料">
                <Information></Information>
            </v-window-item>
            <v-window-item value="訂單確認">
                <OrderConfirmation></OrderConfirmation>
            </v-window-item>
        </v-window>
    </v-container>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import CartItem from '@/components/Cart/CartItem.vue';
import Information from '@/components/Cart/Information.vue';
import OrderConfirmation from '@/components/Cart/Order-confirmation.vue';

const tab = ref("購物車");
const flows = ["購物車", "填寫資料", "訂單確認"];
</script>

<style></style>