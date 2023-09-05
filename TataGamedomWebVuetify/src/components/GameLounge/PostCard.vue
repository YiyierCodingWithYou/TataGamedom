<template lang="">
  <v-card
    variant="outlined"
    class="post mb-3"
    :data-id="post.postId"
    v-if="post.activeFlag"
    :class="[post.isAuthor ? 'blueOutline' : '', fullSize ? 'fullSize' : '']"
  >
    <v-card-item>
      <v-card-title  @click="linkTo('post', post.boardId, post.postId)" class="titleText">{{ post.title }}</v-card-title>
      <v-card-subtitle>
        <span
          class="memberInfo"
          @click="linkTo('account', post.memberAccount, 0)"
        >
          {{ post.memberName }} ( {{ post.memberAccount }} )
        </span>
        <span
          class="boardInfo ms-auto"
          @click="linkTo('board', post.boardId, 0)"
        >
          @ {{ post.boardName }}</span
        >
      </v-card-subtitle>
    </v-card-item>
    <div class="gradient-overlay" v-if="!fullSize && !showCommentsBool"></div>
    <v-card-text
      class="post-text"
      v-html="post.postContent"
      @click="toggleFullSize()"
    >
    </v-card-text>
    <v-card-actions>
      <v-btn
        @click="vote('post', post.postId, 'Up', post.postId)"
        :class="post.voted === 'Up' ? 'voted' : 'not-voted'"
        ><span class="material-symbols-rounded"> thumb_up </span
        ><span>{{ post.voteUp }}</span>
      </v-btn>

      <v-btn
        @click="vote('post', post.postId, 'Down', post.postId)"
        :class="post.voted === 'Down' ? 'voted' : 'not-voted'"
        ><span class="material-symbols-rounded"> thumb_down </span
        ><span>{{ post.voteDown }}</span>
      </v-btn>

      <v-btn @click="showCommentsInput">
        <span class="material-symbols-rounded size-20"> chat_bubble </span>
      </v-btn>

      <v-btn
        @click="
          {
            showComments();
            showCommentsInput();
          }
        "
        :disabled="post.commentCount === 0"
      >
        <span class="material-symbols-rounded size-20"> more_horiz </span>
        ({{ post.commentCount }})
      </v-btn>

      <editPostBtn
        v-if="post.isAuthor === true"
        :boardName="post.boardName"
        :postId="post.postId"
        :editor="post.postContent"
        :title="post.title"
        @editComplete="reloadPost(post.postId)"
      ></editPostBtn>

      <v-btn
        v-show="post.isAuthor || post.isMod"
        @click="deleteContent('post', post.postId, post.postId)"
      >
        <span class="material-symbols-rounded size-20"> delete </span>
      </v-btn>
      <v-btn class="w-5" @click="say('許願給新手的建議(●’◡’●)❤️')"></v-btn>

      <span
        class="ms-auto text-caption cursor-pointer"
        @click="linkTo('post', post.boardId, post.postId)"
        >{{ relativeTime(post.lastEditDatetime) }}</span
      >
      <span class="text-caption" v-show="post.isEdited">修改</span>
    </v-card-actions>
    <v-text-field
      v-show="showCommentInputBool"
      clearable
      label="回應"
      v-model="message"
      append-inner-icon="mdi-message-processing"
      @click="showLoginAlert"
      @click:append-inner="newComment(post.postId)"
      @keyup.enter="newComment(post.postId)"
    ></v-text-field>
    <div v-if="post.comments && post.comments.length > 0 && showCommentsBool">
      <PostCommentCard
        v-for="comment in post.comments"
        :key="comment.commentId"
        :comment="comment"
        @reloadPost="reloadPost(post.postId)"
      ></PostCommentCard>
    </div>
  </v-card>
</template>
<style>
.w-5 {
  width: 50px !important;
}
.material-symbols-rounded {
  font-variation-settings: "FILL" 1, "wght" 200, "GRAD" 0, "opsz" 24;
}

.post {
  background-color: transparent;
  border: rgba(255, 255, 255, 0.5) 2px solid;
  border-right: none;
  border-left: none;
  position: relative;
  overflow: hidden;
}

.post>.post-text {
  overflow: hidden;
  max-height: 40vh;
  cursor: pointer;
}

.fullSize>.post-text {
  max-height: 100%;
}

.post>.gradient-overlay {
  content: "";
  background: linear-gradient(to bottom,
      rgba(0, 0, 0, 0),
      rgba(0, 0, 0, 0.7),
      rgba(0, 0, 0, 1));
  position: absolute;
  top: calc(40vh);
  left: 0;
  right: 0;
  height: 90px;
  z-index: 100;
}

.blueOutline {
  border-color: #a1dfe9;
}

.voted {
  color: #f9ee08;
}

.voted:hover {
  transform: scale(1.1);
  color: #a1dfe9;
}

.not-voted:hover {
  opacity: 1;
  transform: scale(1.1);
  color: #f9ee08;
}

.v-card-text {
  font-size: 1.1rem;
}
.post-text img {
  max-width: 100% !important;
  height: auto;
}

.v-card-subtitle {
  opacity: 1;
}

.memberInfo:hover {
  color: #f9ee08 !important;
  cursor: pointer;
}

.boardInfo:hover {
  color: #a1dfe9 !important;
  cursor: pointer;
}

.cursor-pointer {
  cursor: pointer;
}

.cursor-pointer:hover {
  color: #f9ee08 !important;
}

