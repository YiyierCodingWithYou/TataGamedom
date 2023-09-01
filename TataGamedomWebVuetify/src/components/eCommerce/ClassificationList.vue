<template>
  <div>
    <v-list v-for="classification in classifications" :key="classification.name" density="compact" style="background-color: #01010f; color:#f9ee08" class="ml-5">
      <v-list-item @click.prevent="classificationHandler(classification.name)" :class="{
            'selected-item': selectedClassification === classification.name,
          }">
        {{ classification.name }}
      </v-list-item>
    </v-list>

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
  emit("classificationInput", name);
};
</script>

<style>
.selected-item {
  background-color:  #fbf402 !important;
  color:#01010f !important;
}
</style>