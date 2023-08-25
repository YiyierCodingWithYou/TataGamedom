<template>
  <div>
    <v-row>
      <CartDrawer v-model="drawer" ref="drawerComponent"></CartDrawer>
      <div class="d-flex flex-no-wrap">
        <div class="ma-3">
          <v-img :src="imgLink + productData.gameCoverImg" width="650" cover></v-img>
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
            <v-card-subtitle class="me-auto" v-for="(item, index) in productData.coupons" :key="index">
              {{ item }}{{ productData.couponDescription[index] }}<br />
            </v-card-subtitle>
          </div>
          <v-card-subtitle v-if="productData.specialPrice === productData.price">${{ productData.price
          }}</v-card-subtitle>
          <v-card-subtitle v-else><s>${{ productData.price }}</s>${{ productData.specialPrice }}</v-card-subtitle>
          <div class="d-flex">
            <v-rating v-model="productData.score" class="ma-2 d-flex me-auto" density="compact" half-increments
              readonly></v-rating>｜
            <v-card-subtitle>{{ productData.commentCount }}個評論</v-card-subtitle>
          </div>
          <div>
            <v-row>
              <v-col cols="4">
                <v-btn icon @click="decreaseQuantity" :max="limit" v-model="quantity">
                  <v-icon>mdi-minus</v-icon>
                </v-btn>
              </v-col>
              <v-col cols="4">
                <v-text-field v-model="quantity" min="1" :max="limit" outlined></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-btn icon @click="increaseQuantity" v-model="quantity">
                  <v-icon>mdi-plus</v-icon>
                </v-btn>
              </v-col>
            </v-row>
          </div>
          <v-btn v-if="limit > 0" class="mt-auto ma-3" @click.stop="Add2Cart(productData.id)"
            color="#FFBF5D">加入購物車</v-btn>
          <v-btn v-else-if="limit === 0" class="mt-auto ma-3" disabled>售完</v-btn>
          <p v-if="limit > 0 && limit <= 1000" class="text-center">
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
            <p v-html="productData.systemRequire"></p>
          </div>
          <div class="d-flex ma-5">
            <div v-for="item in productData.classification" :key="item">
              <v-chip class="mr-2" @click="classificationHandler(item)">#{{ item }}</v-chip>
            </div>
          </div>
          <div class="d-flex ma-5">
            <h3 ref="bookmark">🎮 遊戲評論</h3>
            <span class="me-auto">({{ productData.commentCount }})</span>
            <v-btn color="#FFBF5D" @click="toBoard">前往討論版</v-btn>
          </div>
          <v-card v-for="item in productData.gameComments" :key="item" class="ma-5">
            <v-card-item>
              <v-card-title>{{ item.memberName }}</v-card-title>
              <v-card-subtitle>發表於 {{ relativeTime(item.createdTime) }}</v-card-subtitle>
            </v-card-item>
            <v-card-text> {{ item.content }} </v-card-text>
            <v-rating v-model="item.score" density="compact" color="yellow" readonly></v-rating>
          </v-card>
          <v-pagination v-model="thePage" :length="totalPages" :total-visible="5"
            @click="paginationHandler(thePage)"></v-pagination>
        </v-sheet>
        <v-form @submit.prevent="commentSubmit">
          <div class="ma-5">
            <h3>🎮 發表評論</h3>
            <div v-if="$store.state.isLoggedIn">
              <v-textarea :rules="rules" clearable variant="solo" rows="4" v-model="comment"></v-textarea>
              <div class="d-flex">
                <div class="text-center me-auto">
                  <v-rating v-model="star" bg-color="orange-lighten-1" color="yellow"></v-rating>
                </div>
                <v-btn type="submit" :disabled="comment.length < 10 || comment.length > 500 || star == 0
                  " color="#FFBF5D">送出</v-btn>
              </div>
            </div>
            <div v-else>
              <v-card height="100" class="d-flex align-center justify-center">
                <p>
                  請先登入會員以啟用評論功能，<a href="/Members/Login">點此登入</a>
                </p>
              </v-card>
            </div>
          </div>
        </v-form>
      </v-container>
    </v-row>
  </div>
