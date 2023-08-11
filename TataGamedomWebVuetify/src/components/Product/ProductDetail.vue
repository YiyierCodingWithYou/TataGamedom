<template>
  <div>
    <v-row>
      <div class="d-flex flex-no-wrap">
        <div class="ma-3">
          <v-img
            :src="imgLink + productData.gameCoverImg"
            width="650"
            cover
          ></v-img>
        </div>
        <div class="d-flex flex-column mt-3">
          <v-card-title class="text-h5">
            {{ productData.chiName }}
          </v-card-title>
          <hr />
          <v-card-title class="text-h5">
            {{ productData.engName }}
          </v-card-title>
          <div class="d-flex text-h3">
            <v-card-subtitle
              class="me-auto"
              v-for="item in productData.coupons"
              :key="item"
            >
              {{ item }}
            </v-card-subtitle>
            <v-card-subtitle
              v-for="item in productData.couponDescription"
              :key="item"
            >
              {{ item }}
            </v-card-subtitle>
          </div>
          <v-card-subtitle v-if="productData.specialPrice === productData.price"
            >${{ productData.price }}</v-card-subtitle
          >
          <v-card-subtitle v-else
            ><s>${{ productData.price }}</s
            >${{ productData.specialPrice }}</v-card-subtitle
          >
          <div class="d-flex">
            <v-rating
              v-model="productData.score"
              class="ma-2 d-flex me-auto"
              density="compact"
              half-increments
              readonly
            ></v-rating
            >｜
            <v-card-subtitle
              >{{ productData.commentCount }}個評論</v-card-subtitle
            >
          </div>
          <div>
            <v-row>
              <v-col cols="4">
                <v-btn
                  icon
                  @click="decreaseQuantity"
                  :max="limit"
                  v-model="quantity"
                >
                  <v-icon>mdi-minus</v-icon>
                </v-btn>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  v-model="quantity"
                  min="1"
                  :max="limit"
                  outlined
                  readonly
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-btn icon @click="increaseQuantity" v-model="quantity">
                  <v-icon>mdi-plus</v-icon>
                </v-btn>
              </v-col>
            </v-row>
          </div>
          <v-btn
            v-if="limit > 0"
            class="mt-auto ma-3"
            @click="Add2Cart(productData.id)"
            >加入購物車</v-btn
          >
          <v-btn v-else-if="limit === 0" class="mt-auto ma-3" disabled
            >售完</v-btn
          >
          <p v-if="limit > 0 && limit <= 10" class="text-center">
            現庫存剩餘{{ limit }}件
          </p>
          <p v-else-if="limit === 0" class="text-center">無庫存</p>
        </div>
      </div>
    </v-row>
    <v-row>
      <v-container>
        <v-sheet>
          <div class="ma-5">
            <h3>🎮 遊戲簡介</h3>
            <p>{{ productData.description }}</p>
          </div>
          <div class="ma-5">
            <h3>🎮 系統需求</h3>
            <p>{{ productData.systemRequire }}</p>
          </div>
          <div class="d-flex ma-5">
            <div v-for="item in productData.classification" :key="item">
              <v-chip @click="classificationHandler(item)">#{{ item }}</v-chip>
            </div>
          </div>
          <div class="d-flex ma-5">
            <h3 ref="bookmark">🎮 遊戲評論</h3>
            <span>({{ productData.commentCount }})</span>
          </div>

          <v-card
            v-for="item in productData.gameComments"
            :key="item"
            class="ma-5"
          >
            <v-card-item>
              <v-card-title>{{ item.memberName }}</v-card-title>

              <v-card-subtitle
                >發表於 {{ relativeTime(item.createdTime) }}</v-card-subtitle
              >
            </v-card-item>
            <v-card-text> {{ item.content }} </v-card-text>
            <v-rating
              v-model="item.score"
              density="compact"
              readonly
            ></v-rating>
          </v-card>
          <v-pagination
            v-model="thePage"
            :length="totalPages"
            :total-visible="5"
            @click="paginationHandler(thePage)"
          ></v-pagination>
        </v-sheet>
      </v-container>
    </v-row>
  </div>
</template>
    
<script setup>
import { ref, onMounted, defineProps, watch, defineEmits, nextTick } from "vue";
import { useRouter } from "vue-router";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";

const router = useRouter();
const props = defineProps({ productData: Object });
const quantity = ref(1);
const limit = ref(null);
const imgLink = "https://localhost:7081/Files/Uploads/";
const totalPages = ref();
const thePage = ref(1);
const bookmark = ref(null);

watch(props, (newProps) => {
  if (newProps.productData.id) {
    fetchQuantityLimit();
  }
});

const fetchQuantityLimit = async () => {
  const response = await fetch(
    `https://localhost:7081/api/InventoryItems/RemainingQuantity/${props.productData.id}`
  );
  const datas = await response.json();
  limit.value = datas;
  totalPages.value = props.productData.totalPages;
  console.log(totalPages.value);
};

watch(quantity, () => {
  fetchQuantityLimit();
});

const increaseQuantity = () => {
  if (quantity.value < limit.value) {
    quantity.value++;
  }
};

const decreaseQuantity = () => {
  if (quantity.value > 1) {
    quantity.value--;
  }
};

const Add2Cart = async (productId) => {
  const response = await fetch(`https://localhost:7081/api/Carts`, {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      productId: productId,
      qty: quantity.value,
    }),
  });
  let result = await response.json();
  if (result.isFail) {
    alert(result.message);
    router.push({
      name: "Login",
    });
  }
  alert(result.message);
};

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

const emit = defineEmits(["paginationInput"]);

const paginationHandler = (page) => {
  thePage.value = page;
  emit("paginationInput", page);

  nextTick(() => {
    if (bookmark.value) {
      const offset = bookmark.value.offsetTop;
      window.scrollTo({
        top: offset,
        behavior: "smooth",
      });
    }
  });
};

const classificationHandler = (click) => {
  router.push({
    name: eCommerce,
    params: { classification: click },
  });
};
</script>
    
<style></style>