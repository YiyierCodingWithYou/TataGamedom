<template>
  <div class="text-center">
    <v-icon size="x-large">
      {{ "mdi-package-variant-closed-remove" }}
    </v-icon>

    <v-dialog v-model="dialog" activator="parent" width="auto">
      <v-spacer></v-spacer>
      <v-sheet width="1000" class="mx-auto">
        <v-form validate-on="submit lazy" @submit.prevent="submit">
          <v-card>
            <v-card-text>
              <div class="d-flex pa-4">
                <v-checkbox-btn v-model="enabled" class="pe-2"></v-checkbox-btn>
                <v-text-field
                  :disabled="!enabled"
                  hide-details
                  label="I only work if you check the box"
                ></v-text-field>
              </div>
            </v-card-text>
          </v-card>

          <v-spacer></v-spacer>
          <v-btn block class="mt-2" text="取消" @click="dialog = false"></v-btn>
          <v-btn
            :loading="loading"
            block
            class="mt-2"
            text="送出"
            type="submit"
            @click="dialog = false"
          ></v-btn>
        </v-form>
      </v-sheet>
    </v-dialog>
  </div>
</template>


<script>
import axios from "axios";

export default {
  data() {
    return {
      dialog: false,
      enabled: false,
      formData: {
        email: "",
        //todo
      },
    };
  },
  props: {
    orderId: {
      type: [String, Number],
      required: true,
    },
  },
  methods: {
    async saveData() {
      if (this.$refs.form.validate()) {
        // 檢查表單驗證
        try {
          const response = await axios.post(
            "/your-api-endpoint",
            this.formData
          );
          if (response.status === 200) {
            this.dialog = false;
            // ... 你的其他邏輯，例如顯示成功訊息 ...
          }
        } catch (error) {
          console.error("Error submitting form:", error);
          // ... 你的其他邏輯，例如顯示錯誤訊息 ...
        }
      }
    },
  },
};
</script>
