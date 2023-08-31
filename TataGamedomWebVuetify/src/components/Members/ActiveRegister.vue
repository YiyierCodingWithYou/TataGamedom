<template>
    <div>
        <div v-if="processing" class="loading-container">
            <div class="loading-spinner"></div>
            <img src="https://localhost:7081/Files/Uploads/Icons/tataUserIcon.jpg"
                style="margin-left: 30%;height: 700px;width: 700px;" alt="">
        </div>

        <div v-else>
            <h2 v-if="isOk === true">驗證成功</h2>
            <h2 v-else>驗證失敗</h2>
        </div>
    </div>
</template>
  
<script>
import axios from "axios";

export default {
    data: () => ({
        isOk: false,
        processing: true,
    }),
    created() {
        this.sendVerify();
    },
    methods: {
        sendVerify() {
            console.log(this.$route.query);
            axios
                .post(
                    "https://localhost:7081/api/Members/ActiveRegister",
                    {
                        memberId: this.$route.query.memberId,
                        confirmCode: this.$route.query.confirmCode,
                    }
                )
                .then((res) => {
                    console.log(res);
                    console.log("驗證成功");
                    setTimeout(() => {
                        this.processing = false;
                        this.isOk = true;
                    }, 10000);
                })
                .catch((err) => {
                    console.log(err);
                    console.log("驗證失敗");
                    setTimeout(() => {
                        this.processing = false;
                    }, 10000);
                });
        },
    },
};
</script>
  
<style>
.loading-spinner {
    width: 50px;
    height: 50px;
    border: 4px solid rgba(0, 0, 0, 0.2);
    border-top: 4px solid #3498db;
    border-radius: 50%;
    animation: spin 1s linear infinite;
    margin-left: 10px;
}

@keyframes spin {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(360deg);
    }
}
</style>
  