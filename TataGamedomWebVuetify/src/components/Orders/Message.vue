<template>
  <div class="bg-white mt-3">
    <span v-if="!isSenderAccountMine">{{ name }}</span>
    <div class="flex" :class="isSenderAccountMine ? 'flex-row-reverse' : ''">
      <v-avatar class="mt-1" :image="photoUrl" size="40" color=""></v-avatar>
      <slot />
    </div>
  </div>
</template>
  
<script scoped>
export default {
  props: {
    name: { type: String, default: "" },
    photoUrl: { type: String, default: "" },
    isSenderAccountMine: { type: Boolean, default: false },
  },
};
</script>

<style>
.flex {
  display: flex;
}

.flex-row-reverse {
  flex-direction: row-reverse;
}

.bg-white {
  background: cornsilk;
}
</style>