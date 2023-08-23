<template>
  <div>
    <GoogleLogin :callback="callback" />
    <p>
      {{ data }}
    </p>
  </div>
</template>
    
<script setup >
import { ref } from "vue";
import axios from "axios";

const data = ref();

const callback = (response) => {
  const idToken = response.clientId;
  data.value = response;
  console.log(response);
  console.log(response.clientId);

  axios.post('https://localhost:7081/api/Members/GoogleLogin', idToken)
    .then((apiResponse) => {
      // 處理API的回應
      console.log(apiResponse);
    })
    .catch((error) => {
      // 處理錯誤
      console.error(error);
    });
};
</script>
    
<style>
p {
  margin-top: 12px;
  word-break: break-all;
}
</style>