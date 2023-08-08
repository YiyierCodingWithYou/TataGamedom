<template>
  <h2>登入頁面</h2>
  <v-sheet class="pa-12" rounded>
    <v-card color="black" class="mx-auto px-6 py-8" max-width="344">
      <v-form v-model="form" @submit.prevent="onSubmit">
        <v-text-field
          v-model="account"
          :readonly="loading"
          :rules="[required]"
          class="mb-2"
          label="帳號"
          placeholder="請輸入帳號"
        ></v-text-field>

        <v-text-field
          v-model="password"
          :readonly="loading"
          :rules="[required]"
          :type="show2 ? 'text' : 'password'"
          label="密碼"
          placeholder="請輸入密碼"
        ></v-text-field>

        <br />

        <v-btn
          :disabled="!form"
          :loading="loading"
          block
          color="success"
          size="large"
          type="submit"
          variant="elevated"
        >
          登入
        </v-btn>
      </v-form>
    </v-card>
  </v-sheet>
</template>
    
<script>
import axios from "axios";

export default {
  data: () => ({
    form: false,
    email: null,
    password: null,
    loading: false,
  }),

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
          this.$router.push({
            name: "Home",
          });
        })
        .catch((err) => {
          console.log(err);
          console.log("登入失敗");
        });

      // if (!this.form) return

      // this.loading = true

      // setTimeout(() => (this.loading = false), 2000)
    },
    required(v) {
      return !!v || "此欄位為必填";
    },
  },
};
</script>
    
<style></style>