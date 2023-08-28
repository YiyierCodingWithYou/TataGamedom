<template lang="">
  <v-card
    variant="outlined"
    class="post mb-3"
    :data-id="post.postId"
    v-if="post.activeFlag"
    :class="post.isAuthor ? 'yellowOutline' : ''"
  >
    <v-card-item>
      <v-card-title>{{ post.title }}</v-card-title>
      <v-card-subtitle>
        <span class="memberInfo" @click="linkTo('account', post.memberAccount)">
          {{ post.memberName }} ( {{ post.memberAccount }} )
        </span>
        <span class="boardInfo ms-auto" @click="linkTo('board', post.boardId)">
          @ {{ post.boardName }}</span
        >
      </v-card-subtitle>
    </v-card-item>
    <v-card-text class="post-text" v-html="post.postContent"> </v-card-text>
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

      <v-btn @click="showComments" :disabled="post.commentCount === 0">
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

      <span class="ms-auto text-caption">{{
        relativeTime(post.lastEditDatetime)
      }}</span>
      <span class="text-caption" v-show="post.isEdited">修改</span>
    </v-card-actions>
    <v-text-field
      v-show="showCommentInputBool"
      clearable
      label="回應"
      v-model="message"
      append-inner-icon="mdi-message-processing"
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
.material-symbols-rounded {
  font-variation-settings: "FILL" 1, "wght" 200, "GRAD" 0, "opsz" 24;
}

.post {
  box-shadow: 0px 1px 10px 1px #a1dfe9;
  background-color: transparent;
}
.yellowOutline {
  border: 1px solid #f9ee08;
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
.v-card-text img {
  max-width: 100%;
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
</style>

<script setup lang="ts">
import { ref, reactive, computed, watchEffect, onMounted } from "vue";
import { formatDistanceToNow } from "date-fns";
import { zhTW } from "date-fns/locale";
import editPostBtn from "./EditPostBtn.vue";
import PostCommentCard from "./PostCommentCard.vue";
import { useRouter } from "vue-router";

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

const linkTo = (boardOrAccount, value) => {
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
const showComments = () => {
  showCommentsBool.value = !showCommentsBool.value;
};
const showCommentsInput = () => {
  showCommentInputBool.value = !showCommentInputBool.value;
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
  try {
    const response = await fetch(
      `${baseAddress}${
        type === "post" ? "Posts" : "PostComments"
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
  try {
    const response = await fetch(
      `${baseAddress}${type === "post" ? "Posts" : "PostComments"}/${deleteId}`,
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
      let result = await response.json();
      await reloadPost(postId);
      message.value = "";
    } catch {
      alert(":<");
    }
  }
};
</script>
