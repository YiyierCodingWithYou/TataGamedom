<template>
  <div class="d-flex">
    <v-autocomplete
      label="看板名稱"
      :items="boardList"
      item-title="name"
      item-value="id"
      v-model="selectedBoard"
      @update:modelValue="sendEmit"
    ></v-autocomplete>
  </div>
</template>

<script setup lang="">
import { ref, watch, defineProps, defineEmits, onMounted } from "vue";
import axios from "axios";

const emits = defineEmits(["selected"]);
const selectedBoard = ref(null);
const boardList = ref([]);
const boardNameList = ref([]);

const getBoardsList = async () => {
  const res = await axios.get("https://localhost:7081/api/boards", {
    withCredentials: true,
  });
  boardList.value = res.data;
};

const sendEmit = () => {
  emits("selected", selectedBoard.value);
};

onMounted(() => {
  getBoardsList();
});
</script>
<style></style>
