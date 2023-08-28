<template>
  <div class="home flex-column">
    <div class="homeTitle inline-title color-y">
      <p class="inline-title color-b">最優質的</p>
      <p class="inline-title">遊戲</p>
      <Typed :options="options">
        <p class="typing inline-title"></p>
      </Typed>
      <p class="inline-title color-b">都在...</p>
    </div>
    <div class="nya"></div>
    <div>
      <p class="inline-title font-size-4rem">獺獺</p>
      <p class="inline-title  color-b font-size-4rem">玩國</p>
    </div>
    <div class="inline-title">
      <div class="inline-title-big color-y font-comfortaa">Tata</div>
      <div class="inline-title-big color-b font-comfortaa">Gamedom</div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Typed } from "@duskmoon/vue3-typed-js";
import type { TypedOptions } from "@duskmoon/vue3-typed-js";

const options: TypedOptions = {
  strings: ["商城體驗", "論壇討論 ", "新聞快報"],
  loop: true,
  typeSpeed: 100,
  smartBackspace: false,
};
</script>

<style scoped>
.font-size-4rem {
  font-size: 3rem !important;
  font-weight: bold;
  letter-spacing: 3rem !important;
}

.nya {
  height: 30vh;
  width: 100vw;
  background-image: url("https://vincentgarreau.com/particles.js/assets/img/kbLd9vb_new.gif");
  background-size: contain;
}

.home {
  height: calc(100vh - 64px);
  background-color: #01010f;
  display: flex;
  justify-content: center;
  align-items: center;
  background-image: url("https://universe.nasa.gov/rails/active_storage/disk/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaDdDVG9JYTJWNVNTSnpkbUZ5YVdGdWRITXZNalZpWVRJME1qa3RZamxoWkMwME5qQTRMV0kwTUdZdE56ZzJPR0ptT0RjMFlUUXdMemc1WVdVNFlqbGpZVEZqWTJKaU1HSTRZek0zTWpBM01EQmlZemhtTWpCak1USTJOVEF6TW1KaU9HSm1aR0UyTXpRMk16VXpOMk00T0dGaE1XSmhOVGdHT2daRlZEb1FaR2x6Y0c5emFYUnBiMjVKSWw5cGJteHBibVU3SUdacGJHVnVZVzFsUFNKemQybG1kRjlOTXpGZmJXOXpZV2xqWHpFMk1EQXVkMlZpY0NJN0lHWnBiR1Z1WVcxbEtqMVZWRVl0T0NjbmMzZHBablJmVFRNeFgyMXZjMkZwWTE4eE5qQXdMbmRsWW5BR093WlVPaEZqYjI1MFpXNTBYM1I1Y0dWSklnOXBiV0ZuWlM5M1pXSndCanNHVkRvUmMyVnlkbWxqWlY5dVlXMWxPZ3BzYjJOaGJBPT0iLCJleHAiOm51bGwsInB1ciI6ImJsb2Jfa2V5In19--9f1e36489bc11b71bb02fdc9e02701dcbb58e510/swift_M31_mosaic_1600.webp");
  background-size: cover;
  filter: saturate(400%);
}

.inline-title {
  display: inline-block;
  font-size: 2rem;
  font-weight: 600;
  font-family: "Digi-font";
  letter-spacing: 15px;
}

.inline-title-big {
  display: inline-block;
  font-size: 3rem;
}

.typed-element {
  display: inline-block;
}

.color-y {
  color: #f9ee08;
}

.color-b {
  color: #a1dfe9;
}

.color-k {
  color: #01010f;
}
</style>
