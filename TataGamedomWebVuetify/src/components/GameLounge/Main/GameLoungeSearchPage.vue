<template lang="">
  <v-container class="d-md-flex flex-column align-center justify-center">
    <div class="">
      <h4
        class="text-h4 text-weight-600 d-flex align-end justify-center font-digi font-weight-bold"
      >
        <span class="material-symbols-rounded size1 m-0 p-0">
          switch_access_shortcut
        </span>
        <p>從此探索</p>
      </h4>
    </div>
    <div class="d-md-flex mt-5">
      <v-sheet
        class="sheet sheet1"
        border
        rounded
        :style="{
          backgroundImage: `url(${no1.bgImg})`,
        }"
      >
        <p class="sheet-text text-h3 font-weight-black" v-html="no1.title"></p>
      </v-sheet>
      <v-sheet
        class="sheet sheet2"
        border
        rounded
        :style="{ backgroundImage: `url(${no2.bgImg})` }"
      >
        <p class="sheet-text text-h3 font-weight-black" v-html="no2.title"></p>
      </v-sheet>
      <v-sheet
        class="sheet sheet3"
        :style="{ backgroundImage: `url(${no3.bgImg})` }"
        border
        rounded
      >
        <p class="sheet-text text-h3 font-weight-black" v-html="no3.title"></p>
      </v-sheet>
    </div>
  </v-container>
</template>

<script setup>
import axios from "axios";
import { ref, reactive, computed, onMounted } from "vue";

const data = ref([]);
const topFiveItems = ref([]);
const no1 = ref({});
const no2 = ref({});
const no3 = ref({});

const fetchData = () => {
  axios
    .get(`https://localhost:7081/api/Boards`, {
      withCredentials: true,
    })
    .then((res) => {
      data.value = res.data.sort((a, b) => {
        return a.name.localeCompare(b.name, "zh-TW");
      });

      topFiveItems.value = data.value
        .sort((a, b) => {
          return b.postCurrentCount - a.postCurrentCount;
        })
        .map((data) => {
          return {
            title: data.name.replace(" ", "<br>").replace("！", "！<br>"),

            value: data.id,
            prependAvatar: "",
            bgImg: data.boardHeaderCoverImgUrl,
            height: "75px",
            rounded: "shaped",
          };
        })
        .slice(0, 5);
      console.log(topFiveItems.value);
      console.log(topFiveItems.value[0]);
      no1.value = topFiveItems.value[0];
      no2.value = topFiveItems.value[1];
      no3.value = topFiveItems.value[2];
    })
    .catch((err) => {
      console.log(err);
    });
};

onMounted(() => {
  fetchData();
});
</script>
<style>
@import url("https://fonts.googleapis.com/css2?family=Zen+Antique&display=swap");

.font-digi {
  font-family: "Digi-font" !important;
}

.size1 {
  font-size: 4rem !important;
}
.sheet-text {
  max-width: 80%;
  font-family: "Digi-font" !important;
  filter: contrast(1.2);
  color: #a1dfe9;
  margin-left: 3%;
}

.sheet {
  height: 70vh;
  min-width: 30vw;
  transition: all 0.2s ease-in-out;
  box-shadow: 0px 0px 10px 5px rgba(161, 223, 233, 0.5);
  position: relative;
  cursor: pointer;
  background-size: contain;
  background-position: center;
  background-repeat: no-repeat;
  background-color: rgba(99, 99, 99, 0.05);
  border: 1pt solid rgba(249, 238, 8, 0.5);
  rotate: 15deg;
  transform: scale(0.8);
}
.sheet:hover {
  transform: translateY(-5vh) scale(1);
  background-color: black;
  box-shadow: 0px 0px 15px 10px rgba(161, 223, 233, 0.6);
  z-index: 5;
}
.sheet:hover::before {
  content: "進入巢穴";
  font-family: "Digi-font";
  font-weight: 700;
  font-size: 3rem;
}

.sheet:hover::after {
  content: " Enter!! ";
  transform: scale(1.1);
}
.sheet::after {
  position: absolute;
  content: " ";
  rotate: 30deg;
  font-size: 3rem;
  top: 3%;
  right: -5%;
  font-family: Silkscreen;
  font-weight: 700;
  color: #f9ee08;
  z-index: 10;
  text-shadow: #fc0 1px 0 10px;
  transition: all 0.2s ease-in-out;
}

.sheet1::before {
  position: absolute;
  content: "NO.1";
  font-size: 4rem;
  bottom: 1%;
  right: 10%;
  font-family: Silkscreen;
  font-weight: 700;
  color: white;
}
.sheet2::before {
  position: absolute;
  content: "NO.2";
  font-size: 3rem;
  bottom: 1%;
  right: 10%;
  font-family: Silkscreen;
  font-weight: 700;
  color: white;
}
.sheet3::before {
  position: absolute;
  content: "NO.3";
  font-size: 3rem;
  bottom: 1%;
  right: 10%;
  font-family: Silkscreen;
  font-weight: 700;
  color: white;
}
</style>
