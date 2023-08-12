<template>
  <v-app-bar flat>
    <v-app-bar-title>
      <v-icon icon="mdi-circle-slice-4" />
      TataGamedom
    </v-app-bar-title>

    <v-spacer></v-spacer>
    <div v-if="$store.state.isLoggedIn">
      <a color="primary">HI {{ name }}</a>
      <v-btn color="primary" @click="logout">登出</v-btn>
    </div>
    <v-btn v-else color="primary" @click="login">登入</v-btn>
  </v-app-bar>
</template>

<script>
import axios from "axios";

export default {
  computed: {
    IsLogined() {
      return this.$store.state.isLoggedIn;
    },
    name() {
      return this.$store.state.name;
    },
  },
  data() {
    return {
      // isRouterAlive: true,
      account: "",
      returnTo: null,
      forceRerenderKey: 0,
    };
  },
  methods: {
    login() {
      this.returnTo = this.$route.fullPath;
      this.$router.push("/Members/login");
    },
    logout() {
      axios.delete("https://localhost:7081/api/members/Logout", {
        withCredentials: true,
      });
      this.$router.go(0);
    },
    checkLogin() {
      axios
        .get("https://localhost:7081/api/Common/IsLoggedIn", {
          withCredentials: true,
        })
        .then((res) => {
          console.log(res.data);
          this.$store.commit("SET_LOGIN", res.data);
        });
    },
  },
  beforeMount() {
    this.checkLogin();
  },
};
</script>