.titleText:hover {
  color: #f9ee08 !important;
  cursor: pointer;

}
</style>

<script setup lang="ts">
import { ref, reactive, computed, watchEffect, onMounted } from "vue";
import { formatDistanceToNow } from "date-fns";
import { zhTW } from "date-fns/locale";
import editPostBtn from "./EditPostBtn.vue";
import PostCommentCard from "./PostCommentCard.vue";
import { useRoute } from "vue-router";
import { useRouter } from "vue-router";
import { useStore } from "vuex";
import Swal from "sweetalert2";

interface Comment {
  commentContent: string;
  dateTime: string;
  memberAccount: string;
  memberName: string;
  voteUp: number;
  voteDown: number;
  isEdited: boolean;
  isAuthor: boolean;
  isMod: boolean;
  voted: string;
  postId: number;
  comments: Comment[];
  activeFlag: boolean;
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
  isMod: boolean;
  voted: string;
  activeFlag: boolean;
  comments: Comment[];
}

const baseAddress = "https://localhost:7081/api/";
const message = ref("");
const props = defineProps(["post"]);
const post = ref<Post>(props.post);
const comments = ref<Comment[]>([]);
const hasComments = computed(() => comments.value.length > 0);
const router = useRouter();
const route = useRoute();
const store = useStore();
const isLoggedIn = computed(() => store.state.isLoggedIn);
const showLoginAlert = () => {
  if (!isLoggedIn.value) {

    Swal.fire({
      title: "請先登入會員以使用功能",
      icon: "warning",
      color: "white",
      confirmButtonColor: "orange",
      background: "#1e1e1e",
      confirmButtonText: "🎮趕緊加入獺獺玩國🦦",
    });
  }
};


const linkTo = (boardOrAccount, value, postId) => {
  if (boardOrAccount === "post") {
    router.push({
      name: "GameLoungePOST",
      params: { boardId: value, postId: postId },
    });
  }
  if (boardOrAccount === "board") {
    router.push({
      name: "GameLoungeBoard",
      params: { boardId: value },
    });
  }
  if (boardOrAccount === "account") {
    router.push({
      name: "GameLoungeAccount",
      params: { account: value },
    });
  }
};

watchEffect(() => {
  comments.value = post.value.comments || [];
});

let showCommentsBool = ref(false);
let showCommentInputBool = ref(false);
let fullSize = ref(false);
const routePostId = computed(() => route.params.postId);

const showComments = () => {
  showCommentsBool.value = !showCommentsBool.value;
  fullSize.value = showCommentsBool.value;
};
const showCommentsInput = () => {
  showCommentInputBool.value = !showCommentInputBool.value;
};
const toggleFullSize = () => {
  fullSize.value = !fullSize.value;
  console.log(fullSize.value);
};

const relativeTime = (datetime: string) => {
  // 轉換字串為日期對象
  const date = new Date(datetime);
  // 使用 formatDistanceToNow 來獲取相對時間
  return formatDistanceToNow(date, { addSuffix: true, locale: zhTW });
};

const vote = async (
  type: string,
  voteCommentId: number,
  upOrDown: string,
  postId: number
) => {
  if (!isLoggedIn.value) {
    showLoginAlert()
    return
  }

  try {
    const response = await fetch(
      `${baseAddress}${type === "post" ? "Posts" : "PostComments"
      }/${voteCommentId}/Vote/${upOrDown}`,
      {
        method: "PUT",
        credentials: "include",
      }
    );
    let result = await response.json();
    await reloadPost(postId);
  } catch {
    alert(":<");
  }
};

const emits = defineEmits(["deletePost"]);

const deleteContent = async (
  type: string,
  deleteId: number,
  postId: number
) => {
  Swal.fire({
    title: "確認刪除此貼文？",
    text: "刪除後無法復原",
    icon: "warning",
    showCancelButton: true,
    color: "white",
    confirmButtonColor: " red",
    cancelButtonColor: "gray",
    background: "#1e1e1e",
    cancelButtonText: "取消",
    confirmButtonText: "刪除",
  }).then(async (result) => {
    if (result.isConfirmed) {
      try {
        const response = await fetch(
          `${baseAddress}${type === "post" ? "Posts" : "PostComments"
          }/${deleteId}`,
          {
            method: "DELETE",
            credentials: "include",
          }
        );
        let result = await response.json();
        await reloadPost(postId);
        if (type === "post") {
          emits("deletePost");
        }
      } catch {
        alert(":<");
      }
    }
  });
};

const reloadPost = async (id: number): Promise<void> => {
  try {
    const response = await fetch(`${baseAddress}Posts/${id}`, {
      credentials: "include",
    });
    const data: Post = await response.json();
    post.value = data;
    console.log("reload!");
  } catch (error) {
    console.error("Error loading posts:", error);
  }
};

const newComment = async (postId: number) => {
  if (!isLoggedIn.value) {
    showLoginAlert()
    return
  }
  if (message.value.trim() != "") {
    try {
      const response = await fetch(`${baseAddress}PostComments`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify({
          postId: postId,
          content: message.value,
        }),
      });
      await store.dispatch("sendNotification", {
        account: post.value.memberAccount,
        loginMember: store.state.account,
        message: "回覆了您的貼文",
        postId: postId,
      });
      let result = await response.json();
      await reloadPost(postId);
      message.value = "";
    } catch {
      alert(":<");
    }
  }
};

const say = (text: string) => {
  message.value = text;
};

onMounted(() => {
  if (routePostId.value) {
    showComments();
  }
});
</script>
