<template>
  <div class="text-center">
    <v-icon v-bind="props" size="x-large">
      {{ "mdi-package-variant-closed-remove" }}
    </v-icon>

    <v-dialog v-model="dialog" activator="parent" width="auto">
      <v-card>
        <v-card-title>
          <span class="text-h5">退貨申請</span>
        </v-card-title>

        <v-form ref="form">
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Legal first name*"
                    v-model="formData.email"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Legal middle name"
                    hint="example of helper text only on focus"
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Legal last name*"
                    hint="example of persistent helper text"
                    persistent-hint
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-text-field label="Email*" required></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    label="Password*"
                    type="password"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-select
                    :items="['0-17', '18-29', '30-54', '54+']"
                    label="Age*"
                    required
                  ></v-select>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-autocomplete
                    :items="[
                      'Skiing',
                      'Ice hockey',
                      'Soccer',
                      'Basketball',
                      'Hockey',
                      'Reading',
                      'Writing',
                      'Coding',
                      'Basejump',
                    ]"
                    label="Interests"
                    multiple
                  ></v-autocomplete>
                </v-col>
              </v-row>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
        </v-form>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
            Close
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="dialog = false">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>


<script>
import axios from "axios";

export default {
  data() {
    return {
      dialog: false,
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
