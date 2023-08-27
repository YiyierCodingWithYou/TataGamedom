<template>
  <NewPostBtn @postComplete="reloadPosts"></NewPostBtn>
  <PostCard
    v-for="post in posts"
    :key="post.postId"
    :post="post"
    @deletePost="reloadPosts"
  ></PostCard>
  <InfiniteLoading @infinite="loadPosts" :key="reloadKey">
    <template #complete>
      <p class="text-center">已經看完所有貼文🦦</p>
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
import { ref, onMounted } from "vue";
import NewPostBtn from "./NewPostBtn.vue";
import PostCard from "./PostCard.vue";
import InfiniteLoading from "v3-infinite-loading";
import "v3-infinite-loading/lib/style.css"; //required if you're not going to override default slots

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
const reloadKey = ref<number>(0);
const page = ref<number>(1);
const baseaddress = "https://localhost:7081/api/";
const posts = ref<Post[]>([]);
const loadPosts = async ($state: any) => {
  try {
    const response = await fetch(
      `${baseaddress}Posts/personalized?page=${page.value}`,
      {
        credentials: "include",
      }
    );
    const datas: Post[] = await response.json();

    if (datas.length) {
      posts.value = [...posts.value, ...datas];
      $state.loaded();
    } else {
      $state.complete();
    }
    page.value++; // 每次加載完，頁數加1
  } catch (error) {
    console.error("Error loading posts:", error);
    $state.error(); // 如果加載出錯，告訴組件加載出錯
  }
};
const reloadPosts = () => {
  console.log("reload起來");
  page.value = 1;
  posts.value = [];
  reloadKey.value++;
};
</script>
<style lang=""></style>
