<template>
  <div>
    <v-card
      class="mx-auto pa-12 pb-8 mt-16"
      elevation="8"
      max-width="448"
      rounded="lg"
      style="background-color: black; color: white"
    >
      <div class="text-subtitle-1 text-medium-emphasis text-white">帳號</div>

      <v-text-field
        v-model="account"
        density="compact"
        placeholder="請輸入帳號"
        prepend-inner-icon="mdi-account-outline"
        variant="outlined"
      ></v-text-field>

      <div
        class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between"
      >
        密碼

        <a
          class="text-caption text-decoration-none text-blue"
          href="#"
          rel="noopener noreferrer"
          @click="ForgetPwd"
        >
          忘記密碼?</a
        >
      </div>

      <v-text-field
        v-model="password"
        :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'"
        density="compact"
        placeholder="請輸入密碼"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="visible = !visible"
      ></v-text-field>

      <v-btn
        block
        class="mb-8 mt-5"
        color="blue"
        size="large"
        variant="tonal"
        @click="onSubmit"
      >
        登入
      </v-btn>

      <v-card-text class="text-center">
        <a
          class="text-blue text-decoration-none"
          href="#"
          rel="noopener noreferrer"
          @click="goToRegister"
        >
          立即註冊 <v-icon icon="mdi-chevron-right"></v-icon>
        </a>
      </v-card-text>
    </v-card>
  </div>
</template>
    
<script>
import axios from "axios";
import ForgetPwd from "./ForgetPwd.vue";

export default {
  data: () => ({
    visible: false,
    account: "", // Add this line
    password: "", // Add this line
  }),
  emits: ["loginOk"],
  methods: {
    onSubmit() {
      axios
        .post(
          "https://localhost:7081/api/members/login",
          {
            account: this.account,
            password: this.password,
          },
          {
            withCredentials: true,
          }
        )
        .then((res) => {
          console.log(res);
          console.log("登入成功");
          // this.$store.commit("SET_LOGIN", true);
          this.$store.commit("SET_LOGIN", {
            isLogined: true,
            name: res.data,
            account: this.account,
          });
          this.$emit("loginOk");
          this.$router.go(-1);

          localStorage.setItem("returnToRoute", this.$route.fullPath);
        })
        .catch((err) => {
          console.log(err);
          console.log("登入失敗");
        });
    },
    goToRegister() {
      this.$router.push("/members/register");
    },
    ForgetPwd() {
      this.$router.push("/members/ForgetPwd");
    },
  },
};
</script>
    
<style>
</style>