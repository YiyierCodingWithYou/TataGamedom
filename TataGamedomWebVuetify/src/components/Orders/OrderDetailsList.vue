<template>
  <div class="text-center">
    <v-icon @click="" v-bind="props" size="x-large">
      {{ "mdi-script-text-outline" }}
    </v-icon>

    <v-dialog v-model="dialog" activator="parent" width="auto">
      <v-card class="mx-auto" max-width="auto">
        <v-card-item class="bg-brown-lighten-5">
          <v-card-title>
            <span class="text-h5"></span>
          </v-card-title>

          <template v-slot:append>
            <v-defaults-provider
              :defaults="{
                VBtn: {
                  variant: 'text',
                  density: 'comfortable',
                },
              }"
            >
              <v-btn icon="mdi-pencil"></v-btn>
            </v-defaults-provider>
          </template>
        </v-card-item>

        <v-list>
          <v-list-item prepend-icon="mdi-phone" title="訂單編號"></v-list-item>
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-phone" title="成立日期"></v-list-item>
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-phone" title="完成日期"></v-list-item>
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-phone" title="寄送方式"></v-list-item>
          <v-divider inset></v-divider>
          <v-list-item prepend-icon="mdi-phone" title="收件人"></v-list-item>
          <v-divider inset></v-divider>
          <v-list-item
            prepend-icon="mdi-email"
            title="mcbeal@example.com"
          ></v-list-item>

          <v-divider inset></v-divider>

          <v-list-item
            prepend-icon="mdi-map-marker"
            title="收件地址"
          ></v-list-item>
        </v-list>
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
      required: true,
    },
  },
};
</script>

<style></style>