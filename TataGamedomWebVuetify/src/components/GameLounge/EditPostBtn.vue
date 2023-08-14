<template>
  <v-dialog v-if="isLoggedIn" v-model="dialog" persistent width="auto">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props">
        <span class="material-symbols-rounded size-20"> edit_square </span>
      </v-btn>
    </template>
    <v-form @submit.prevent="editPost">
      <v-card>
        <v-card-title class="text-h6 font-weight-bold">
          編輯貼文<span class="font-weight-thin text-body-2">
            @ {{ boardName }}</span
          >
        </v-card-title>
        <v-card-text>
          <v-text-field
            label="標題"
            hide-details="auto"
            v-model="title"
          ></v-text-field>
          <QuillEditor
            :modules="modules"
            :toolbar="toolbarOptions"
            class="quill-editor"
            contentType="html"
            v-model:content="editor"
          />
          <span class="text-body-2 text-red ms-5" v-if="editor.length > 1500"
            >*長度過長</span
          >
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="orange-darken-1" @click="initPost"> 取消 </v-btn>
          <v-btn
            color="green-darken-1"
            type="submit"
            :disabled="editor.length < 0 || editor.length > 1500"
          >
            編輯
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-form>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, defineProps, defineEmits } from "vue";
import { QuillEditor } from "@vueup/vue-quill";
import "@vueup/vue-quill/dist/vue-quill.snow.css";
import ImageUploader from "quill-image-uploader";
import axios from "axios";
import DOMPurify from "dompurify";
import store from "@/store";

const emit = defineEmits(["editComplete"]);
const isLoggedIn = ref(store.state.isLoggedIn);

const props = defineProps({
  postId: {
    type: Number,
    required: true,
  },
  boardName: {
    type: String,
    required: true,
  },
  editor: {
    type: String,
    required: true,
  },
  title: {
    type: String,
    required: false,
  },
});

const title = ref(props.title);
const editor = ref(props.editor);
const dialog = ref(false);

const initPost = () => {
  editor.value = props.editor;
  title.value = props.title;
  dialog.value = false;
};

const toolbarOptions = [
  [{ header: [1, 2, 3, 4, 5, false] }], // custom button values
  ["bold", "italic", "underline", "strike"], // toggled buttons
  ["blockquote", "code-block"],
  [{ list: "ordered" }, { list: "bullet" }],
  [{ color: [] }, { background: [] }], // dropdown with defaults from theme
  ["link", "image"],
  ["clean"], // remove formatting button
];

const modules = {
  name: "imageUploader",
  module: ImageUploader,
  toolbar: toolbarOptions,
  options: {
    upload: (file) => {
      return new Promise((resolve, reject) => {
        const formData = new FormData();
        formData.append("file", file);
        axios
          .post(
            "https://localhost:7081/api/Common/uploadImage/Post",
            formData,
            {
              headers: {
                "Content-Type": "multipart/form-data",
              },
              withCredentials: true,
            }
          )
          .then((res) => {
            console.log(res);
            let imgurLink = res.data;
            console.log(imgurLink);
            resolve(imgurLink);
          })
          .catch((err) => {
            reject("Upload failed");
            console.error("Error:", err);
          });
      });
    },
  },
};

const editPost = () => {
  let content = DOMPurify.sanitize(editor.value);
  if (content == "") {
    alert("請輸入內容");
    return;
  }
  let post = {
    id: props.postId,
    title: title.value,
    content: content,
  };
  axios
    .put(`https://localhost:7081/api/Posts/${props.postId}`, post, {
      headers: {
        "Content-Type": "application/json",
      },
      withCredentials: true,
    })
    .then((res) => {
      console.log(post);
      console.log(res);
      alert("編輯成功");
      title.value = "";
      editor.value = "";
      dialog.value = false;
      emit("editComplete");
    })
    .catch((err) => {
      console.error("Error:", err);
    });
};
</script>

<style scoped>
>>> .quill-editor {
  resize: vertical;
  overflow: auto;
  min-height: 200px;
  max-height: 300px;
}
</style>
