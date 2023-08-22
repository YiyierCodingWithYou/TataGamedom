<template>
  <v-card class="w-100">
    <v-img cover max-height="250" :src="iconUrl"></v-img>
    <v-card-item>
      <v-card-title>{{ memberData?.name }}</v-card-title>
      <v-card-subtitle>
        <span
          class="me-1"
          v-if="memberData?.isFollowingYou && memberData?.isFollowing"
          >互相追隨</span
        >
        <span
          class="me-1"
          v-if="memberData?.isFollowingYou && !memberData?.isFollowing"
          >正在追隨你</span
        >
      </v-card-subtitle>
    </v-card-item>
    <v-card-text>
      <div
        class="d-flex justify-center align-items-center my-4"
        v-if="!memberData?.isSelf"
      >
        <v-btn v-if="!memberData?.isFollowing" @click="followAction">
          Follow
        </v-btn>
        <v-btn v-if="memberData?.isFollowing" @click="followAction">
          UnFollow
        </v-btn>
      </div>
      <div class="d-flex justify-center">
        <div class="mx-5 d-flex flex-column align-center justify-center">
          <p>{{ memberData?.followerCounting }}</p>
          <p>追隨者</p>
        </div>
        <div class="mx-5 d-flex flex-column align-center justify-center">
          <p>{{ memberData?.followingCounting }}</p>
          <p>追隨中</p>
        </div>
      </div>
      <v-divider class="mx-4 my-4"></v-divider>
      <v-card-title>About Me</v-card-title>
      <v-card-text v-html="memberData?.aboutMe"></v-card-text>
    </v-card-text>
  </v-card>
</template>
<script setup lang="ts">
import { ref, reactive, onMounted, defineProps } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

interface MemberData {
  id: number;
  name: string;
  aboutMe: string;
  iconUrl: string;
  isFollowing: boolean;
  isFollowingYou: boolean;
  isSelf: boolean;
  followerCounting: number;
  followingCounting: number;
}

const memberData = ref<MemberData>();
const iconUrl = ref("");
const props = defineProps({
  memberAccount: {
    type: String,
    required: true,
  },
});

const getMemberData = async () => {
  const res = await axios
    .get(`https://localhost:7081/api/MembersAbout/${props.memberAccount}`, {
      withCredentials: true,
    })
    .then((res) => {
      console.log(res.data);
      memberData.value = res.data;
      iconUrl.value =
        memberData.value?.iconUrl ??
        "https://pbs.twimg.com/media/F32EcZxbYAI5Oml.jpg";
    })
    .catch((err) => {
      console.log(err.data);
    });
};

const followAction = async () => {
  const res = await axios
    .post(
      `https://localhost:7081/api/MembersAbout/Follow?memberAccount=${props.memberAccount}`,
      {},
      {
        withCredentials: true,
      }
    )
    .then((res) => {
      console.log(res.data);
      getMemberData();
    })
    .catch((err) => {
      console.log(err);
    });
};

onMounted(() => {
  getMemberData();
});
</script>
<style lang=""></style>
