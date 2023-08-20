<template>
    <NewsCarousel />
    <v-main class="bg-grey-lighten-3 v-main">
        <v-container>
            <v-row>
                <v-col cols="8">
                    <v-sheet min-height="300vh" rounded="lg">
                        <div>
                            <div>{{ newsData.title }}</div>
                            <div>{{ newsData.content }}</div>
                            <div>{{ newsData.scheduleDate }}</div>
                            <div>{{ newsData.name }}</div>
                        </div>

                        <div v-for="item in newsData.newsComments" :key="item" class="mt-5">
                            <div>{{ item.name }}</div>
                            <div>{{ item.content }}</div>
                            <div>發表於:{{ relativeTime(item.time) }}</div>
                        </div>

                        <div class="mt-5">
                            留言區塊
                            <div>按讚啦</div>
                        </div>
                    </v-sheet>
                </v-col>

                <v-col cols="4" style="position: absolute; left: 71%; max-width: 550px">
                    <v-sheet rounded="lg" min-height="100">
                        <h1>關鍵字搜尋</h1>
                        <SearchTextBox class="mt-2" @searchInput="inputHandler"></SearchTextBox>
                    </v-sheet>
                </v-col>

                <v-col cols="4" class="gameclass">
                    <v-sheet rounded="lg" min-height="400">
                        <h1>遊戲類別</h1>
                        <NewsGameClass @classificationInput="classificationHandler" class="mt-10"></NewsGameClass>
                    </v-sheet>
                </v-col>

                <v-col cols="4" class="hotnews">
                    <v-sheet rounded="lg" min-height="500">
                        <h1 class="">熱門新聞</h1>
                        <HotNews></HotNews>
                    </v-sheet>
                </v-col>
            </v-row>
        </v-container>
    </v-main>


    <!-- <v-container class="container">
        <v-row>

        </v-row>
    </v-container> -->
</template>
    
<script setup >
import { ref, onMounted } from "vue";
import { useRoute } from 'vue-router';
import NewsCarousel from "../News/NewsCarousel.vue";
import SearchTextBox from "../News/SearchTextBox.vue";
import NewsGameClass from "./NewsGameClass.vue";
import HotNews from "../News/HotNews.vue";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";


const route = useRoute();
const newsData = ref([]);
const newsComments = ref([])
const newsId = ref(parseInt(route.params.newsId, 10));

const loadData = async () => {
    try {
        const response = await fetch(`https://localhost:7081/api/News/${newsId.value}`);
        const datas = await response.json();
        newsData.value = datas;
        console.log("aaaa", datas);
        console.log("bbb", datas.newsComments);
        console.log("ccc", newsId.value);
    } catch (err) {
        console.log('錯誤訊息', err);
    }
};

onMounted(() => {
    loadData();
});


// //留言
// const comment;


// //按讚
// const likes;


// //收回讚
// const dislikes;



//時間轉換
const relativeTime = (datetime) => {
    const formattedDate = format(
        new Date(datetime),
        "yyyy年MM月dd日 EEEE HH:mm:ss",
        {
            locale: zhTW,
        }
    );
    return formattedDate;
};
</script>
    
<style>
.v-main {
    padding-top: 0;
}
</style>