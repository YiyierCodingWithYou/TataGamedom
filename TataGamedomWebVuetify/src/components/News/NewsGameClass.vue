<template>
  <div>
    <ul>
      <li v-for="classification in classifications" :key="classification.name">
        <button @click.prevent="classificationHandler(classification.name)" :class="{
          'link-like-button': true,
          'selected-item': selectedClassification === classification.name,
        }">
          {{ classification.name }}
        </button>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted, defineEmits } from "vue";

const classifications = ref([]);
const selectedClassification = ref("");

const API = "https://localhost:7081/api/";

const loadClassification = async () => {
  const response = await fetch(`${API}Products/Classification`);
  const datas = await response.json();
  classifications.value = datas;
};
onMounted(() => {
  loadClassification();
});

const emit = defineEmits(["classificationInput"]);

const classificationHandler = (name) => {
  selectedClassification.value = name;
  //
  emit("classificationInput", name);
};
</script>

<style>
ul {
  list-style: none;
}

.selected-item {
  background-color: #f9ee08;
}
</style>