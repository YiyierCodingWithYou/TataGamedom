<template>
  <v-list item-props :items="items" @click:select="openLink"> </v-list>
</template>

<script setup lang="ts">
import { ref, onMounted, watch, computed } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useStore } from "vuex";

const items = ref<item>([]);
const allItems = ref<item>([]);
const topFiveItems = ref<item>([]);
const data = ref<boardData>([]);

interface item {
  type?: string;
  title?: string;
  subtitle?: string;
  value?: number;
  prependAvatar?: string;
  appendAvatar?: string;
  height?: string | number;
  prependIcon?: string;
}

interface boardData {
  id: number;
  name: string;
  boardAbout: string;
  boardHeaderCoverImgUrl: string;
  isFollowed: boolean;
  isFavorite: boolean;
  postCurrentCount: number;
}

const divider: item = {
  type: "divider",
};

const headerItem = (type: string, title: string): item => {
  const result = {
    type: type,
    title: title,
  };
  return result;
};

const searchItem: item = {
  prependIcon: "mdi-magnify",
  title: "Search",
  value: "search",
  rounded: "xl",
  baseColor: "blue",
};

const fetchData = () => {
  items.value = [];
  axios
    .get(`https://localhost:7081/api/Boards`, {
      withCredentials: true,
    })
    .then((res) => {
      data.value = res.data.sort((a, b) => {
        return a.name.localeCompare(b.name, "zh-TW");
      });

      allItems.value = data.value.map((data) => {
        return {
          title: data.name,
          value: data.id,
          rounded: "shaped",
          appendIcon: data.isFavorite ? "mdi-cards-heart" : "",
        };
      });

      topFiveItems.value = data.value
        .sort((a, b) => {
          return b.postCurrentCount - a.postCurrentCount;
        })
        .map((data) => {
          return {
            title: data.name,
            value: data.id,
            prependAvatar: "",
            prependAvatar: data.boardHeaderCoverImgUrl,
            height: "75px",
            rounded: "shaped",
          };
        })
        .slice(0, 5);

      console.log(data.value);
      console.log(topFiveItems.value);
      items.value = items.value
        .concat(headerItem("header", "🕹️熱門巢穴"))
        .concat(topFiveItems.value)
        .concat(divider)
        .concat(headerItem("subheader", "ALL"))
        .concat(searchItem)
        .concat(allItems.value);
    })
    .catch((err) => {
      console.log(err);
    });
};

onMounted(() => {
  fetchData();
});

const store = useStore();
const count = computed(() => store.state.GameLoungeStore.count);

watch(count, (newValue, oldValue) => {
  fetchData();
});

const router = useRouter();

const openLink = (e) => {
  console.log(e.id);

  if (e.id !== undefined && e.id !== "search") {
    router.push({
      name: "GameLoungeBoard",
      params: { boardId: e.id },
    });
  }
};
</script>
