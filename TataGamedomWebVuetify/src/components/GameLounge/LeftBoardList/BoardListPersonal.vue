<template>
  <div>
    <v-list
      item-props
      :items="items"
      lines="two"
      @click:select="openLink"
      select-strategy="single-leaf"
    >
    </v-list>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, defineProps, watch, computed } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useStore } from "vuex";

const items = ref<item>([]);
const allItems = ref<item>([]);
const topFiveItems = ref<item>([]);
const noFavo = ref<item>([]);
const noFollow = ref<item>([]);
const data = ref<boardData>([]);
const router = useRouter();
const props = defineProps({
  memberAccount: {
    type: String,
    required: true,
  },
});

interface item {
  type?: string;
  title?: string;
  subtitle?: string;
  value?: number;
  prependAvatar?: string;
  appendAvatar?: string;
  height?: string | number;
  prependIcon?: string;
  rounded?: string;
  appendIcon?: string;
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

const fetchData = () => {
  axios
    .get(
      `https://localhost:7081/api/Boards?memberAccount=${props.memberAccount}`,
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      items.value = [];
      noFavo.value = [];
      noFollow.value = [];
      data.value = res.data;
      allItems.value = data.value.map((data) => {
        return {
          title: data.name,
          value: data.id,
          rounded: "shaped",
          appendIcon: data.isFavorite ? "mdi-cards-heart" : "",
        };
      });

      topFiveItems.value = data.value
        .filter((item) => item.isFavorite)
        .sort((a, b) => {
          return b.postCurrentCount - a.postCurrentCount;
        })
        .map((data) => {
          return {
            title: data.name,
            value: data.id,
            prependAvatar: data.boardHeaderCoverImgUrl,
            height: "75px",
            rounded: "shaped",
          };
        })
        .slice(0, 5);

      if (topFiveItems.value.length === 0) {
        noFavo.value = {
          title: "尚未有最愛🎮趕緊加入✨",
          baseColor: "pink",
          height: "100px",
        };
      }
      if (allItems.value.length === 0) {
        noFollow.value = {
          title: "尚未追蹤看板👀到處逛逛追蹤吧✨",
          baseColor: "pink",
          height: "100px",
        };
      }
      items.value = items.value
        .concat(headerItem("header", "🕹️熱門最愛"))
        .concat(topFiveItems.value)
        .concat(noFavo.value)
        .concat(divider)
        .concat(headerItem("subheader", "所有追蹤"))
        .concat(allItems.value)
        .concat(noFollow.value)
        .concat(divider);
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

const openLink = (e) => {
  console.log(e.id);

  if (e.id !== undefined) {
    router.push({
      name: "GameLoungeBoard",
      params: { boardId: e.id },
    });
  }
};
</script>
