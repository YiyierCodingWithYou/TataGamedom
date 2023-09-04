<template>
  <div class="bg d-flex justify-center align-center">
    <v-card
      class="mx-auto pa-10 pb-5 mt"
      elevation="8"
      max-width="800"
      rounded="lg"
      style="background-color: #01010f; color: white"
    >
      <div class="digi25px">ACCOUNT</div>
      <!-- <div class="text-subtitle-1 text-medium-emphasis text-white">Account</div> -->

      <v-text-field
        style="width: 500px"
        v-model="account"
        density="compact"
        placeholder="Enter your account"
        prepend-inner-icon="mdi-account-outline"
        variant="outlined"
      ></v-text-field>
      <div class="digi25px">PASSWORD</div>
      <!-- <div class="text-subtitle-1 mt-3 text-medium-emphasis d-flex align-center justify-space-between">
      </div> -->

      <v-text-field
        v-model="password"
        :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'"
        density="compact"
        placeholder="Enter your Password"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="visible = !visible"
      ></v-text-field>

      <div style="color: red">
        {{ errorMsg }}
      </div>

      <v-btn
        block
        class="digi my-5"
        size="large"
        variant="tonal"
        @click="onSubmit"
      >
        LOGIN
      </v-btn>

      <v-card-text class="text-center">
        <a
          class="digi2 text-decoration-none cursor-pointer"
          @click="goToRegister"
        >
          Sign up<v-icon icon="mdi-chevron-right"></v-icon>
        </a>
        <a
          class="digi2 text-decoration-none cursor-pointer"
          style="margin-left: 90px"
          @click="ForgetPwd"
        >
          ForgetPassword?</a
        >
      </v-card-text>

      <GoogleLogin
        :callback="callback"
        prompt
        style="margin-left: 30%"
      ></GoogleLogin>
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
                "https://localhost:7081/api/Carts", 
                {
                  productId: item.productId,
                  qty: item.qty,
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
              localStorage.removeItem("localCart"); 
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
.bg {
  background-image: url("https://www.nasa.gov/sites/default/files/styles/full_width_feature/public/thumbnails/image/pia21590_orig.jpg");
  background-size: cover;
  background-position: center;
  height: calc(100vh - 63px);
  width: 100vw;
}
.cursor-pointer {
  cursor: pointer;
}

.digi {
  font-size: 50px;
  font-family: "Digi-font";
  color: #f9ee08;
  background-color: transparent;
}

.digi25px {
  display: inline-block;
  font-size: 25px;
  font-weight: 50;
  font-family: "Digi-font";
  letter-spacing: 2px;
  color: white;
}

.digi2 {
  display: inline-block;
  font-size: 20px;
  font-weight: 50;
  font-family: "Digi-font";
  letter-spacing: 2px;
  color: #a1dfe9;
  margin: 10px 0px;
}
</style> 