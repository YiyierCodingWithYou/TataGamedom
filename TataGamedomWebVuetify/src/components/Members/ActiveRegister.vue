<template>
    <h2 v-if="processing">驗證中請稍後</h2>
    <div v-else>
        <h2 v-if="isOk === true">驗證成功</h2>
        <h2 v-else>驗證失敗</h2>
    </div>
</template>
    
<script>
import axios from "axios";

export default {
    data: () => ({
        isOk: false,
        processing: true
    }),
    created() {
        this.sendVerify()
    },
    methods: {
        sendVerify() {
            console.log(this.$route.query);
            axios
                .post(
                    "https://localhost:7081/api/Members/ActiveRegister",
                    {
                        memberId: this.$route.query.memberId,
                        confirmCode: this.$route.query.confirmCode
                    },
                )
                .then((res) => {
                    console.log(res);
                    console.log("驗證成功");
                    this.processing = false
                    this.isOk = true;
                })
                .catch((err) => {
                    console.log(err);
                    this.processing = false
                    console.log("驗證失敗");
                });
        },

    },
};
</script>
    
<style></style>