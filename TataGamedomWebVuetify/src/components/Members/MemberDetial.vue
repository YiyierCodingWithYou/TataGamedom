<template>
  <h2>是我啦會員資料</h2>
  <v-form v-model="valid">
    <v-container>
      <v-row>
        <v-col cols="12" md="4">
          <v-text-field
            v-model="name"
            :rules="nameRules"
            :counter="10"
            label="姓名"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="lastname"
            :rules="nameRules"
            :counter="10"
            label="Last name"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required
          ></v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required
          ></v-text-field>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
  <v-card class="mx-auto" color="white" max-width="600" title="更改密碼">
    <v-container>
      <v-text-field
        v-model="oringinalPassword"
        :append-inner-icon="
          oringinalPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'
        "
        color="primary"
        label="舊密碼"
        :type="oringinalPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="
          oringinalPasswordVisible = !oringinalPasswordVisible
        "
      ></v-text-field>

      <v-text-field
        v-model="createPassword"
        :append-inner-icon="createPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="新密碼"
        :type="createPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="createPasswordVisible = !createPasswordVisible"
      ></v-text-field>

      <v-text-field
        v-model="confirmPassword"
        :append-inner-icon="confirmPasswordVisible ? 'mdi-eye-off' : 'mdi-eye'"
        color="primary"
        label="確認密碼"
        :type="confirmPasswordVisible ? 'text' : 'password'"
        variant="underlined"
        @click:append-inner="confirmPasswordVisible = !confirmPasswordVisible"
      ></v-text-field>
      <p v-if="createPassword !== confirmPassword" class="password-mismatch">
        新密碼需與確認密碼相符
      </p>

      <v-btn color="success" @click="onSubmit">
        修改密碼
        <v-icon icon="mdi-chevron-right" end></v-icon>
      </v-btn>
    </v-container>
  </v-card>
</template>
    
<script setup >
import axios from "axios";
import { ref, onMounted, watch } from "vue";

const member = ref([]);
const valid = ref(false);
const name = ref("");
const lastname = ref("");
const email = ref("");
const oringinalPasswordVisible = ref(false);
const createPasswordVisible = ref(false);
const confirmPasswordVisible = ref(false);
const passwordsMatch = ref(true);

const loadMember = async () => {
  const response = await fetch("https://localhost:7081/api/Members", {
    credentials: "include",
  });
  const datas = await response.json();
  member.value = datas.member;
  console.log("123132", datas);
};

onMounted(() => {
  loadMember();
});

const nameRules = [
  (value) => {
    if (value) return true;
    return "姓名為必填";
  },
  (value) => {
    if (value?.length <= 10) return true;
    return "Name must be less than 10 characters.";
  },
];

const emailRules = [
  (value) => {
    if (value) return true;
    return "E-mail is required.";
  },
  (value) => {
    if (/.+@.+\..+/.test(value)) return true;
    return "E-mail must be valid.";
  },
];
</script>
    
<style>
.WH {
  height: 50px;
  width: 600px;
  margin-left: 30%;
}
.bgc {
  background-color: rgb(157, 82, 82);
}
</style>