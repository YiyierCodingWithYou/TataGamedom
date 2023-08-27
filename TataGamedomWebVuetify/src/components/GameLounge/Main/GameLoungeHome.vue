<template>
  <div id="JoinUs" class="diamond-wrapper" @click="sendEmits">
    <div class="diamond"></div>
    <div class="diamond"></div>
    <div class="diamond-text">
      <h1>參與巢穴</h1>
      <h2>啟動你的遊戲社群</h2>
    </div>
  </div>
  <div class="d-flex flex-column blur">
    <div class="bg-pink h-500px">
      <swiper
        v-if="boardInfo.length > 0"
        :slidesPerView="3"
        :spaceBetween="0"
        :loop="true"
        :autoplay="{ delay: 1, disableOnInteraction: false }"
        :speed="2500"
        :modules="modules"
        class="mySwiper"
      >
        <swiper-slide
          v-for="(slide, index) in boardInfo"
          :key="index"
          :style="{ backgroundImage: `url(${slide.bgImg})` }"
          @click="goToBoard(slide.id)"
        >
          {{ slide.content }}
        </swiper-slide>
      </swiper>
    </div>
    <div class="bg-blue h-500px">
      <swiper
        v-if="boardInfo.length > 0"
        :slidesPerView="3"
        :spaceBetween="0"
        :loop="true"
        :autoplay="{ delay: 1, disableOnInteraction: false }"
        :speed="2500"
        :modules="modules"
        dir="rtl"
        class="mySwiper"
      >
        <swiper-slide
          v-for="(slide, index) in boardInfo"
          :key="index"
          :style="{ backgroundImage: `url(${slide.bgImg})` }"
          @click="goToBoard(slide.id)"
        >
          {{ slide.content }}
        </swiper-slide>
      </swiper>
    </div>
    <div class="bg-pink h-500px">
      <swiper
        v-if="boardInfo.length > 0"
        :slidesPerView="3"
        :spaceBetween="0"
        :loop="true"
        :autoplay="{ delay: 1, disableOnInteraction: false }"
        :speed="2500"
        :modules="modules"
        class="mySwiper"
      >
        <swiper-slide
          v-for="(slide, index) in boardInfo"
          :key="index"
          :style="{ backgroundImage: `url(${slide.bgImg})` }"
          @click="goToBoard(slide.id)"
        >
          {{ slide.content }}
        </swiper-slide>
      </swiper>
    </div>
  </div>
</template>
<script setup>
import { ref, onMounted } from "vue";
import { Swiper, SwiperSlide } from "swiper/vue";
import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/pagination";
import { Autoplay, Pagination } from "swiper/modules";
import { useRouter } from "vue-router";
import axios from "axios";

const emits = defineEmits(["goTab3"]);
const sendEmits = () => {
  emits("goTab3");
};

const modules = ref([Autoplay, Pagination]);
const boardInfo = ref([]);
const router = useRouter();
const goToBoard = (id) => {
  router.push({
    name: "GameLoungeBoard",
    params: { boardId: id },
  });
};

const getBoardInfo = async () => {
  axios
    .get(`https://localhost:7081/api/Boards`, {
      withCredentials: true,
    })
    .then((res) => {
      boardInfo.value = res.data.map((data) => {
        return {
          id: data.id,
          bgImg: data.boardHeaderCoverImgUrl,
          name: data.gameName,
        };
      });

      console.log(boardInfo.value);
    })
    .catch((err) => {
      console.log(err);
    });
};
onMounted(() => {
  getBoardInfo();
});
</script>
<style>
#JoinUs {
  position: fixed;
  top: 40%;
  left: 50%;
  z-index: 99;
}
.blur {
  filter: blur(1px) grayscale(10%) contrast(110%);
}
.bg1 {
  background-image: url("https://picsum.photos/200/300") !important;
}
.swiper {
  width: 100%;
  height: 100%;
}
.mySwiper {
  cursor: pointer;
}
.h-500px {
  height: calc((100vh - 64px - 48px) / 3);
}

.swiper-slide {
  text-align: center;
  font-size: 18px;
  background-color: rgb(1, 1, 15);
  color: #f9ee08;

  /* Center slide text vertically */
  display: flex;
  justify-content: center;
  align-items: center;
  background-size: cover;
  background-position: center;
}

.swiper-wrapper {
  transition-timing-function: linear;
}

/* Diamond */

.before-after-content,
.diamond:before,
.diamond:after {
  content: "";
  position: absolute;
  width: 100%;
  height: 100%;
  transition: all 0.25s ease-in-out;
}

.diamond-wrapper {
  position: relative;
  cursor: pointer;
  width: 300px;
  height: 300px;
  left: 50%;
  transform: translateX(-50%) rotate(45deg);
}
.diamond-wrapper:hover .diamond {
  background-color: rgba(1, 1, 15, 0.3);
}
.diamond-wrapper:hover .diamond:before,
.diamond-wrapper:hover .diamond:after {
  transform: rotate(0deg);
}
.diamond-wrapper:hover .diamond-text > * {
  transform: translateY(-15px);
}

.diamond-text {
  position: absolute;
  top: 110px;
  left: 50px;
  text-align: center;
  transform: rotate(-45deg);
  color: #a1dfe9;
  font-family: "Digi-font";
}
.diamond-text > * {
  transition: transform 0.25s ease-in-out;
}
.diamond-text h1 {
  color: #f9ee08;
  line-height: 0.8;
  font-size: 48px;
  margin-bottom: 20px;
}

.diamond {
  position: absolute;
  width: 100%;
  height: 100%;
  background-color: rgb(1, 1, 15);
  transition: all 0.25s ease-in-out;
}
.diamond:first-of-type:before {
  transform: rotate(5deg);
  background: linear-gradient(
    to bottom,
    rgb(1, 1, 15) 0%,
    rgba(1, 1, 15, 0.5) 50%,
    rgba(1, 1, 15, 0) 100%
  );
  top: 13px;
  left: -15px;
}
.diamond:first-of-type:after {
  transform: rotate(5deg);
  background: linear-gradient(
    to top,
    rgb(1, 1, 15) 0%,
    rgba(1, 1, 15, 0.5) 50%,
    rgba(1, 1, 15, 0) 100%
  );
  bottom: 13px;
  left: 15px;
}
.diamond:nth-of-type(2):before {
  transform: rotate(5deg);
  background: linear-gradient(
    to left,
    rgb(1, 1, 15) 0%,
    rgba(1, 1, 15, 0.5) 50%,
    rgba(1, 1, 15, 0) 100%
  );
  top: -14px;
  left: -13px;
}
.diamond:nth-of-type(2):after {
  transform: rotate(5deg);
  background: linear-gradient(
    to right,
    rgb(1, 1, 15) 0%,
    rgba(1, 1, 15, 0.5) 50%,
    rgba(1, 1, 15, 0) 100%
  );
  bottom: -14px;
  left: 13px;
}
</style>
