<template>
  <v-form v-model="valid">
    <v-container>
      <v-row class="mt-3">
        <v-col cols="12" md="6">
          <v-text-field v-model="name" :rules="nameRules" label="姓名" required></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
          <v-text-field v-model="phone" :rules="phoneRules" :counter="10" label="手機" required></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
          <v-text-field v-model="email" label="E-mail" required readonly></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
          <v-text-field v-model="birthday" label="生日" readonly>
          </v-text-field>
        </v-col>

        <v-col cols="12" md="10" style="position: relative">
          <v-file-input label="上傳頭像" variant="filled" prepend-icon="mdi-camera" style="font-size: 50px; height: 350px"
            @change="uploadImage"></v-file-input>
          <!-- <img style="position: absolute; top:12px ; right:300px ; height: 200px; width: 200px; border-radius: 50%;"
            :src="img + iconImg" /> -->
        </v-col>
        <img style="
            position: absolute;
            top: 350px;
            right: 150px;
            height: 200px;
            width: 200px;
            border-radius: 50%;
          " :src="img + iconImg" />
        <v-col cols="12" md="11" style="position: absolute; margin-top: 450px">About Me
          <QuillEditor :modules="modules" :toolbar="toolbarOptions" class="quill-editor" contentType="html"
            v-model:content="editor" />
        </v-col>
        <v-btn color="yellow" @click="onClick" style="margin-left: 45%; top: 110px">
          確認修改
        </v-btn>
      </v-row>
    </v-container>
  </v-form>
</template>
    
<script setup >
import axios from "axios";
import { ref, onMounted, watch } from "vue";
import { useRouter } from "vue-router";
import store from "@/store";
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
import { QuillEditor } from "@vueup/vue-quill";
import "@vueup/vue-quill/dist/vue-quill.snow.css";
import ImageUploader from "quill-image-uploader";
import ChangePwd from "./ChangePwd.vue";
import Swal from "sweetalert2";

//const member = ref([]);
const valid = ref(false);
const name = ref("");
const account = ref("");
const email = ref("");
const birthday = ref("");
const phone = ref("");
const iconImg = ref("");
const originalPassword = ref("");
const createPassword = ref("");
const confirmPassword = ref("");
const originalPasswordVisible = ref(false);
const createPasswordVisible = ref(false);
const confirmPasswordVisible = ref(false);
const passwordsMatch = ref(true);
const router = useRouter();
const editor = ref("");
let img = "https://localhost:7081/Files/Uploads/Icons/";

watch([createPassword, confirmPassword], () => {
  passwordsMatch.value = createPassword === confirmPassword;
});

//載入會員資料
const loadMember = async () => {
  const response = await fetch("https://localhost:7081/api/Members", {
    credentials: "include",
  });
  const datas = await response.json();
  //member.value = datas;
  name.value = datas.name;
  account.value = datas.account;
  email.value = datas.email;
  birthday.value = relativeTime(datas.birthday);
  phone.value = datas.phone;
  iconImg.value = datas.iconImg;
  editor.value = datas.aboutMe;

  //iconImg.value = imageUrl;
  console.log("123132", datas);
};

onMounted(() => {
  loadMember();
});

//上傳圖片
async function uploadImage(event) {
  const file = event.target.files[0];
  if (!file) {
    return;
  }

  const folderName = "Icons";
  const formData = new FormData();
  formData.append("file", file);

  try {
    const response = await axios.post(
      `https://localhost:7081/api/Common/uploadImage/${folderName}`,
      formData,
      {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      }
    );

    //用來/分割上傳的連結(只取最後的XXXX.JPG)
    const parts = response.data.split("/");
    iconImg.value = parts[parts.length - 1];
    console.log("上傳成功", iconImg.value);
  } catch (error) {
    console.error("上傳失敗", error);
  }
}

//確認修改
const onClick = async () => {
  if (!validateForm()) {
    return;
  }
  axios
    .put(
      `https://localhost:7081/api/Members?iconImgFileName=${iconImg.value}`,
      {
        name: name.value,
        phone: phone.value,
        iconImg: iconImg.value,
        account: account.value,
        email: email.value,
        aboutMe: editor.value,
        //birthday: birthday.value,
      },
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res);
      Swal.fire({
        icon: "success",
        title: "資料修改成功",
        showConfirmButton: false,
        timer: 1500,
      });
      store.commit("SET_UPDATEIMG", iconImg.value);
    })
    .catch((err) => {
      console.log(err);
      Swal.fire({
        icon: "error",
        title: "資料修改失敗",
      });
    });
};

//登出
const logout = async () => {
  axios.delete("https://localhost:7081/api/members/Logout", {
    withCredentials: true,
  });
  store.commit("SET_LOGIN", false);
  router.push({
    name: "Login",
  });
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

//修改時間格式
const relativeTime = (datetime) => {
  const date = new Date(datetime);
  return format(date, "yyyy/MM/dd", { locale: zhTW });
};

const nameRules = [
  (value) => {
    if (value) return true;
    return "姓名為必填";
  },
];

const phoneRules = [
  (value) => {
    if (value && /^\d{10}$/.test(value)) {
      return true;
    }
    return "手機必須為10位數字";
  },
  (value) => {
    if (value) return true;
    return "手機為必填";
  },
];

const validateForm = () => {
  const nameValid = nameRules.every((rule) => rule(name.value) === true);
  const phoneValid = phoneRules.every((rule) => rule(phone.value) === true);

  if (!nameValid) {
    Swal.fire({
      icon: "error",
      title: "姓名必須符合驗證規則",
    });
    return false;
  }

  if (!phoneValid) {
    Swal.fire({
      icon: "error",
      title: "手機必須符合驗證規則",
    });

    return false;
  }

  return true;
};
</script>
    
<style>
.quill-editor {
  resize: vertical;
  overflow: auto;
  min-height: 200px;
  max-height: 200px;
}
</style>