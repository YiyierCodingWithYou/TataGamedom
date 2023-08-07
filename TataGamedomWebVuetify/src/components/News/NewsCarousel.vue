<template>
         <h1>新聞主頁</h1>
   <v-carousel hide-delimiters style="height: 500px;">
    <v-carousel-item
      v-for="(item,i) in items"
      :key="i"
      :src="item.src"
      cover
    >  
    <div class="title">
           <p class="titleword">喔是喔</p>
    </div>
</v-carousel-item>
  </v-carousel>

</template>
    
<script>
     export default {
    data () {
      return {
        items: [
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/squirrel.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/sky.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/bird.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg',
          },
          {
            src: 'https://cdn.vuetifyjs.com/images/carousel/planet.jpg',
          },
        ],
      }
    },
  }
</script>
    
<style>
    .title{
        background-color: rgba(0, 0, 0, 0.9);
        height: 100px;
        margin-top: 400px;
    }
    .titleword{
        color:white;
        display: flex;

 
    }
</style>