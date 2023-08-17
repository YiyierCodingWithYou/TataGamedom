<template>
  <h2>重設密碼</h2>
  <v-sheet width="300" class="mx-auto">
    <v-form fast-fail @submit.prevent="submitForm">
      <v-text-field
        v-model="createPassword"
        label="重設密碼"
        :rules="createPasswordRules"
      ></v-text-field>

      <v-text-field
        v-model="confirmPassword"
        label="確認密碼"
        :rules="confirmPasswordRules"
      ></v-text-field>

      <v-btn type="submit" block class="mt-2">Submit</v-btn>
    </v-form>
  </v-sheet>
</template>
    
<script >
import axios from "axios";
export default {
  data() {
    return {
      createPassword: "",
      confirmPassword: "",
      createPasswordRules: [
        function (value) {
          if (!value) return "請輸入密碼";
        },
      ],
      confirmPasswordRules: [
        function (value) {
          if (!value) return "請輸入確認密碼";
          if (value !== this.createPassword) return "兩次密碼不相符";
        }.bind(this),
      ],
    };
  },
  methods: {
    submitForm() {
      // 執行提交後的操作，例如重設密碼信件的寄出

      axios.post(
        `https://localhost:7081/api/Members/ResetPassword`,
        {
          memberId: this.$route.query.memberId,
          confirmCode: this.$route.query.confirmCode,
          createPassword: this.createPassword,
          confirmPassword: this.confirmPassword,
        },
        { withCredentials: true }
      );
      // 顯示提醒訊息
      this.showAlert();
    },
    showAlert() {
      alert("已將密碼重設，請重新登入");
    },
  },
};
</script>

<style>
</style>