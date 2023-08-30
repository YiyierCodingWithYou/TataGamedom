<template>
  <div class="message">
    <span v-if="!senderAccount">{{ name }}</span>
    <div class="flex" :class="senderAccount ? 'flex-row-reverse' : ''">
      <Avatar class="mt-1" :src="photoUrl" />
      <div
        class="text w-3/4"
        :class="senderAccount ? 'bg-green-800' : 'bg-gray-700'"
      >
        <slot />
      </div>
    </div>
  </div>
</template>
  
<script>
import Avatar from "./Avatar.vue";
export default {
  components: { Avatar },
  props: {
    name: { type: String, default: "" },
    photoUrl: { type: String, default: "" },
    senderAccount: { type: Boolean, default: false },
  },
};
</script>