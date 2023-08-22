<template>
  <div>
    <v-btn
      class="cartBtn ma-2"
      color="orange-darken-2"
      icon="mdi-cart-outline"
      @click="openDrawer"
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
      <v-btn icon @click.stop="closeDrawer" class="closeBtn">
        <v-icon>mdi-close</v-icon>
      </v-btn>

      <!-- 抽屉内容 -->
    </v-navigation-drawer>
  </div>
</template>
  
  <script setup>
import { ref } from "vue";

const drawer = ref(false); // 初始状态为关闭
const rail = ref(true);
const drawerMiniVariant = ref(false);

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
.cartBtn {
  z-index: 100;
}
</style>