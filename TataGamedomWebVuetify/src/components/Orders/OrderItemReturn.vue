<template>
  <v-sheet width="300" class="mx-auto">
    <form @submit.prevent="submit">
      <v-text-field v-model="GameName" disabled :label="GameName"></v-text-field>

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
      GameName: this.$route.params.gameChiName,
      orderItemId: this.$route.params.id,
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