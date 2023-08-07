<template>
  <v-col cols="12" sm="8">
    <v-sheet min-height="70vh" rounded="lg">
      <v-container>
        <v-text-field
          label="page"
          variant="outlined"
          v-model="page"
          @change="loadPosts"
        ></v-text-field>
        <NewPostBtn></NewPostBtn>
        <v-col v-for="post in posts" :key="post.postId">
          <PostCard :post="post"></PostCard>
        </v-col>
        <InfiniteLoading @infinite="loadPosts">
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
      </v-container>
    </v-sheet>
  </v-col>
</template>
<script setup lang="ts">
import { onMounted, ref, DefineComponent } from "vue";
import NewPostBtn from "./NewPostBtn.vue";
import PostCard from "./PostCard.vue";
import InfiniteLoading from "v3-infinite-loading";
import "v3-infinite-loading/lib/style.css"; //required if you're not going to override default slots

interface Comment {
  comment: string;
  userName: string;
  userAccount: string;
  time: string;
}

interface Post {
  postId: string;
  title: string;
  content: string;
  userName: string;
  userAccount: string;
  time: string;
  like: number;
  unlike: number;
  commentNumber: number;
  commentList: Comment[];
}

const page = ref<number>(1);
const baseaddress = "https://localhost:7081/api/";
const posts = ref<Post[]>([]);
const loadPosts = async ($state: any) => {
  try {
    const response = await fetch(`${baseaddress}Posts?page=${page.value}`);
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

// onMounted(() => {
//   loadPosts();
// });
</script>
<style scoped></style>
