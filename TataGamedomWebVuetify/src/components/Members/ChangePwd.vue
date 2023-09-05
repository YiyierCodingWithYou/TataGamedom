<template>
  <v-card class="mx-auto mt-16" style="box-shadow: 2px 2px 10px #a1dfe9; background-color: #01010f" max-width="600"
    title="更改密碼">
    <v-container>
      <v-text-field v-model="originalPassword" :append-inner-icon="originalPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary" :rules="originalPasswordRules" label="舊密碼" :type="originalPasswordVisible ? 'text' : 'password'"
        variant="underlined" @click:append-inner="originalPasswordVisible = !originalPasswordVisible"></v-text-field>

      <v-text-field v-model="createPassword" :append-inner-icon="createPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary" :rules="createPasswordRules" label="新密碼" :type="createPasswordVisible ? 'text' : 'password'"
        variant="underlined" @click:append-inner="createPasswordVisible = !createPasswordVisible"></v-text-field>

      <v-text-field v-model="confirmPassword" :append-inner-icon="confirmPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary" :rules="confirmPasswordRules" label="確認密碼" :type="confirmPasswordVisible ? 'text' : 'password'"
        variant="underlined" @click:append-inner="confirmPasswordVisible = !confirmPasswordVisible"></v-text-field>

      <v-btn color="yellow" @click="onSubmit" style="left: 200px">
        修改密碼
        <v-icon icon="mdi-chevron-right" end></v-icon>
      </v-btn>
      <v-btn color="black" style="left:350px" @click="fillFormData"></v-btn>
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
  //iconImg.value = imageUrl;
  console.log("123132", datas);
};

onMounted(() => {
  loadMember();
});

const fillFormData = () => {
  originalPassword.value = "w84w84j06eji6",
    createPassword.value = "w84w84j06eji6",
    confirmPassword.value = "w84w84j06eji6"
}

const originalPasswordRules = ref([
  (value) => {
    if (!value) return "請輸入舊密碼";
  },
]);

const createPasswordRules = ref([
  (value) => {
    if (!value) return "請輸入密碼";
    if (value.length < 8) return "請輸入8個字以上的大小寫英文和數字";
  },
]);

const confirmPasswordRules = ref([
  (value) => {
    if (!value) return "請輸入確認密碼";
    if (value !== createPassword.value) return "兩次密碼不相符";
  },
]);

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
  if (
    originalPassword.value &&
    createPassword.value &&
    confirmPassword.value
  ) {
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
        Swal.fire({
          icon: "success",
          title: `密碼修改成功
        請使用新密碼重新登入`,
          showConfirmButton: false,
          timer: 1500,
        });
        logout();
      })
      .catch((err) => {
        console.log(err);
        Swal.fire("密碼修改失敗");
        Swal.fire({
          icon: "error",
          title: "密碼修改失敗",
        });
      });
  } else {
    Swal.fire({
      icon: "error",
      title: "請填寫所有必填欄位",
    });
  }
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
    
<style></style>