</template>
    
<script setup>
import { ref, onMounted, defineProps, watch, defineEmits, nextTick } from "vue";
import { useRouter } from "vue-router";
import { format } from "date-fns";
import { zhTW } from "date-fns/locale";
import store from "@/store";
import CartDrawer from "@/components/eCommerce/CartDrawer.vue";

const drawer = ref(false);
const router = useRouter();
const props = defineProps({ productData: Object });
const quantity = ref(1);
const limit = ref(null);
const imgLink = "https://localhost:7081/Files/Uploads/";
const totalPages = ref();
const thePage = ref(1);
const bookmark = ref(null);
const star = ref(0);
const comment = ref("");
const API = "https://localhost:7081/api/";
const drawerComponent = ref(null)
const quantityNum = ref(0)

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

//加入購物車
const Add2Cart = async (productId) => {
  if (quantity.value > limit.value) {
    alert("所選數量超過庫存限制！");
    return;
  }

  let totalQuantity = quantity.value;

  if (store.state.isLoggedIn) {
    const response = await fetch(`${API}Carts`, {
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
      router.push({
        name: "Login",
      });
    }
    alert(result.message);
    autoToggleDrawer(); // 設置計時器來自動關閉抽屜
  }


  quantityNum.value = parseInt(quantity.value)

  if (!store.state.isLoggedIn) {
    let localCart = localStorage.getItem("localCart");
    if (localCart) {
      localCart = JSON.parse(localCart);
    } else {
      localCart = [];
    }
    const existingProduct = localCart.find(
      (item) => item.productId === productId
    );
    if (existingProduct) {
      totalQuantity = quantityNum.value + existingProduct.qty;
      if (totalQuantity > limit.value) {
        alert("所選數量加上購物車中現有數量超過庫存限制！");
        return;
      }
      console.log("exqty=" + existingProduct.qty);
      console.log("quantityNum.value=" + quantityNum.value);
      existingProduct.qty += quantityNum.value;
      console.log("exqty=" + existingProduct.qty);
      localStorage.setItem("localCart", JSON.stringify(localCart));
    }
    else {
      localCart.push({ productId, qty: quantityNum.value });
    }
    autoToggleDrawer(); // 設置計時器來自動關閉抽屜
    alert("已成功加入購物車！");
  }
};



const autoToggleDrawer = () => {
  console.log("我該還沒開ㄌ" + drawer.value);
  openDrawerFromParent();
  console.log("我該開ㄌ" + drawer.value);
  setTimeout(() => {
    console.log("我準備關ㄌ" + drawer.value);
    closeDrawer();
    console.log("我該關ㄌ" + drawer.value);
  }, 1000);
};

const openDrawerFromParent = () => {
  drawerComponent.value.drawerContent();
  drawer.value = true;

  console.log("我開ㄌ3");

};

const closeDrawer = () => {
  drawer.value = false;
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
const returnComments = () => {
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

const paginationHandler = (page) => {
  thePage.value = page;
  emit("paginationInput", page);
  returnComments();
};

const classificationHandler = (value) => {
  router.push({
    name: "eCommerce",
    query: {
      classificationChosen: value,
    },
  });
};

const rules = [
  (value) => !!value || "評論不可為空",
  (value) => (value && value.length >= 10) || "評論不得低於10個字",
  (value) => (value && value.length <= 500) || "評論不得超過500個字",
];

//發表評論
const commentSubmit = async () => {
  const response = await fetch(
    `https://localhost:7081/api/Products?productId=${props.productData.id}`,
    {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        content: comment.value,
        score: star.value,
      }),
    }
  )
    .then((response) => response.json())
    .then((result) => {
      if (result.message === "發表評論成功") {
        (comment.value = ""), (star.value = 0);
        alert(result.message);
        emit("commentSucceed");
        returnComments();
      } else {
        alert(result.message);
      }
    })
    .catch((error) => {
      console.error("Error:", error);
    });
};

const toBoard = async () => {
  //console.log(props.productData.boardId);
  router.push({
    name: "GameLoungeBoard",
    params: { boardId: props.productData.boardId },
  });
};
</script>
    
<style></style>