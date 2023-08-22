<template>
  <v-form @submit.prevent="handleSubmit">
    <v-text-field
      v-model="form.receiverName"
      label="Receiver Name"
      required
    ></v-text-field>

    <v-text-field
      v-model="form.goodsAmount"
      label="Goods Amount"
      required
      type="number"
    ></v-text-field>

    <v-text-field
      v-model="form.receiverAddress"
      label="Receiver Address"
      required
    ></v-text-field>

    <v-text-field
      v-model="form.receiverCellPhone"
      label="Receiver Cell Phone"
      required
    ></v-text-field>

    <v-btn type="submit">Submit</v-btn>
  </v-form>
  <div>
    <iframe :src="url" width="100%" height="500px"></iframe>
  </div>
</template>
  
<script>
import { ref } from "vue";
import { useStore } from "vuex";

export default {
  name: "LogisticsForm",
  setup() {
    const store = useStore();
    const form = ref({
      goodsAmount: "",
      receiverAddress: "",
      receiverCellPhone: "",
      receiverName: "",
    });
    const responseHtml = ref("");
    const blob = ref(null);
    const url = ref("");

    const updateBlobAndUrl = () => {
      blob.value = new Blob([responseHtml.value], { type: "text/html" });
      url.value = URL.createObjectURL(blob.value);
    };

    const handleSubmit = async () => {
      try {
        var response = await store.dispatch(
          "navigateToLogisticsSelection",
          form.value
        );

        responseHtml.value = response.data.content;
        console.log(responseHtml.value);
        updateBlobAndUrl();
      } catch (error) {
        console.error("Error submitting the form:", error);
      }
    };

    return {
      form,
      url,
      handleSubmit,
      responseHtml,
      updateBlobAndUrl,
    };
  },
};
</script>
  
  <style scoped>
</style>
  