<template>
  <div>
    <v-row>
      <CartDrawer v-model="drawer" ref="drawerComponent" class="myDraw"></CartDrawer>
      <v-container class="d-flex flex-no-wrap">
        <v-row>
          <v-col cols="6">
            <div class="mt-3 d-flex justify-center align-center">
              <v-img :src="imgLink + productData.gameCoverImg" height="380" cover></v-img>
            </div>
          </v-col>
          <v-col cols="6">
            <div class="d-flex flex-column mt-3 whiteText">
              <div class="text-h5 mb-2 ml-3" style="color:#a1dfe9">
                ✨{{ productData.chiName }}
              </div>
              <v-divider class="border-opacity-100 mb-2" color="#a1dfe9"></v-divider>
              <div class="text-h5 ml-3" style="color:#a1dfe9">
                {{ productData.engName }}
              </div>
              <div class="mt-3 mb-3 ml-3">
                <p class="me-auto" v-for="(item, index) in productData.coupons" :key="index">{{ item }}{{
                  productData.couponDescription[index] }}<br /></p>
              </div>
              <p class="ml-3 mb-3" style="font-size: 20px; color:white"
                v-if="productData.specialPrice === productData.price">${{ productData.price
                }}</p>
              <p class="ml-3 mb-3" v-else><s style="font-size: 16px; color:grey">${{ productData.price }}</s><span
                  style="font-size: 20px; color:white">　${{ productData.specialPrice }}</span></p>
              <div class="d-flex align-center mb-3">
                <v-rating v-model="productData.score" class="ma-2 d-flex me-auto" density="compact" half-increments
                  readonly style="color:#f9ee08" size="small"></v-rating>
                <p class="mr-3">{{ productData.commentCount }}個評論</p>
              </div>
              <div>
                <v-row class="d-flex justify-center align-center mb-3">
                  <v-col cols="4" class="d-flex justify-center align-center">
                    <v-btn icon @click="decreaseQuantity" :max="limit" v-model="quantity" class="plusMinBtn">
                      <v-icon>mdi-minus</v-icon>
                    </v-btn>
                  </v-col>
                  <v-col cols="4" class="d-flex justify-center align-center">
                    <input type="number" v-model="quantity" min="1" :max="limit"  style="color:#a1dfe9" class="text-center" readonly />
                  </v-col>
                  <v-col cols="4" class="d-flex justify-center align-center">
                    <v-btn icon @click="increaseQuantity" v-model="quantity" class="plusMinBtn">
                      <v-icon>mdi-plus</v-icon>
                    </v-btn>
                  </v-col>
                </v-row>
              </div>
              <v-btn v-if="limit > 0" class="mt-auto ma-3 myBtn" @click.stop="Add2Cart(productData.id)">加入購物車</v-btn>
              <v-btn v-else-if="limit === 0" class="mt-auto ma-3" disabled>售完</v-btn>
              <p v-if="limit > 0 && limit <= 10" class="text-center">
                現庫存剩餘{{ limit }}件
              </p>
              <p v-else-if="limit === 0" class="text-center">無庫存</p>
            </div>
          </v-col>
        </v-row>
      </v-container>
    </v-row>
    <v-row>
      <v-container>
        <v-sheet class="myComment">
          <div class="ma-5">
            <h3 class="mytitle">🦦 遊戲簡介</h3>
            <p class="myContent">{{ productData.description }}</p>
          </div>
          <div class="ma-5">
            <h3 class="mytitle">🦦 系統需求</h3>
            <p class="myContent" v-html="productData.systemRequire"></p>
          </div>
          <div class="d-flex ma-5">
            <div v-for="item in productData.classification" :key="item">
              <v-chip class="mr-2" @click="classificationHandler(item)" style="background-color: #f9ee08;color:#01010f;">#{{ item }}</v-chip>
            </div>
          </div>
          <div class="d-flex justify-center align-center">
            <h3 class="mytitle" ref="bookmark">🦦 遊戲評論</h3>
            <span class="me-auto">({{ productData.commentCount }})</span>
            <v-btn class="myBtn" @click="toBoard">前往討論版</v-btn>
          </div>
          <v-card v-for="item in productData.gameComments" :key="item" class="mt-5 myCard whiteText justify-center align-center">
            <v-card-item>
              <v-card-title class="mt-2 mb-2" >{{ item.memberName }}</v-card-title>
             
              <v-card-subtitle class="mb-2">發表於 {{ relativeTime(item.createdTime) }}</v-card-subtitle>
              <v-divider class="border-opacity-75 mb-2" color="#a1dfe9"></v-divider>
            </v-card-item>
            
            <v-card-text class="myContent"> {{ item.content }} </v-card-text>
            <v-rating v-model="item.score" density="compact" color="yellow" readonly class="ml-3 mb-3"></v-rating>
          </v-card>
          <v-pagination v-model="thePage" :length="totalPages" :total-visible="5" @click="paginationHandler(thePage)"
            color="#f9ee08"></v-pagination>
        </v-sheet>
        <v-form @submit.prevent="commentSubmit">
          <div class="ma-5">
            <h3 class="mytitle">🦦 發表評論</h3>
            <div v-if="$store.state.isLoggedIn">
              <v-textarea :rules="rules" clearable variant="outlined" rows="5" v-model="comment" auto-grow
                base-color="#a1dfe9" color="#a1dfe9"></v-textarea>
              <div class="d-flex">
                <div class="text-center me-auto">
                  <v-rating v-model="star" color="#f9ee08"></v-rating>
                </div>
                <v-btn type="submit" :disabled="comment.length < 10 || comment.length > 500 || star == 0
                  " class="myBtn">送出</v-btn>
              </div>
            </div>
            <div v-else>
              <v-card height="100" class="d-flex align-center justify-center myCard">
                <p class="myComment">
                  請先登入會員以啟用評論功能，<a href="/Members/Login" style="color:#a1dfe9">點此登入</a>
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
    
<style>
.myDraw {
  position: fixed;
  bottom: 20px;
  right: 20px;
  z-index: 20;
}

.myBtn {
  font-size: 18px;
  border: 1px solid #a1dfe9;
  background-color: #01010f;
  color: #a1dfe9;
}

.myBtn:hover {
  background-color: #a1dfe9;
  color: #01010f;
  box-shadow: 2px 2px 10px #a1dfe9;
}

.myComment {
  background-color: #01010f;
  color: white
}

.myCard {
  background-color: #01010f;
  color: #f9ee08;
  box-shadow: 2px 2px 10px #a1dfe9;
  border-radius: 3%;
  border: 2px inset #a1dfe9;
  font-size: 16px
}

.mytitle {
  color: #a1dfe9 !important;
  font-size: 18px;
}

.myContent {
  color: white;
  font-size: 16px;
}

.whiteText {
  color: white;
}

.plusMinBtn {
  background-color: #01010f;
  color: #a1dfe9;
}
</style>