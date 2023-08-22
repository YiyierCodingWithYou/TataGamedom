<template>
  <div>
    <v-btn
      class="ma-2"
      color="orange-darken-2"
      icon="mdi-cart-outline"
      @click="openDrawer"
      ref="drawerRef"
    ></v-btn>
    <v-navigation-drawer
      v-model="drawer"
      :rail="rail"
      permanent
      location="right"
      :mini-variant="drawerMiniVariant"
      class="w-25"
      @click.stop
    >

      <!-- 抽屉内容 -->
    </v-navigation-drawer>
  </div>
</template>
  
  <script setup>
import { ref, onMounted, onUnmounted } from "vue";

const drawer = ref(false); // 初始状态为关闭
const drawerRef = ref(null);
const rail = ref(true);
const drawerMiniVariant = ref(false);

onMounted(() => {
  window.addEventListener("click", outsideClickListener);
});

onUnmounted(() => {
  window.removeEventListener("click", outsideClickListener);
});

const outsideClickListener = (event) => {
  // 檢查被點擊的元素是否是抽屜或其子元素
  if (!drawerRef.value?.$el.contains(event.target)) {
    closeDrawer();
  }
};

const openDrawer = () => {
  drawer.value = true;
  drawerMiniVariant.value = true;
};

const closeDrawer = () => {
  drawer.value = false;
  drawerMiniVariant.value = false;
};
</script>
  
  <style>
</style>