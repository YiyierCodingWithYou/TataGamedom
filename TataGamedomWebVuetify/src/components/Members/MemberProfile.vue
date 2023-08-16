<template>
  <v-card class="mx-auto" width="256">
    <v-layout>
      <v-navigation-drawer permanent absolute>
        <v-list>
          <v-list-item :prepend-avatar="iconImg" :title="name" :subtitle="email">
          </v-list-item>
        </v-list>
        <v-divider></v-divider>

        <v-list :lines="false" density="compact" nav>
          <v-list-item v-for="( item, i ) in  items " :key="i" :value="item" color="primary"
            @click="handleItemClick(item)">
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
import { ref, onMounted } from "vue";
import { useRouter } from 'vue-router';


const router = useRouter();
const member = ref([]);
const name = ref("");
const iconImg = ref("");
const email = ref("");
let img = "https://localhost:7081/Files/NewsImages/";

const loadMember = async () => {
  const response = await fetch("https://localhost:7081/api/Members", {
    credentials: "include",
  });
  const datas = await response.json();
  member.value = datas.member;
  name.value = datas.name
  iconImg.value = img + datas.iconImg
  email.value = datas.email
  console.log("hiii", datas);
};

onMounted(() => {
  loadMember();
})


const items = [
  { text: "個人資料", icon: "mdi-account" },
  { text: "我的訂單", icon: "mdi-clipboard-text" },
  { text: "最愛討論版", icon: "mdi-star" },
];

const handleItemClick = (item) => {
  if (item.text === "個人資料") {
    gotoDetial();
  }
}

const gotoDetial = () => {
  router.push({
    name: "MemberDetial",
  })
}
</script>
    
<style></style>