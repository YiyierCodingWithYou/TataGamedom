<template>
  <v-card class="mx-auto mt-16 " style="box-shadow: 2px 2px 10px #a1dfe9; background-color: #01010f" max-width="600"
    title="忘記密碼">
    <v-form ref="myForm" fast-fail @submit.prevent="submitForm">
      <v-container>
        <v-text-field v-model="account" label="帳號" :rules="accountRules"></v-text-field>

        <v-text-field v-model="email" class="mt-5" label="email" :rules="emailRules"></v-text-field>

        <v-btn type="submit" class="mt-2 bg-yellow" style="left:43%">確認</v-btn>
        <v-btn color="black" class="mt-2" @click="fillFormData" style="left:72%"></v-btn>
      </v-container>
    </v-form>

  </v-card>
</template>
    
<script >
import axios from "axios";
import Swal from "sweetalert2";
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
      // 檢查是否有填寫帳號和郵件地址
      if (this.account && this.email) {
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
        Swal.fire({
          icon: "success",
          title: "已將重設密碼信件寄出",
          showConfirmButton: false,
          timer: 1500,
        });
      } else {
        // 如果帳號或郵件地址為空，顯示錯誤訊息或執行其他適當的處理
        Swal.fire({
          icon: "error",
          title: "請正確填寫帳號和郵件地址...",
        });
      }
    },
    fillFormData() {
      this.account = "tata123456",
        this.email = "zzzz850304@gmail.com"
    },
  },
};
</script>
    
<style>
.TATA {
  border: 1px #f9ee08 solid;
}
</style>