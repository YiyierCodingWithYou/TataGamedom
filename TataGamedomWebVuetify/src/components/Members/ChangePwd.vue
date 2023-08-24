<template>
  <v-card class="mx-auto mt-16" color="white" max-width="600" title="更改密碼">
    <v-container>
      <v-text-field
        v-model="originalPassword"
        :append-inner-icon="originalPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="舊密碼"
        :type="originalPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="originalPasswordVisible = !originalPasswordVisible"
      ></v-text-field>

      <v-text-field
        v-model="createPassword"
        :append-inner-icon="createPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="新密碼"
        :type="createPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="createPasswordVisible = !createPasswordVisible"
      ></v-text-field>

      <v-text-field
        v-model="confirmPassword"
        :append-inner-icon="confirmPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="確認密碼"
        :type="confirmPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="confirmPasswordVisible = !confirmPasswordVisible"
      ></v-text-field>
      <p v-if="createPassword !== confirmPassword" class="password-mismatch">
        新密碼需與確認密碼相符
      </p>

      <v-btn color="success" @click="onSubmit" style="left: 220px">
        修改密碼
        <v-icon icon="mdi-chevron-right" end></v-icon>
      </v-btn>
    </v-container>
  </v-card>
</template>
    
<script setup>
import axios from "axios";
import { ref, onMounted, watch } from "vue";
import { useRouter } from "vue-router";
import store from "@/store";
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";
import { QuillEditor } from "@vueup/vue-quill";
import "@vueup/vue-quill/dist/vue-quill.snow.css";
import ImageUploader from "quill-image-uploader";
//import { VDatePicker } from "vuetify/labs/VDatePicker";

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
  axios
    .put(
      `https://localhost:7081/api/Members?iconImgFileName=${iconImg.value}`,
      {
        name: name.value,
        phone: phone.value,
        iconImg: iconImg.value,
        account: account.value,
        email: email.value,
        //birthday: birthday.value,
      },
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res);
      alert("資料修改成功");
      store.commit("SET_UPDATEIMG", iconImg.value);
    })
    .catch((err) => {
      console.log(err);
      alert("資料修改失敗");
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

//改密碼
const onSubmit = async () => {
  await axios
    .post(
      "https://localhost:7081/api/Members/ChangePassword",
      {
        originalPassword: originalPassword.value,
        createPassword: createPassword.value,
        confirmPassword: confirmPassword.value,
      },
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res);
      alert("密碼修改成功，請使用新密碼重新登入");
      logout();
    })
    .catch((err) => {
      console.log(err);
      alert("密碼修改失敗");
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
</script>
    
<style>
</style>