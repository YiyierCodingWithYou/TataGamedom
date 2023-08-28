<template lang="">
  <div class="text-center">
    <div @click="dialog = true" class="clickBtn m-0 p-o">
      <slot name="clickBtn"> </slot>
    </div>

    <v-dialog v-model="dialog" width="auto">
      <v-card>
        <v-card-title>
          <slot name="title"> </slot>
        </v-card-title>
        <v-card-text>
          <v-card class="mx-auto" max-width="300">
            <v-list item-props :items="items" @click:select="openLink"></v-list>
          </v-card>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>

<style scoped></style>
<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
const dialog = ref(false);
const items = ref([]);
const router = useRouter();
const props = defineProps({
  data: {
    type: Array,
  },
});

const openLink = (e) => {
  router.push({
    name: "GameLoungeAccount",
    params: { account: e.id },
  });
};

items.value = props.data;
</script>
