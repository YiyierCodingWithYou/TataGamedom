<template lang="">
  <v-col cols="5">
    <v-autocomplete
      v-model="boardOrAccount"
      :items="data"
      color="blue-grey-lighten-2"
      item-title="name"
      item-value="param"
      chips
      :auto-select-first="false"
      clearable
      @update:modelValue="linkTo(boardOrAccount)"
    >
      <template v-slot:chip="{ props, item }">
        <v-chip
          v-bind="props"
          :prepend-avatar="item.raw.iconUrl"
          :text="item.raw.name"
        ></v-chip>
      </template>

      <template v-slot:item="{ props, item }">
  <v-list-item
    v-bind="props"
    :prepend-avatar="item?.raw?.iconUrl"
    :title="item?.raw?.name"
    :subtitle="item?.raw?.type"
  ></v-list-item>
</template>
    </v-autocomplete>
  </v-col>
  <v-col cols="6"> <v-text-field label="Keyword"></v-text-field> </v-col>
</template>

<script setup>
import { ref, watch, onMounted } from "vue";
import axios from "axios";
import { useRouter, useRoute } from "vue-router";

const boardOrAccount = ref(null);
const data = ref([]);
const router = useRouter();
const route = useRoute();

const fetchData = () => {
  axios
    .get(`https://localhost:7081/api/Common/Search/BoardOrAccount`)
    .then((res) => {
      data.value = res.data;
    })
    .catch((err) => {
      console.log(err);
    });
};

const linkTo = (value) => {
  console.log(value);
  if (!isNaN(+value)) {
    router.push({
      name: "GameLoungeBoard",
      params: { boardId: value },
    });
  }
  if (isNaN(+value)) {
    console.log("im str");
    router.push({
      name: "GameLoungeAccount",
      params: { account: value },
    });
  }
};

if (route.params.account !== undefined) {
  boardOrAccount.value = route.params.account;
}

if (route.params.boardId !== undefined) {
  boardOrAccount.value = route.params.boardId;
}

onMounted(() => {
  fetchData();
});
</script>
<style scoped>
.w-100px {
  width: 250px;
}
</style>
