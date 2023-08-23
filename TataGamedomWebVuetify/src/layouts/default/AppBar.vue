<template>
  <v-app-bar flat>
    <v-app-bar-title>
      <v-icon icon="mdi-circle-slice-4" />
      TataGamedom
    </v-app-bar-title>
    <a href="/GameLounge" class="me-3">👀</a>
    
    <a href="/News" class="me-3">偷看一下</a>
    <v-spacer></v-spacer>
    <a href="/Cart" class="me-3" ><v-icon>mdi-cart-outline</v-icon></a>
    <div v-if="$store.state.isLoggedIn">
      <!-- <a color="primary" @click="toggleMemberProfile">HI {{ name }}</a> -->
      <a color="primary" @mouseover="showMemberProfile = true">
        HI {{ name }}
      </a>
      <v-btn color="primary" @click="logout">登出</v-btn>
    </div>
    
    <v-btn v-else color="primary" @click="login">登入</v-btn>
  </v-app-bar>
  <MemberProfile class="MemberProfile" v-if="showMemberProfile" @close="closeMemberProfile"
    @mouseleave="showMemberProfile = false" />
</template>

<script>
import axios from "axios";
import MemberProfile from "@/components/Members/MemberProfile.vue";

export default {
  components: {
    MemberProfile,
  },
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
      //isRouterAlive: true,
      account: "",
      returnTo: null,
      forceRerenderKey: 0,
      showMemberProfile: false,
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
      //this.$store.commit("SET_LOGIN", false); // 將登入狀態重置為未登入
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
    toggleMemberProfile() {
      this.showMemberProfile = !this.showMemberProfile;
    },
    closeMemberProfile() {
      this.showMemberProfile = false;
    },
  },
  beforeMount() {
    this.checkLogin();
  },
};
</script>

<style>
.MemberProfile {
  position: fixed;
  z-index: 5;
  right: 0;
  margin-top: 64px;
}
</style>