<template>
  <v-tabs fixed-tabs bg-color="dark">
    <v-tab @click="selectedTab = 'MemberDetial'" :active="selectedTab === 'MemberDetial'">
      修改資料
    </v-tab>
    <v-tab @click="selectedTab = 'ChangePwd'" :active="selectedTab === 'ChangePwd'">
      修改密碼
    </v-tab>
  </v-tabs>

  <MemberDetial v-if="selectedTab === 'MemberDetial'"></MemberDetial>
  <ChangePwd v-if="selectedTab === 'ChangePwd'"></ChangePwd>
</template>
    
<script setup>
import { ref, onMounted } from "vue";
import MemberDetial from "@/components/Members/MemberDetial.vue";
import ChangePwd from "@/components/Members/ChangePwd.vue";
const showChangePwd = ref(false);
const selectedTab = ref("MemberDetial");
onMounted(() => {
  const Pwd =
    "26256583618AA9595240F1D7BE6AE79A35AF7BF1DE258F04636875BA4E11C291";
  if (
    Pwd !== "26256583618AA9595240F1D7BE6AE79A35AF7BF1DE258F04636875BA4E11C291"
  ) {
    showChangePwd.value = true;
  }
});
</script>
    
<style>
.Detail {
  border: solid;
}
</style>