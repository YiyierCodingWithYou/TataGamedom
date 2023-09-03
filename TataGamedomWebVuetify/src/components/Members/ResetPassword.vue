<template>
  <v-sheet width="600" class="mx-auto" style="margin-top: 30px;">
    <v-form fast-fail @submit.prevent="submitForm">
      <v-card class="mx-auto mt-16" style="box-shadow: 2px 2px 10px #a1dfe9; background-color: #01010f" max-width="600"
        title="重設密碼">
        <v-container>
          <v-text-field style="" v-model="createPassword" label="重設密碼" type="password"
            :rules="createPasswordRules"></v-text-field>

          <v-text-field v-model="confirmPassword" label="確認密碼" type="password"
            :rules="confirmPasswordRules"></v-text-field>

          <v-btn type="submit" block class="mt-2 bg-yellow">重設密碼</v-btn>
        </v-container>
      </v-card>
    </v-form>
  </v-sheet>
</template>
    
<script >
import axios from "axios";
import Swal from "sweetalert2";
export default {
  data() {
    return {
      createPassword: "",
      confirmPassword: "",
      createPasswordRules: [
        function (value) {
          if (!value) return "請輸入密碼";
          if (value.length < 8) return "請輸入8個字以上的大小寫英文和數字";
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
      axios
        .post(
          `https://localhost:7081/api/Members/ResetPassword`,
          {
            memberId: this.$route.query.memberId,
            confirmCode: this.$route.query.confirmCode,
            createPassword: this.createPassword,
            confirmPassword: this.confirmPassword,
          },
          { withCredentials: true }
        )
        .then(() => {
          // 顯示提醒訊息
          Swal.fire({
            icon: "success",
            title: "已將密碼重設，請重新登入",
            showConfirmButton: false,
            timer: 1500,
          });
          this.$router.push({
            name: "Login",
          });
        })
        .catch((err) => {
          console.error("重設密碼失敗", err);
          Swal.fire({
            icon: "error",
            title: "重設密碼失敗",
          });
        });
    },
  },
};
</script>

<style></style>