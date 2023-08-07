<template>
  <v-col cols="12" sm="8">
    <v-sheet min-height="70vh" rounded="lg">
      <v-container>
        <NewPostBtn></NewPostBtn>
        <PostCard></PostCard>
        <PostCard></PostCard>
        <PostCard></PostCard>
      </v-container>
    </v-sheet>
  </v-col>
</template>
<script setup>
import NewPostBtn from "./NewPostBtn.vue";
import PostCard from "./PostCard.vue";
</script>
<style scoped></style>
