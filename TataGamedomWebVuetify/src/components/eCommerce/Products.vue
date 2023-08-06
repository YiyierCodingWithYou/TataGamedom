<template>
    <div>
        <v-carousel show-arrows="hover">
            <v-carousel-item src="https://cdn.vuetifyjs.com/images/cards/docks.jpg" cover></v-carousel-item>

            <v-carousel-item src="https://cdn.vuetifyjs.com/images/cards/hotel.jpg" cover></v-carousel-item>

            <v-carousel-item src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg" cover></v-carousel-item>
        </v-carousel>
    </div>
</template>
    
<script setup>
import {ref, reactive, onMounted} from 'vue'
const keyword = ref("")
const classification = ref("")
const sortBy = ref("")
const isAscending = ref("")
   const products = ref([])
   const totalPages = ref(1)  //共幾頁
   const thePage = ref(1)  //第幾頁
   const API = import.meta.env.VITE_API_URL
    const loadProducts = async ()=>{
       
      const response = await fetch(`${API}Products?keyword=${keyword.value}&classification=${classification.value}&sortBy=${sortBy.value}&isAscending=${isAscending.value}`)
      const datas = await response.json()
      products.value = datas.products
      console.log(products.value)
      totalPages.value = datas.totalPages
    }

</script>
    
<style></style>