<template>
  <v-form ref="myForm">
    <v-card class="mx-auto mt-10" color="black" max-width="344" title="使用者註冊" style="border: 2px solid #a1dfe9">
      <v-container>
        <v-text-field v-model="account" color="primary" label="帳號" :rules="rules.account"
          variant="underlined"></v-text-field>

        <v-text-field v-model="password" :append-inner-icon="passwordVisible ? 'mdi-eye-off' : 'mdi-eye'" color="primary"
          label="密碼" :type="passwordVisible ? 'text' : 'password'" :rules="passwordRules" variant="underlined"
          @click:append-inner="passwordVisible = !passwordVisible"></v-text-field>

        <v-text-field v-model="checkPassword" :append-inner-icon="checkPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
          color="primary" label="確認密碼" :type="checkPasswordVisible ? 'text' : 'password'" :rules="checkPasswordRules"
          variant="underlined" @click:append-inner="checkPasswordVisible = !checkPasswordVisible"></v-text-field>

        <v-text-field v-model="name" :rules="rules.name" color="primary" label="姓名" variant="underlined"></v-text-field>

        <v-text-field v-model="birthday" :rules="rules.birthday" color="primary" label="生日" type="date"
          variant="underlined"></v-text-field>

        <v-text-field v-model="email" :rules="emailRules" color="primary" label="Email"
          variant="underlined"></v-text-field>

        <v-text-field v-model="phone" :rules="phoneRules" color="primary" label="手機" variant="underlined"></v-text-field>

        <v-checkbox v-model="terms" :rules="rules.terms" color="secondary" label="我同意網站條款和條件"></v-checkbox>
      </v-container>

      <v-divider></v-divider>

      <v-card-actions>
        <v-spacer></v-spacer>

        <v-btn class="bg-yellow" color="black" @click="validateAndSubmit">
          完成註冊
          <v-icon icon="mdi-chevron-right" end></v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-form>
</template>
    
<script>
import axios from "axios";
import Swal from "sweetalert2";

export default {
  data: () => ({
    account: "",
    password: "",
    checkPassword: "",
    name: "",
    birthday: "",
    email: "",
    phone: "",
    coverImg: "",
    terms: false,
    passwordVisible: false,
    checkPasswordVisible: false,
    passwordRules: [
      (value) => {
        if (!value) return "請輸入密碼";
        if (value.length < 8) return "請輸入8個字以上的大小寫英文和數字";
      },
    ],
    checkPasswordRules: [
      (value) => {
        if (!value) return "請輸入確認密碼";
        //if (value !== this.password) return "兩次密碼不相符";
      },
    ],
    emailRules: [
      (value) => {
        if (!value) return "請輸入信箱";
        if (/[\u4e00-\u9fa5]/.test(value)) return "信箱格式不正確";
        if (value.includes("@") && /.+@.+\..+/.test(value)) return true;
        return "信箱格式不正確";
      },
    ],
    phoneRules: [
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
    ],
    rules: {
      account: [(v) => !!v || "帳號不可空白"],
      name: [(v) => !!v || "姓名不可空白"],
      birthday: [(v) => !!v || "生日不可空白"],
      terms: [(v) => !!v || "請勾選同意"],
    },
  }),
  methods: {
    validateAndSubmit() {
      this.$refs.myForm.validate().then((valid) => {
        if (valid) {
          this.onSubmit();
        } else {
          Swal.fire({
            icon: "error",
            title: "請正確填寫會員資料...",
          });
        }
      });
    },
    onSubmit() {
      if (
        !this.account ||
        !this.password ||
        !this.checkPassword ||
        !this.name ||
        !this.birthday ||
        !this.email ||
        !this.phone
      ) {
        Swal.fire({
          icon: "error",
          title: "請正確填寫會員資料...",
        });
        return;
      }
      axios
        .post(
          "https://localhost:7081/api/Members/Register",
          {
            account: this.account,
            password: this.password,
            checkPassword: this.checkPassword,
            name: this.name,
            birthday: this.birthday,
            email: this.email,
            phone: this.phone,
            coverImg: this.coverImg,
          },
          {
            withCredentials: true,
          }
        )
        .then((res) => {
          this.$router.push({
            name: "Login",
          });
          Swal.fire({
            icon: "success",
            title: "註冊成功",
            text: "請到信箱收取確認信!"
          });

        })
        .catch((err) => {
          console.log(err);
          //  Swal.fire("註冊失敗", err.response.data);
          Swal.fire({
            icon: "error",
            title: "註冊失敗...",
            text: `${err.response.data}`
          });
        });
    },
    callback(response) {
      this.data = response;
    },
  },
};
</script>
    
<style></style>