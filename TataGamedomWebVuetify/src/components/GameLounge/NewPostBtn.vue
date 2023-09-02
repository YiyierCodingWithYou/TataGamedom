<template>
  <v-dialog v-model="dialog" v-if="IsLoggedIn" persistent width="auto">
    <template v-slot:activator="{ props }">
      <v-btn variant="outlined" class="w-100 my-5 newBtn" v-bind="props">
        🖋️發表貼文
      </v-btn>
    </template>
    <v-form @submit.prevent="postNewPost">
      <v-card>
        <v-card-title class="text-h6 font-weight-bold">
          新增貼文
          <select-board
            @selected="handleSelection"
            class="d-inline-block w-50 d-inline-block"
          />
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
          <v-btn color="orange-darken-1" @click="dialog = false"> 取消 </v-btn>
          <v-btn
            color="green-darken-1"
            type="submit"
            :disabled="editor.length < 0 || editor.length > 1500"
          >
            發佈
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-form>
  </v-dialog>
</template>

<script setup lang="">
import { ref, defineProps, defineEmits, computed, onMounted } from "vue";
import { QuillEditor } from "@vueup/vue-quill";
import { useRoute } from "vue-router";
import "@vueup/vue-quill/dist/vue-quill.snow.css";
import ImageUploader from "quill-image-uploader";
import axios from "axios";
import DOMPurify from "dompurify";
import store from "@/store";
import selectBoard from "@/components/GameLounge/SelectBoard.vue";

const emit = defineEmits(["postComplete"]);
const title = ref("");
const editor = ref("");
const dialog = ref(false);
const IsLoggedIn = computed(() => store.state.isLoggedIn);
const boardId = ref(0);
const boardList = ref([]);
const route = useRoute();

const handleSelection = (selectedBoard) => {
  boardId.value = selectedBoard;
};

const toolbarOptions = [
  [{ header: [1, 2, 3, 4, 5, false] }], // custom button values
  ["bold", "italic", "underline", "strike"], // toggled buttons
  ["blockquote", "code-block"],
  [{ list: "ordered" }, { list: "bullet" }],
  [{ color: [] }, { background: [] }], // dropdown with defaults from theme
  ["image"],
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

const postNewPost = () => {
  let content = DOMPurify.sanitize(editor.value);
  if (content == "") {
    alert("請輸入內容");
    return;
  }
  let post = {
    boardId: boardId.value,
    title: title.value,
    content: content,
  };
  axios
    .post("https://localhost:7081/api/Posts", post, {
      withCredentials: true,
    })
    .then((res) => {
      alert("發文成功");
      title.value = "";
      editor.value = "";
      dialog.value = false;
      emit("postComplete");
    })
    .catch((err) => {
      console.error("Error:", err);
    });
};

if (route.params.boardId !== undefined) {
  boardId.value = +route.params.boardId;
}
</script>

<style scoped>
/* .plusBtn {
  background-color: black;
  box-shadow: 0px 0px 10px 2px #a1dfe9 !important;
  position: fixed;
  bottom: 20px;
  right: 25%;
  z-index: 999;
} */

.newBtn {
  border: #a1dfe9 1px solid;
  position: relative;
  letter-spacing: 12px;
  font-size: 0.9rem;
  font-weight: 600;
}

.newBtn:hover {
  background: #a1dfe9;
  color: black !important;
  box-shadow: 0px 0px 10px 2px #a1dfe9;
}

>>> .quill-editor {
  resize: vertical;
  overflow: auto;
  min-height: 200px;
  max-height: 300px;
}

>>> .quill-editor img {
  max-width: 50%;
}
</style>
