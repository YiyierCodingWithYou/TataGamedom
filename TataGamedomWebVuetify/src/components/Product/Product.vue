<template>
    <div class="shopContainer">
        <div>
            <SingleProductCarousel v-if="product !== undefined" :productData="product">
            </SingleProductCarousel>
        </div>
        <div>
            <v-container class="mt-10">
                <v-row>
                    <v-col cols="3">
                        <v-sheet rounded="lg" color="transparent">
                            <SideBar @searchInput="inputHandler" @classificationInput="classificationHandler"
                                @getProductInput="GetSingleProduct"></SideBar>
                        </v-sheet>
                    </v-col>
                    <v-col cols="9">
                        <v-sheet rounded="lg" color="transparent">
                            <CartDrawer v-model="drawer" class="myDraw" ref="drawerComponent"></CartDrawer>
                            <ProductDetail v-if="product !== undefined" :productData="product" class="justify-center"
                                @commentSucceed="reload" @paginationInput="paginationHandler" @drawerInput="drawerHandler">
                            </ProductDetail>
                        </v-sheet>
                    </v-col>
                </v-row>
            </v-container>
        </div>

    </div>
</template>
            
<script setup>
import { ref, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import SingleProductCarousel from "@/components/Product/SingleProductCarousel.vue";
import ProductDetail from "@/components/Product/ProductDetail.vue";
import { defineEmits } from "vue";
import SideBar from "@/components/eCommerce/SideBar.vue";
import { watch } from "vue";
import CartDrawer from "@/components/eCommerce/CartDrawer.vue";

const drawer = ref(false);
const drawerComponent = ref(null)
const route = useRoute();
const router = useRouter();
const productId = ref(parseInt(route.params.productId, 10));
const page = ref(1);
const product = ref({});
const totalPages = ref(0);

const loadData = async () => {
    const response = await fetch(
        `https://localhost:7081/api/Products/${productId.value}?page=${page.value}`
    );
    const datas = await response.json();
    product.value = datas;
    totalPages.value = datas.totalPages;
    productId.value = parseInt(route.params.productId, 10);
};

const paginationHandler = (value) => {
    page.value = value;
    loadData();
};
const reload = () => {
    loadData();
};

const inputHandler = (value) => {
    router.push({
        name: "eCommerce",
        query: {
            keywordInput: value,
        },
    });
};

//遊戲分類
const classificationHandler = (value) => {
    router.push({
        name: "eCommerce",
        query: {
            classificationChosen: value,
        },
    });
};

//刷新商品頁面
const GetSingleProduct = async (value) => {
    productId.value = parseInt(value, 10);
    router.push({
        name: "SingleProduct",
        params: { productId: productId.value },
    });
};

watch(productId, (newVal, oldVal) => {
    if (newVal !== oldVal) {
        loadData();
    }
});

const drawerHandler = (value) => {
    if (value === "已成功加入購物車！") {
        autoToggleDrawer();
    }
}

const autoToggleDrawer = () => {
    openDrawerFromParent();
    setTimeout(() => {
        closeDrawer();
    }, 1000);
};

const openDrawerFromParent = () => {
    drawerComponent.value.drawerContent();
    drawer.value = true;
    console.log('func:openDrawerFromParent');
};

const closeDrawer = () => {
    drawer.value = false;
    console.log('func:closeDrawer');
};

onMounted(() => {
    loadData();
});
</script>
           
<style scoped>
.v-container {
    max-width: 90%;
}

.shopContainer {
    background-color: #01010f;
    color: #f9ee08;
}

.myDraw {
    position: fixed;
    bottom: 20px;
    right: 20px;
    z-index: 20;
}
</style>