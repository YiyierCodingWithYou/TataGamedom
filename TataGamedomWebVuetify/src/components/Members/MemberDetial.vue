<template>
    <h2>是我啦會員資料</h2>
</template>
    
<script setup >
import axios from "axios";
import { ref, onMounted } from "vue";

const member = ref([]);

const loadMember = async () => {
    const response = await fetch("https://localhost:7081/api/Members", {
        credentials: "include",
    });
    const datas = await response.json();
    member.value = datas.member;
    console.log("123132", datas);
};

onMounted(() => {
    loadMember();
})

</script>
    
<style></style>