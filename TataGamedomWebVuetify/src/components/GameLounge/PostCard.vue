<template lang="">
  <v-card variant="outlined" class="post mb-3" :data-id="post.postId">
    <v-card-item>
      <v-card-title>{{ post.title }}</v-card-title>
      <v-card-subtitle
        >{{ post.memberAccount }}
        <span class="ms-auto"> @{{ post.boardName }}</span></v-card-subtitle
      >
    </v-card-item>
    <v-card-text v-html="post.postContent"> </v-card-text>
    <v-card-actions>
      <v-btn
        @click="vote('post', post.postId, 'Up', post.postId)"
        :color="post.voted === 'Up' ? 'red' : 'blue-grey-lighten-4'"
        >❤️ <span>{{ post.voteUp }}</span>
      </v-btn>
      <v-btn
        @click="vote('post', post.postId, 'Down', post.postId)"
        :color="post.voted === 'Down' ? 'black' : 'blue-grey-lighten-4'"
        >💀<span>{{ post.voteDown }}</span></v-btn
      >
      <v-btn v-show="false">修改</v-btn>
      <v-btn v-show="false">刪除</v-btn>
      <v-btn @click="showComments">展開 ({{ post.commentCount }}) </v-btn>
      <v-btn @click="showCommentsInput">回應</v-btn>
      <span class="ms-auto text-caption">{{ post.lastEditDatetime }}</span>
      <span class="text-caption" v-show="post.isEdited">已修改</span>
    </v-card-actions>
    <v-text-field
      v-show="showCommentInputBool"
      clearable
      label="回應"
      v-model="message"
      append-inner-icon="mdi-message-processing"
      @click:append-inner="newComment(post.postId)"
    ></v-text-field>
    <v-card
      v-for="(comment, index) in comments"
      :key="comment.commentId"
      class="comment"
      v-show="showCommentsBool"
      variant="outlined"
      :data-comment-id="comment.commentId"
    >
      <v-card-item>
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
          >💀<span>{{ comment.voteDown }}</span></v-btn
        >
        <span class="ms-auto text-caption">{{ comment.dateTime }}</span>
      </v-card-actions>
    </v-card>
  </v-card>
</template>
<script setup lang="ts">
import { ref, reactive, computed, watchEffect } from "vue";

interface Comment {
  commentContent: string;
  dateTime: string;
  memberAccount: string;
  memberName: string;
  voteUp: number;
  voteDown: number;
  voted: string;
  postId: number;
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

const baseAddress = "https://localhost:7081/api/";
const message = ref("");
const props = defineProps(["post"]);
const post = ref<Post>(props.post);
const comments = ref<Comment[]>([]);

watchEffect(() => {
  comments.value =
    post.value.comments?.map((comment) => {
      return comment;
    }) || [];
});

const isVoted = ref<boolean>();
let showCommentsBool = ref(false);
let showCommentInputBool = ref(false);
const showComments = () => {
  showCommentsBool.value = !showCommentsBool.value;
};
const showCommentsInput = () => {
  showCommentInputBool.value = !showCommentInputBool.value;
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
      }
    );
    let result = await response.json();
    await reloadPost(postId);
  } catch {
    alert(":<");
  }
};
const reloadPost = async (id: number): Promise<void> => {
  try {
    const response = await fetch(`${baseAddress}Posts/${id}`);
    const data: Post = await response.json();
    post.value = data;
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
<style scoped>
.post {
  border-color: rgba(250, 112, 0, 0.1);
  box-shadow: 2px 2px 2px 2px rgba(250, 112, 0, 0.05);
}
.comment {
  border-color: rgba(64, 64, 64, 0.1);
  background-color: rgba(64, 64, 64, 0.03);
}
</style>
