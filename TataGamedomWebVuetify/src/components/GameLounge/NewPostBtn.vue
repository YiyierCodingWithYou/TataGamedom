<template>
  <v-row>
    <v-col cols="12" id="k">
      <v-text-field
        placeholder="發表貼文"
        prepend-icon="mdi-paw"
        variant="solo"
        @click="hi"
      ></v-text-field>
    </v-col>
  </v-row>
</template>
<script setup>
import { ref } from "vue";

const hi = () => {
  alert("hi");
};
</script>
<style scoped></style>
