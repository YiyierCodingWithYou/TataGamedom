<template>
  <NewPostBtn @postComplete="reload"></NewPostBtn>
  <PostCard
    v-for="post in posts"
    :key="post.postId"
    :post="post"
    @deletePost="reload"
  ></PostCard>
  <InfiniteLoading @infinite="loadPosts" :key="reloadKey" ref="infiniteLoading">
    <template #complete>
      <p class="text-center">看完了，不妨到處逛逛？🦦</p>
    </template>
    <template #spinner>
      <div class="d-flex justify-center align-center">
        <img
          src="https://i.gifer.com/PYh.gif"
          style="max-height: 60px"
          alt="Loading..."
        />
      </div>
    </template>
  </InfiniteLoading>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, watch } from "vue";
import NewPostBtn from "./NewPostBtn.vue";
import PostCard from "./PostCard.vue";
import InfiniteLoading from "v3-infinite-loading";
import "v3-infinite-loading/lib/style.css"; //required if you're not going to override default slots
import { useRoute } from "vue-router";
import { useStore } from "vuex";
import { tr } from "date-fns/locale";

interface Comment {
  commentContent: string;
  dateTime: string;
  memberAccount: string;
  memberName: string;
  voteUp: number;
  voteDown: number;
  voted: string;
  comments: Comment[];
}

interface Post {
  postId: string;
  title: string;
  postContent: string;
  memberId: number;
  memberAccount: string;
  memberName: string;
  voteUp: number;
  voteDown: number;
  commentCount: number;
  isEdited: boolean;
  isAuthor: boolean;
  voted: string;
  comments: Comment[];
}

const props = defineProps({
  memberAccount: {
    type: String,
    default: "",
  },
  boardId: {
    type: String,
    default: "",
  },
  keyword: {
    type: String,
    default: "",
  },
});

const baseaddress = "https://localhost:7081/api/";
const page = ref<number>(1);
const postId = ref(0);
const posts = ref<Post[]>([]);
const route = useRoute();
const store = useStore();
const infiniteLoading = ref<any>(null);
const keyword = computed(() => store.state.GameLoungeStore.keyword);
const reloadKey = ref(0);
postId.value = +route.params.postId;

const loadPosts = async ($state: any) => {
  if (route.params.postId) {
    const response = await fetch(`${baseaddress}Posts/${route.params.postId}`, {
      credentials: "include",
    });
    const datas = await response.json();
    posts.value = [].concat(datas);
    $state.complete();
    return;
  }
  try {
    const response = await fetch(
      `${baseaddress}Posts?page=${page.value}&keyword=${keyword.value}&memberAccount=${props.memberAccount}&boardId=${props.boardId}`,
      {
        credentials: "include",
      }
    );
    const datas = await response.json();

    if (datas.length === 0) {
      $state.complete();
    } else {
      posts.value.push(...datas);
      $state.loaded();
      page.value++;
    }
    console.log(page.value);
  } catch (error) {
    console.error("Error loading posts:", error);
    $state.error();
  }
};

const reload = () => {
  console.log("reload起來");
  page.value = 1;
  posts.value = [];
  reloadKey.value++;
};

watch(keyword, (newVal, oldVal) => {
  if (newVal !== oldVal) {
    console.log("keyword changed 我要reload");
    reload();
  }
});
</script>
<style lang=""></style>
