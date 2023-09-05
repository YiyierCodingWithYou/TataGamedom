<template>
  <v-card>
    <v-img cover max-height="250" :src="iconUrl"></v-img>
    <v-card-item>
      <v-card-title>{{ memberData?.name }}</v-card-title>
      <v-card-subtitle>
        <v-chip v-if="memberData?.isFollowingYou && memberData?.isFollowing" class="ma-2 me1" color="#f9ee08" label>
          互相追隨
        </v-chip>
        <v-chip v-if="memberData?.isFollowingYou && !memberData?.isFollowing" class="ma-2 me1" color="#f9ee08" label>
          正在追隨你
        </v-chip>
      </v-card-subtitle>
    </v-card-item>
    <v-card-text>
      <div class="d-flex justify-center align-items-center my-4" v-if="!memberData?.isSelf">
        <v-btn rounded="lg" size="large" variant="outlined"
          :class="!memberData?.isFollowing ? 'followBtn' : 'unFollowBtn'" @click="followAction">
        </v-btn>
      </div>
      <div class="d-flex justify-center">
        <div class="mx-5 d-flex flex-column align-center justify-center">
          <FollowList :data="followerList" :key="dataKey">
            <template #title> 追隨者 </template>
            <template #clickBtn>
              <v-btn variant="text">
                {{ memberData?.followerCounting }}
              </v-btn>
            </template>
          </FollowList>
          <p>追隨者</p>
        </div>
        <div class="mx-5 d-flex flex-column align-center justify-center">
          <FollowList :data="followingList" v-if="dataKey > 0">
            <template #title> 追隨中 </template>
            <template #clickBtn>
              <v-btn variant="text">
                {{ memberData?.followingCounting }}
              </v-btn>
            </template>
          </FollowList>
          <p>追隨中</p>
        </div>
      </div>
      <v-divider class="mx-4 my-4"></v-divider>
      <v-card-title>About Me</v-card-title>
      <v-card-text v-html="memberData?.aboutMe"></v-card-text>
      <v-btn class="editMe" v-if="memberData?.isSelf" block rounded="xl" variant="outlined"
        @click="() => $router.push('/Members')">修改</v-btn>
    </v-card-text>
  </v-card>
</template>

<style scoped>
.editMe {
  color: #a1dfe9;
  border-color: #a1dfe9;
  margin-bottom: 20px;
  font-size: 1rem;
}

.editMe:hover {
  color: black;
  border-color: #f9ee08;
  background-color: #a1dfe9;
}

.v-card {
  background-color: transparent !important;
  box-shadow: 0px 0px 10px 2px #a1dfe9 !important;
}

.followBtn {
  color: #f9ee08;
}

.followBtn::before {
  content: "立即追蹤";
  position: relative;
}

.unFollowBtn {
  color: black;
  background-color: #a1dfe9;
}

.unFollowBtn:hover {
  background-color: pink;
}

.unFollowBtn:hover::before {
  content: "取消追蹤";
}

.unFollowBtn::before {
  content: "正在追蹤";
  position: relative;
}
</style>
<script setup lang="ts">
import FollowList from "@/components/GameLounge/RightBoardList/FollowList.vue";
import { ref, reactive, onMounted, computed, watch } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { useStore } from "vuex";
import Swal from "sweetalert2";

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

const store = useStore();
const memberData = ref<MemberData>();
const iconUrl = ref("");
const props = defineProps({
  memberAccount: {
    type: String,
    required: true,
  },
});
const followingList = ref([{}]);
const followerList = ref([{}]);
const dataKey = ref(0);
const StoreAcountAboutReloadKey = computed(
  () => store.state.GameLoungeStore.accountAboutReloadKey
);
const isLoggedIn = computed(() => store.state.isLoggedIn);
const showLoginAlert = () => {
  if (!isLoggedIn.value) {

    Swal.fire({
      title: "請先登入會員以使用功能",
      icon: "warning",
      color: "white",
      confirmButtonColor: "orange",
      background: "#1e1e1e",
      confirmButtonText: "🎮趕緊加入獺獺玩國🦦",
    });
  }
};

const getMemberData = async () => {
  const res = await axios
    .get(`https://localhost:7081/api/MembersAbout/${props.memberAccount}`, {
      withCredentials: true,
    })
    .then((res) => {
      memberData.value = res.data;
      iconUrl.value =
        res.data.iconURL ?? "https://pbs.twimg.com/media/F32EcZxbYAI5Oml.jpg";
      followingList.value = res.data.followings.map((m) => {
        return {
          title: m.name,
          subtitle: m.account,
          value: m.account,
          prependAvatar: m.iconURL,
        };
      });
      followerList.value = res.data.followers.map((m) => {
        return {
          title: m.name,
          subtitle: m.account,
          value: m.account,
          prependAvatar: m.iconURL,
        };
      });
      dataKey.value = dataKey.value + 1;
      console.log(dataKey.value);

      console.log(followerList.value);
      console.log(followingList.value);
    })
    .catch((err) => {
      console.log(err);
    });
};

const followAction = async () => {
  if (!isLoggedIn.value) {
    showLoginAlert()
    return
  }
  const res = await axios
    .post(
      `https://localhost:7081/api/MembersAbout/Follow?memberAccount=${props.memberAccount}`,
      {},
      {
        withCredentials: true,
      }
    )
    .then(async (res) => {
      if (!memberData.value.isFollowing) {
        await store.dispatch("sendNotification", {
          account: props.memberAccount,
          loginMember: store.state.account,
          message: "追蹤了你",
          postId: 0,
        });
      }
      dataKey.value = dataKey.value + 1;
      getMemberData();
    })
    .catch((err) => {
      console.log(err);
    });
};

onMounted(() => {
  getMemberData();
});

watch(StoreAcountAboutReloadKey, () => {
  getMemberData();
});
</script>
