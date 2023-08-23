<template>
  <div>
    <v-card class="mx-auto pa-12 pb-8 mt-16" elevation="8" max-width="448" rounded="lg"
      style="background-color: black; color: white">
      <div class="text-subtitle-1 text-medium-emphasis text-white">帳號</div>

      <v-text-field v-model="account" density="compact" placeholder="請輸入帳號" prepend-inner-icon="mdi-account-outline"
        variant="outlined"></v-text-field>

      <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
        密碼

        <a class="text-caption text-decoration-none text-blue" href="#" rel="noopener noreferrer" @click="ForgetPwd">
          忘記密碼?</a>
      </div>

      <v-text-field v-model="password" :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'" density="compact" placeholder="請輸入密碼" prepend-inner-icon="mdi-lock-outline"
        variant="outlined" @click:append-inner="visible = !visible"></v-text-field>

      <div style="color: red">
        {{ errorMsg }}
      </div>

      <v-btn block class="mb-8 mt-5" color="blue" size="large" variant="tonal" @click="onSubmit">
        登入
      </v-btn>

      <v-card-text class="text-center">
        <a class="text-blue text-decoration-none" href="#" rel="noopener noreferrer" @click="goToRegister">
          立即註冊 <v-icon icon="mdi-chevron-right"></v-icon>
        </a>
      </v-card-text>
      <GoogleLogin :callback="callback" prompt></GoogleLogin>
    </v-card>
  </div>
</template>

<script>
import axios from "axios";
//import ForgetPwd from "./ForgetPwd.vue";
import GoogleLogin from "../Members/GoogleLogin.vue";
export default {
  components: {
    GoogleLogin,
  },
  data: () => ({
    visible: false,
    account: "", // Add this line
    password: "", // Add this line
    errorMsg: "",
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
            isLoggedIn: true,
            name: res.data.name,
            account: this.account,
            age: res.data.age,
          });
          this.$emit("loginOk");

          const localCart = JSON.parse(localStorage.getItem('localCart') || '[]');
          const promises = [];
          for (let item of localCart) {
            promises.push(
              axios.post(
                "https://localhost:7081/api/Carts", // Assuming this is your API endpoint to add items to the cart
                {
                  productId: item.productId,
                  qty: item.qty,
                  // Add any other necessary properties
                },
                {
                  withCredentials: true,
                }
              )
            );
          }
          Promise.all(promises)
            .then(() => {
              console.log("All cart items successfully saved to the database");
              localStorage.removeItem('localCart'); // Clear localCart after transferring to server
            })
            .catch(error => {
              console.error("Error saving cart items to the database:", error);
            });

          this.$router.go(-1);

          localStorage.setItem("returnToRoute", this.$route.fullPath);
        })
        .catch((err) => {
          console.log(err);
          console.log("登入失敗");
          this.errorMsg = err.response.data;
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

<style></style>
