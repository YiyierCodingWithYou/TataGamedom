<template lang="">
  <v-card variant="outlined" class="test mb-3">
    <v-card-item data-id="post.postId">
      <v-card-title>{{ post.title }}</v-card-title>
      <v-card-subtitle
        >{{ post.memberAcount }} | {{ post.boardName }}</v-card-subtitle
      >
    </v-card-item>
    <v-card-text> {{ post.postContent }} </v-card-text>
    <v-card-actions>
      <v-btn :color="isVoted ? 'red' : 'grey'"
        >❤️ <span>{{ post.voteUp }}</span>
      </v-btn>
      <v-btn :color="isVoted ? 'black' : 'grey'"
        >💀<span>{{ post.voteDown }}</span></v-btn
      >
      <v-btn v-show="false">修改</v-btn>
      <v-btn v-show="false">刪除</v-btn>
      <v-btn @click="showComments">展開回應 ({{ post.commentCount }}) </v-btn>
      <v-btn @click="showCommentsInput">發表回應</v-btn>
      <span class="ms-auto text-caption" v-show="post.IsEdited">已修改</span>
      <span class="ms-auto text-caption">{{ post.lastEditDatetime }}</span>
    </v-card-actions>
    <v-card-action>
      <v-text-field
        v-show="showCommetInputBool"
        clearable
        label="回應"
        v-model="message"
        append-inner-icon="mdi-message-processing"
        @click:append-inner="sendMessage"
      ></v-text-field>
    </v-card-action>
    <v-card class="comment" v-show="showCommentsBool" subtitle="111">
      <v-card-text> 我是回應 </v-card-text>
      <v-card-actions>
        <v-btn :color="isVoted ? 'red' : 'grey'">❤️ <span>1</span> </v-btn>
        <v-btn :color="isVoted ? 'black' : 'grey'">💀<span>1</span></v-btn>
        <span class="ms-auto text-caption">2023-12-22</span>
      </v-card-actions>
    </v-card>
  </v-card>
</template>
<script setup>
import { ref, computed } from "vue";
const message = ref("");
// const props = defineProps(["post"]);
// const post = computed(() => props.post);
const post = ref({
  postId: 0,
  title: "aaa",
  postContent: "bbb",
  dateTime: "2023-08-07T07:09:22.815Z",
  boardId: 0,
  boardName: "ccccc",
  memberAccount: "account",
  memberName: "nameeeee",
  voteUp: 0,
  voteDown: 0,
  commentCount: 0,
  comments: [
    {
      commentId: 0,
      commentContent: "string",
      dateTime: "2023-08-07T07:09:22.815Z",
      memberAccount: "string",
      memberName: "string",
      voteUp: 0,
      voteDown: 0,
    },
  ],
  lastEditDatetime: "2023-08-07T07:09:22.815Z",
  isEdited: true,
});
let showCommentsBool = ref(false);
let showCommetInputBool = ref(false);
const sendMessage = () => {
  alert(message.value);
};
const showComments = () => {
  showCommentsBool.value = !showCommentsBool.value;
};
const showCommentsInput = () => {
  showCommetInputBool.value = !showCommetInputBool.value;
};
</script>
<style scoped>
.test {
  border-color: rgba(250, 112, 0, 0.1);
  box-shadow: 2px 2px 2px 2px rgba(250, 112, 0, 0.05);
}

.comment {
  background-color: #eceff1;
}
</style>
