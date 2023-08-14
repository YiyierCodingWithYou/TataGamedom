<template>
  <div class="text-center">
    <v-icon v-bind="props" size="x-large">
      {{ "mdi-package-variant-closed-remove" }}
    </v-icon>

    <v-dialog v-model="dialog" activator="parent" width="auto">
      <v-card>
        <v-card-text>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
          eiusmod tempor incididunt ut labore et dolore magna aliqua.
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" block @click="dialog = false"
            >Close Dialog</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>


<script>
export default {
  data() {
    return {
      dialog: false,
    };
  },
  props: {
    orderId: {
      type: [String, Number],
      required: true,
    },
  },
};
</script>
