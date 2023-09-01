<template>
  <div>
    <GoogleLogin :callback="callback" />
  </div>
</template>
    
<script setup >
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import store from "@/store";

const data = ref();
const router = useRouter();
const account = ref("");

const callback = async (response) => {
  data.value = response;
  console.log(response);
  console.log(response.credential);
  // const credential = response.credential;
  //const credential = JSON.stringify({ credential: response.credential });
  await axios
    .post(
      "https://localhost:7081/api/Members/GoogleLogin",
      response.credential,
      {
        withCredentials: true,
        headers: {
          "Content-Type": "application/json",
        },
      }
    )
    .then((apiResponse) => {
      // 處理API的回應
      console.log("抓出來", apiResponse.data);
      console.log("抓出來", apiResponse);
      console.log("acccc", account);
      store.commit("SET_LOGIN", {
        isLoggedIn: true,
        name: apiResponse.data.name,
        age: apiResponse.data.age,
        iconImg: apiResponse.data.iconImg,
      });
      // emit("loginOk");
      router.go(-1);

      localStorage.setItem("returnToRoute", route.fullPath);

      // router.go(-1);

      // localStorage.setItem("returnToRoute", this.$route.fullPath);
    })
    .catch((error) => {
      // 處理錯誤
      console.error(error);
    });
};
</script>
    
<style></style>