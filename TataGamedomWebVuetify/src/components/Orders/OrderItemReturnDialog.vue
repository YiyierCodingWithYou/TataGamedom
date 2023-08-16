<template>
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
</template>


<script>
import { ref, watch } from "vue";
import axios from "axios";

export default {
  props: {
    modelValue: {
      type: Boolean,
      required: true,
    },
    orderId: {
      type: [String, Number],
      required: true,
    },
  },
  setup(props, { emit }) {
    const dialog = ref(false);
    const enabled = ref(false);
    const loading = ref(false); // Added for loading state
    const formData = ref({
      email: "",
      //todo
    });

    const saveData = async () => {
      // Assuming you want to validate enabled state here, otherwise add your condition.
      if (enabled.value) {
        try {
          loading.value = true; // start loading
          const response = await axios.post(
            "/your-api-endpoint",
            formData.value
          );
          if (response.status === 200) {
            dialog.value = false;
          }
        } catch (error) {
          console.error("Error submitting form:", error);
        } finally {
          loading.value = false; // end loading
        }
      }
    };

    watch(dialog, (newValue) => {
      emit("update:modelValue", newValue);
    });

    return {
      dialog,
      enabled,
      formData,
      saveData,
      loading, // return loading to template
    };
  },
};
</script>
