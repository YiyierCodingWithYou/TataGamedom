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
      <span class="ms-auto text-caption">{{ post.lastEditDatetime }}</span>
      <span class="text-caption" v-show="post.isEdited">已修改</span>
    </v-card-actions>
    <v-card-action>
      <v-text-field
        v-show="showCommentInputBool"
        clearable
        label="回應"
        v-model="message"
        append-inner-icon="mdi-message-processing"
        @click:append-inner="sendMessage"
      ></v-text-field>
    </v-card-action>
    <v-card
      v-for="(comment, index) in comments"
      :key="index"
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
        <v-btn :color="isVoted ? 'red' : 'grey'"
          >❤️<span>{{ comment.voteUp }}</span>
        </v-btn>
        <v-btn :color="isVoted ? 'black' : 'grey'"
          >💀<span>{{ comment.voteDown }}</span></v-btn
        >
        <span class="ms-auto text-caption">{{ comment.dateTime }}</span>
      </v-card-actions>
    </v-card>
  </v-card>
</template>
<script setup lang="ts">
import { ref, reactive, computed } from "vue";
const message = ref("");
const props = defineProps(["post"]);
const post = computed(() => props.post);
const comments = computed(() => post.value.comments || []);
const isVoted = ref(true);
let showCommentsBool = ref(false);
let showCommentInputBool = ref(false);
const sendMessage = () => {
  alert(message.value);
};
const showComments = () => {
  showCommentsBool.value = !showCommentsBool.value;
};
const showCommentsInput = () => {
  showCommentInputBool.value = !showCommentInputBool.value;
};

const vote = (type: string, upOrDown: string): void => {
  alert("voted!");
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
