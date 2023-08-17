<template></template>
    
<script setup>
import { ref } from "vue";

const baseLoginPayUrl = "https://localhost:7081/api/LinePay/";

const requestPayment = async (paymentData) => {
  try {
    const response = await fetch(baseLoginPayUrl + "Create", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(paymentData),
    });

    if (response.ok) {
      const data = await response.json();
      window.location = data.info.paymentUrl.web;
    }
  } catch (error) {
    console.error("Error with requestPayment: ", error);
  }
};
</script>
    
<style>
</style>