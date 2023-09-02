<template>
  <!-- <div style="justify-content: center;align-items: center;display: flex;position: relative;">
    <img src="https://localhost:7081/Files/Icons/bay.png" style="width: 800px;height: 800px;" alt="">
  </div> -->
  <!-- <div style="width: 2000px;">
    <img src="https://localhost:7081/Files/Icons/black.jpg" style="height: 1000px;width: 2000px;" alt="">
  </div> -->
  <div style="position: absolute; top:130px;left: 35%;">
    <v-card class="mx-auto pa-10 pb-5 mt" elevation="8" max-width="800" rounded="lg"
      style="background-color: #01010f; color: white">
      <div class="digi40px">ACCOUNT</div>
      <!-- <div class="text-subtitle-1 text-medium-emphasis text-white">Account</div> -->

      <v-text-field style="width: 500px;" v-model="account" density="compact" placeholder="Enter your account"
        prepend-inner-icon="mdi-account-outline" variant="outlined"></v-text-field>
      <div class="digi40px">PASSWORD
      </div>
      <!-- <div class="text-subtitle-1 mt-3 text-medium-emphasis d-flex align-center justify-space-between">
      </div> -->

      <v-text-field v-model="password" :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'" density="compact" placeholder="Enter your Password"
        prepend-inner-icon="mdi-lock-outline" variant="outlined" @click:append-inner="visible = !visible"></v-text-field>

      <div style="color: red">
        {{ errorMsg }}
      </div>

      <v-btn block class="digi my-8" size="large" variant="tonal" @click="onSubmit">
        LOGIN
      </v-btn>

      <v-card-text class="text-center">
        <a class="digi2 text-blue text-decoration-none cursor-pointer" @click="goToRegister">
          Sign up<v-icon icon="mdi-chevron-right"></v-icon>
        </a>
        <a class="digi2  text-decoration-none text-blue cursor-pointer" style="margin-left: 90px;" @click="ForgetPwd">
          ForgetPassword?</a>
      </v-card-text>
      <GoogleLogin :callback="callback" prompt style="margin-left: 30%;"></GoogleLogin>
    </v-card>
  </div>
</template>

<script>
import axios from "axios";
//import ForgetPwd from "./ForgetPwd.vue";
import GoogleLogin from "../Members/GoogleLogin.vue";
import { useRouter } from "vue-router";
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
            iconImg: res.data.iconImg,
          });
          this.$emit("loginOk");

          const localCart = JSON.parse(
            localStorage.getItem("localCart") || "[]"
          );
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
              localStorage.removeItem("localCart"); // Clear localCart after transferring to server
            })
            .catch((error) => {
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
      this.$router.push("/Members/Register");
    },
    ForgetPwd() {
      this.$router.push("/Members/ForgetPwd");
    },
  },
};
</script>

<style scoped>
.cursor-pointer {
  cursor: pointer;
}

.digi {
  font-size: 50PX;
  font-family: "Digi-font";
  color: #f9ee08;
  background-color: transparent;

}

.digi40px {
  display: inline-block;
  font-size: 25PX;
  font-weight: 50;
  font-family: "Digi-font";
  letter-spacing: 2px;
  color: white
}

.digi2 {
  display: inline-block;
  font-size: 20PX;
  font-weight: 50;
  font-family: "Digi-font";
  letter-spacing: 2px;
  color: #f9ee08;
  margin: 10px 0px;
}
</style> 
