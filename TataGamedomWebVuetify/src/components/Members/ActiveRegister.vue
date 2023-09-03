<template>
    <div>
        <div v-if="processing" class="loading-container">

            <img src="https://localhost:7081/Files/Icons/tataing.png"
                style="position: relative;;margin-left: 30%;height: 700px;width: 700px;" alt="">
            <div class="loading-spinner" style="position:absolute; top:61%; left: 46%;"></div>
        </div>

        <div v-else>
            <div v-if="isOk === true">
                <img src="https://localhost:7081/Files/Icons/tataOK.png"
                    style="margin-left: 30%;height: 700px;width: 700px;" alt="">
            </div>
            <div v-else>
                <img src="https://localhost:7081/Files/Icons/tataerr.png"
                    style="margin-left: 30%;height: 700px;width: 700px;" alt="">
            </div>
        </div>
    </div>
</template>
  
<script>
import axios from "axios";
import { useRouter } from "vue-router";

export default {
    data: () => ({
        isOk: false,
        processing: true,
    }),
    created() {
        this.sendVerify();
    },
    methods: {
        isOktrue() {
            this.isOk = true;
        },
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
                    this.isOktrue(),
                        setTimeout(() => {
                            this.processing = false;
                            setTimeout(() => {
                                console.log("aaaaa", this.isOk);
                                this.$router.push("/Members/Login");
                            }, 3000);
                        }, 3000);
                })
                .catch((err) => {
                    console.log(err);
                    console.log("驗證失敗");
                    setTimeout(() => {
                        this.processing = false;
                    }, 3000);
                });
        },
    },
};
</script>
  
<style>
.loading-spinner {
    width: 70px;
    height: 70px;
    border: 4px solid rgba(0, 0, 0, 0.2);
    border-top: 5px solid #3498db;
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
  