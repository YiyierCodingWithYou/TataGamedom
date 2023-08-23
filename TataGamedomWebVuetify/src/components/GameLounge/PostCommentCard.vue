<template lang="">
  <v-card
    v-if="comment"
    :key="comment.commentId"
    class="comment ms-5"
    variant="outlined"
    :data-comment-id="comment.commentId"
  >
    <v-card-item v-if="comment.activeFlag">
      <v-card-subtitle>{{ comment.memberAccount }}</v-card-subtitle>
    </v-card-item>
    <v-card-text> {{ comment.commentContent }} </v-card-text>
    <v-card-actions>
      <v-btn
        @click="vote('comment', comment.commentId, 'Up', comment.postId)"
        :color="comment.voted === 'Up' ? 'red' : 'blue-grey-lighten-4'"
        >❤️<span>{{ comment.voteUp }}</span>
      </v-btn>
      <v-btn
        @click="vote('comment', comment.commentId, 'Down', comment.postId)"
        :color="comment.voted === 'Down' ? 'black' : 'blue-grey-lighten-4'"
        >💀<span>{{ comment.voteDown }}</span>
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
      @click:append-inner="newComment(comment.commentId, comment.postId)"
      @keyup.enter="newComment(comment.commentId, comment.postId)"
    ></v-text-field>
  </v-card>
  <div class="ms-5">
    <PostCommentCard
      v-if="comment.comments"
      v-for="comment in comment.comments"
      :key="comment.commentId"
      :comment="comment"
      @reloadPost="$emit('reloadPost', $event)"
    ></PostCommentCard>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, watch, defineEmits, defineProps } from "vue";
import { formatDistanceToNow } from "date-fns";
import { zhTW } from "date-fns/locale";

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
  try {
    const response = await fetch(
      `${baseAddress}${type === "post" ? "Posts" : "PostComments"}/${deleteId}`,
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
};

const newComment = async (commentId: number, postId: number) => {
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
      let result = await response.json();
      emits("reloadPost", postId);
      message.value = "";
    } catch {
      alert(":<");
    }
  }
};
</script>
<style lang=""></style>
