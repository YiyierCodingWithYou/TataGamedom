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
const data = ref();

const callback = (response) => {
  data.value = response;
  console.log(response);
};
</script>
    
<style>
p {
  margin-top: 12px;
  word-break: break-all;
}
</style>