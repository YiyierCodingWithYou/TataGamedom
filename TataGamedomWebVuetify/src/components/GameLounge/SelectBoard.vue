<template>
  <div class="d-flex">
    <v-autocomplete
      v-if="boardList.length > 0"
      label="看板名稱"
      :items="boardList"
      item-title="name"
      item-value="id"
      v-model="selectedBoard"
      @update:modelValue="sendEmit"
      variant="underlined"
    ></v-autocomplete>
  </div>
</template>

<script setup lang="">
import { ref, watch, defineProps, defineEmits, onMounted } from "vue";
import axios from "axios";
import { useRoute } from "vue-router";
const route = useRoute();
const emits = defineEmits(["selected"]);
const selectedBoard = ref(null);
const boardList = ref([]);
const boardNameList = ref([]);
const boardId = ref(0);

const getBoardsList = async () => {
  const res = await axios.get("https://localhost:7081/api/boards", {
    withCredentials: true,
  });
  boardList.value = res.data;
  boardList.value = boardList.value.filter((item) => item.isBucket === false);
  if (route.params.boardId !== undefined) {
    selectedBoard.value = +route.params.boardId;
  }
};

const sendEmit = () => {
  emits("selected", selectedBoard.value);
};

onMounted(() => {
  getBoardsList();
});
</script>
<style></style>
