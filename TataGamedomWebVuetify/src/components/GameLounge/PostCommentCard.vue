<template lang="">
  <div class="comment test" :class="comment.isAuthor ? 'blueOutline' : ''">
    <v-card
      v-if="comment"
      :key="comment.commentId"
      class="commentCard ms-5"
      variant="outlined"
      :data-comment-id="comment.commentId"
    >
      <v-card-item v-if="comment.activeFlag">
        <v-card-subtitle>
          <span
            class="memberInfo"
            @click="linkTo('account', comment.memberAccount)"
          >
            {{ comment.memberName }} ( {{ comment.memberAccount }} )
          </span>
        </v-card-subtitle>
      </v-card-item>
      <v-card-text> {{ comment.commentContent }} </v-card-text>
      <v-card-actions>
        <v-btn
          @click="vote('comment', comment.commentId, 'Up', comment.postId)"
          :class="comment.voted === 'Up' ? 'voted' : 'not-voted'"
          ><span class="material-symbols-rounded"> thumb_up </span>

          <span>{{ comment.voteUp }}</span>
        </v-btn>
        <v-btn
          @click="vote('comment', comment.commentId, 'Down', comment.postId)"
          :class="comment.voted === 'Down' ? 'voted' : 'not-voted'"
          ><span class="material-symbols-rounded"> thumb_down </span>
          <span>{{ comment.voteDown }}</span>
        </v-btn>

        <v-btn @click="showCommentsInput">
          <span class="material-symbols-rounded size-20"> chat_bubble </span>
        </v-btn>

        <v-btn
          v-if="comment.isAuthor || comment.isMod"
          @click="deleteContent('comment', comment.commentId, comment.postId)"
        >
          <span class="material-symbols-rounded size-20"> delete </span>
        </v-btn>
        <span class="ms-auto text-caption">{{
          relativeTime(comment.dateTime)
        }}</span>
      </v-card-actions>
      <v-text-field
        v-show="showCommentInputBool"
        clearable
        label="回應"
        v-model="message"
        append-inner-icon="mdi-message-processing"
        @click="showLoginAlert"
        @click:append-inner="newComment(comment.commentId, comment.postId)"
        @keyup.enter="newComment(comment.commentId, comment.postId)"
      ></v-text-field>
    </v-card>
    <div>
      <div class="ms-5 test">
        <PostCommentCard
          v-if="comment.comments"
          v-for="comment in comment.comments"
          :key="comment.commentId"
          :comment="comment"
          @reloadPost="$emit('reloadPost', $event)"
        ></PostCommentCard>
      </div>
    </div>
  </div>
</template>

<style scoped>
.test {
  border-left: 1px solid rgba(249, 238, 8, 0.2);
}

.comment {}

.blueOutline {
  border-color: #a1dfe9;
}

.material-symbols-rounded {
  font-variation-settings: "FILL" 1, "wght" 200, "GRAD" 0, "opsz" 24;
}

.commentCard {
  border-top: 1px none 1px none solid rgba(161, 223, 233);
  border-left: 1px solid rgba(249, 238, 8, 0.2);
  border-bottom: none;
  border-right: none;
  border-radius: 0%;
  position: relative;
  background-color: #01010f;
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
import { reactive, ref, watch, computed } from "vue";
import { formatDistanceToNow } from "date-fns";
import { zhTW } from "date-fns/locale";
import { useRouter } from "vue-router";
const router = useRouter();
import { useStore } from "vuex";
const store = useStore();
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

const baseAddress = "https://localhost:7081/api/";
const message = ref("");
const props = defineProps({
  comment: {
    type: Object,
  },
});

const comment = ref(props.comment);

watch(
  () => props.comment,
  (newValue, oldValue) => {
    comment.value = newValue;
  },
  { deep: true }
);

const emits = defineEmits(["reloadPost"]);

let showCommentInputBool = ref(false);
const showCommentsInput = () => {
  showCommentInputBool.value = !showCommentInputBool.value;
};
const relativeTime = (datetime: string) => {
  // 轉換字串為日期對象
  const date = new Date(datetime);
  // 使用 formatDistanceToNow 來獲取相對時間
  return formatDistanceToNow(date, { addSuffix: true, locale: zhTW });
};

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
    emits("reloadPost", postId);
  } catch {
    alert(":<");
  }
};

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
        emits("reloadPost", postId);
      } catch {
        alert(":<");
      }
    }
  });
};

const newComment = async (commentId: number, postId: number) => {
  if (!isLoggedIn.value) {
    showLoginAlert()
    return
  }
  if (message.value.trim() != "") {
    try {
      const response = await fetch(`${baseAddress}PostComments/CommentReply`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify({
          commentId: commentId,
          content: message.value,
        }),
      });
      await store.dispatch("sendNotification", {
        account: props.comment?.memberAccount,
        loginMember: store.state.account,
        message: "回覆了您的留言",
        postId: postId,
      });
      let result = await response.json();
      emits("reloadPost", postId);
      message.value = "";
    } catch {
      alert(":<");
    }
  }
};

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
</script>
