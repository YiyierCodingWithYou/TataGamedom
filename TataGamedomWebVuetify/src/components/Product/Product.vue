<template>
    <div>
        <SingleProductCarousel v-if="product !== undefined" :productData="product" ref="bookmark"></SingleProductCarousel>

        <v-main class="bg-grey-lighten-2">
            <v-container>
                <v-row>
                    <v-col cols="3">
                        <v-sheet rounded="lg">
                            <SideBar @searchInput="inputHandler" @classificationInput="classificationHandler"
                                @getProductInput="GetSingleProduct"></SideBar>
                        </v-sheet>
                    </v-col>
                    <v-col>
                        <v-sheet rounded="lg">
                            <ProductDetail v-if="product !== undefined" :productData="product" class="justify-center"
                                @commentSucceed="reload" @paginationInput="paginationHandler"></ProductDetail>
                        </v-sheet>
                    </v-col>
                </v-row>
            </v-container>
        </v-main>

    </div>
</template>
            
<script setup>
import { ref, onMounted, nextTick } from "vue";
import { useRoute, useRouter } from "vue-router";
import SingleProductCarousel from "@/components/Product/SingleProductCarousel.vue";
import ProductDetail from "@/components/Product/ProductDetail.vue";
import { defineEmits } from "vue";
import SideBar from "@/components/eCommerce/SideBar.vue";
import { watch } from "vue";

const route = useRoute();
const router = useRouter();
const bookmark = ref(null);
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
};
loadData();

const paginationHandler = (value) => {
    page.value = value;
    loadData();
};
const reload = () => {
    loadData();
}

const inputHandler = (value) => {
    router.push({
        name: "eCommerce",
        query: {
            keywordInput: value
        }
    })
};

//遊戲分類
const classificationHandler = (value) => {
    router.push({
        name: "eCommerce",
        query: {
            classificationChosen: value
        }
    })
};

//刷新商品頁面
const GetSingleProduct = async (value) => {
    productId.value = parseInt(value, 10);
    router.push({
        name: "SingleProduct",
        params: { productId: productId.value }
    });
};

watch(productId, (newVal, oldVal) => {
    if (newVal !== oldVal) {
        loadData();
        nextTick(() => {
            if (bookmark.value) {
                const offset = bookmark.value.$el.offsetTop;
                window.scrollTo({
                    top: offset,
                    behavior: "smooth",
                });
            }
        });
    }
});

onMounted(() => {
    loadData();
});
</script>
           
<style></style>