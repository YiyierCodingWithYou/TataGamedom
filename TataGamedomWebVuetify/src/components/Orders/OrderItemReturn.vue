<template>
  Test
  <v-sheet width="300" class="mx-auto">
    <form @submit.prevent="submit">
      <v-text-field v-model="GameName" disabled label="遊戲"></v-text-field>

      <v-textarea clearable clear-icon="mdi-close-circle" label="退貨理由" v-model="Reason"></v-textarea>

      <v-btn class="me-4" type="submit">
        送出
      </v-btn>
    </form>
  </v-sheet>
</template>
<script>
export default {
  data() {
    return {
      GameName: '',
      orderItemId: null,
      Reason: '',
      invalidInput: false
    }
  },
  methods: {
    submitSurvey() {
      if (this.orderItemId === null) {
        this.invalidInput = true;
      }
      this.invalidInput = false;

      fetch('https://localhost:7081/api/OrderItemReturns', {
        method: 'post',
        headers: {
          'Content-Type': 'application/Json'
        },
        body: JSON.stringify({
          orderItemId: this.orderItemId,
          Reason: this.Reason
        })
      })
    }
  }
}

</script>

<style></style>