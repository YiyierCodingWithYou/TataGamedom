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

const callback = async (response) => {
  data.value = response;
  console.log(response.credential);
  // const credential = response.credential;
  //const credential = JSON.stringify({ credential: response.credential });
  await axios.post('https://localhost:7081/api/Members/GoogleLogin', response.credential, {
    withCredentials: true,
    headers: {
      'Content-Type': 'application/json',
    },
  })
    .then((apiResponse) => {
      // 處理API的回應
      console.log("抓出來", apiResponse.data.user);
    })
    .catch((error) => {
      // 處理錯誤
      console.error(error);
    });
};

// const callback = (response) => {
//   data.value = response;
//   const credential = response.credential;
//   const credentialModel = { Credential: credential };
//   console.log(response);
//   console.log("我是credential", credential);
//   axios.post('https://localhost:7081/api/Members/GoogleLogin', credentialModel, {
//     withCredentials: true,
//     headers: {
//       'Content-Type': 'application/json',
//     },
//   })
//     .then((apiResponse) => {
//       // 處理API的回應
//       console.log(apiResponse);
//     })
//     .catch((error) => {
//       // 處理錯誤
//       console.error(error);
//     });
// };
</script>
    
<style>
p {
  margin-top: 12px;
  word-break: break-all;
}
</style>