<template>
    <div>
    <ul>
      <!-- 使用 v-for 將 classifications 的每個元素都渲染成一個 <li> -->
      <li v-for="classification in classifications" :key="classification.name" @click="classificationHandler(classification.name)">
        {{ classification.name }}
      </li>
    </ul>
  </div>
</template>
    
<script setup>
import { ref, reactive, onMounted } from 'vue'

const keyword = ref("")

const classifications = ref([])

const API = 'https://localhost:7081/api/'

const loadClassification = async () => {
    const response = await fetch(`${API}Products/Classification`)
    const datas = await response.json()
    classifications.value = datas
    console.log(classifications.value)
}
onMounted(() => {
    loadClassification()
})

const emit = defineEmits(["classificationInput"])

const classificationHandler = () => {
    //引發事件 子將資料傳給父
    emit("classificationInput", classification.value)
}
</script>
    
<style></style>