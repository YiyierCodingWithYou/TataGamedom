<template>
  <div
    :class="['message-wrapper', isSenderAccountMine ? 'right' : 'left']"
    class=""
  >
    <span class="message-author">
      <!-- <span class="message-author"> -->
      <v-avatar size="75" class="avatar">
        <v-img :src="photoUrl" cover></v-img
      ></v-avatar>
      <p>{{ name }}</p>
    </span>
    <div class="message-content mt-4 mx-2">
      <div class="message-box">
        <slot class="text-black" />
      </div>
      <span class="message-time">{{ sendAt }}</span>
    </div>
  </div>
</template>

<script scoped>
export default {
  props: {
    name: { type: String, default: "" },
    recevierPhotoUrl: { type: String, default: "" },
    senderPhotoUrl: { type: String, default: "" },
    sendAt: { type: String, default: "" },
    isSenderAccountMine: { type: Boolean, default: false },
  },
  computed: {
    photoUrl() {
      return this.isSenderAccountMine
        ? this.senderPhotoUrl
        : this.recevierPhotoUrl;
    },
  },
};
</script>

<style scoped>
.message-wrapper {
  display: flex;
  margin-top: 12px;
}

.message-wrapper.right {
  flex-direction: row-reverse;
}

.message-author {
  display: flex;
  align-items: center;
  flex-direction: column;
}

.avatar {
  color: brown;
  margin-right: 8px;
}

.message-content {
  display: flex;
  flex-direction: column;
}

.message-box {
  background-color: cornsilk;
  color: black !important;
  padding: 12px;
  border-radius: 16px;
}

.message-time {
  font-size: 10px;
  align-self: flex-end;
  margin-top: 4px;
}
</style>
