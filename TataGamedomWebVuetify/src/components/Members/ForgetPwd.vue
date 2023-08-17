<template>
  <H2>偶忘記密碼ㄌ</H2>
  <v-sheet width="300" class="mx-auto">
    <v-form fast-fail @submit.prevent="submitForm">
      <v-text-field
        v-model="account"
        label="帳號"
        :rules="accountRules"
      ></v-text-field>

      <v-text-field
        v-model="email"
        label="email"
        :rules="emailRules"
      ></v-text-field>

      <v-btn type="submit" block class="mt-2">Submit</v-btn>
    </v-form>
  </v-sheet>
</template>
    
<script >
import axios from "axios";
export default {
  data: () => ({
    account: "",
    email: "",
    accountRules: [
      (value) => {
        if (!value) return "請輸入帳號";
        if (/[\u4e00-\u9fa5]/.test(value)) return "帳號不可包含中文字";
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
  }),
  methods: {
    submitForm() {
      // 執行提交後的操作，例如重設密碼信件的寄出
      axios.post(
        "https://localhost:7081/api/Members/ForgetPassword",
        {
          account: this.account,
          email: this.email,
        },
        { withCredentials: true }
      );
      // 顯示提醒訊息
      this.showAlert();
    },
    showAlert() {
      alert("已將重設密碼信件寄出");
    },
  },
};
</script>
    
<style>
</style>