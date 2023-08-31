<template>
  <div class="message">
    <span v-if="!isSenderAccountMine">{{ name }}</span>
    <div class="flex" :class="isSenderAccountMine ? 'flex-row-reverse' : ''">
      <Avatar class="mt-1" :src="photoUrl" />
      <div class="text w-3/4" :class="isSenderAccountMine ? 'bg-green-800' : 'bg-gray-700'">
        <slot />
      </div>
    </div>
  </div>
</template>
  
<script scoped>
import Avatar from "./Avatar.vue";
export default {
  components: { Avatar },
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
</style>