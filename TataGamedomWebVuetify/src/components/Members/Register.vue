<template>
  <v-card class="mx-auto" color="black" max-width="344" title="使用者註冊">
    <v-container>
      <v-text-field
        v-model="account"
        color="primary"
        label="帳號"
        variant="underlined"
      ></v-text-field>
      <div style="color: red">{{ errorMsg }}</div>

      <v-text-field
        v-model="password"
        :append-inner-icon="passwordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="密碼"
        :type="passwordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="passwordVisible = !passwordVisible"
      ></v-text-field>

      <v-text-field
        v-model="checkPassword"
        :append-inner-icon="checkPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="確認密碼"
        :type="checkPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="checkPasswordVisible = !checkPasswordVisible"
      ></v-text-field>
      <p v-if="password !== checkPassword" class="password-mismatch">
        密碼需與確認密碼相符
      </p>

      <v-text-field
        v-model="name"
        color="primary"
        label="姓名"
        variant="underlined"
      ></v-text-field>

      <v-text-field
        v-model="birthday"
        color="primary"
        label="生日"
        type="date"
        variant="underlined"
      ></v-text-field>

      <v-text-field
        v-model="email"
        color="primary"
        label="Email"
        variant="underlined"
      ></v-text-field>

      <v-text-field
        v-model="phone"
        color="primary"
        label="手機"
        variant="underlined"
      ></v-text-field>

      <!-- <v-text-field
        v-model="coverImg"
        color="primary"
        label="大頭貼"
        variant="underlined"
      ></v-text-field> -->

      <v-checkbox
        v-model="terms"
        color="secondary"
        label="我同意網站條款和條件"
      ></v-checkbox>
    </v-container>

    <v-divider></v-divider>

    <v-card-actions>
      <v-spacer></v-spacer>

      <v-btn color="success" @click="onSubmit">
        完成註冊

        <v-icon icon="mdi-chevron-right" end></v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
    
<script>
import axios from "axios";

export default {
  data: () => ({
    account: "",
    password: "",
    checkPassword: "",
    passwordsMatch: true,
    name: "",
    birthday: "",
    email: "",
    phone: "",
    coverImg: "",
    errmsg: "",
    terms: false,
    // visible: false,
    passwordVisible: false,
    checkPasswordVisible: false,
  }),
  watch: {
    password: function () {
      this.passwordsMatch = this.password === this.checkPassword;
    },
    checkPassword: function () {
      this.passwordsMatch = this.password === this.checkPassword;
    },
  },
  methods: {
    onSubmit() {
      if (!this.email || !this.phone) {
        console.log("請填寫email和phone");
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
          console.log(res);
          console.log("註冊成功");
          alert("註冊成功，請到信箱收取確認信!");
        })
        .catch((err) => {
          console.log(err);
          console.log("註冊失敗");
        });
    },
    callback(response) {
      this.data = response;
    },
  },
};
</script>
    
<style>
.password-mismatch {
  color: red;
  font-size: 14px;
}
</style>