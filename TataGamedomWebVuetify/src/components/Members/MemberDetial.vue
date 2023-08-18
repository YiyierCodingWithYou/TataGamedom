<template>
  <h2>是我啦會員資料</h2>
  <v-form v-model="valid">
    <v-container>
      <v-row>
        <v-col cols="12" md="6">
          <v-text-field
            v-model="name"
            :rules="nameRules"
            label="姓名"
            required
          ></v-text-field>
        </v-col>
        <!-- 
        <v-col cols="12" md="4">
          <v-text-field
            v-model="account"
            :counter="10"
            label="帳號"
            required
          ></v-text-field>
        </v-col> -->

        <v-col cols="12" md="6">
          <v-text-field
            v-model="email"
            label="E-mail"
            required
            readonly
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
          <v-text-field
            v-model="birthday"
            label="生日"
            required
            readonly
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="6">
          <v-text-field
            v-model="phone"
            :rules="phoneRules"
            :counter="10"
            label="手機"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="12">
          <v-file-input
            label="上傳頭像"
            variant="filled"
            prepend-icon="mdi-camera"
          ></v-file-input>
        </v-col>

        <img style="height: 300px; width: 300px" :src="img + iconImg" alt="" />
        <!-- <v-col cols="12" md="8">
          <v-text-field
            v-model="iconImg"
            :rules="emailRules"
            label="大頭貼"
            required
          ></v-text-field>
        </v-col> -->
      </v-row>
    </v-container>
    <v-btn color="success" @click="onClick" style="left: auto">
      確認修改
    </v-btn>
  </v-form>

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
  <v-date-picker></v-date-picker>
</template>
    
<script setup >
import axios from "axios";
import { ref, onMounted, watch } from "vue";
import { useRouter } from "vue-router";
import store from "@/store";
import { zhTW } from "date-fns/locale";
import { format } from "date-fns";

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
let img = "https://localhost:7081/Files/Icons/";

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
  console.log("123132", datas);
};

onMounted(() => {
  loadMember();
});

const onClick = async () => {
  axios
    .put(
      "https://localhost:7081/api/Members",
      {
        name: name.value,
        phone: phone.value,
        iconImg: iconImg.value,
        account: account.value,
        email: email.value,
      },
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res);
      alert("資料修改成功");
      store.commit("SET_UPDATENAME", name.value);
      //loadMember();
      //router.go(0);
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
  axios
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
  // (value) => {
  //   if (/.+@.+\..+/.test(value)) return true;
  //   return "E-mail must be valid.";
  // },
];
</script>
    
<style>
</style>