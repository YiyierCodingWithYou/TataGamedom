<template>
  <v-card class="mx-auto" width="256">
    <v-layout>
      <v-navigation-drawer permanent absolute>
        <v-list>
          <v-list-item
            prepend-avatar="https://cdn.vuetifyjs.com/images/john.png"
            title="John Leider"
            subtitle="john@google.com"
          >
            <template v-slot:append> </template>
          </v-list-item>
        </v-list>

        <v-divider></v-divider>

        <v-list :lines="false" density="compact" nav>
          <v-list-item
            v-for="(item, i) in items"
            :key="i"
            :value="item"
            color="primary"
          >
            <template v-slot:prepend>
              <v-icon :icon="item.icon"></v-icon>
            </template>

            <v-list-item-title v-text="item.text"></v-list-item-title>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-main style="height: 190px"></v-main>
    </v-layout>
  </v-card>
</template>
    
<script setup>
import axios from "axios";

const loadMember = async () => {
  const response = await fetch("https://localhost:7081/api/Members/");
};

const items = [
  { text: "個人資料", icon: "mdi-folder" },
  { text: "我的訂單", icon: "mdi-account-multiple" },
  { text: "最愛討論版", icon: "mdi-star" },
];
</script>
    
<style>
</style>