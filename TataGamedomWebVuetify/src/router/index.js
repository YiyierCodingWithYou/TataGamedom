// Composables
import { createRouter, createWebHistory } from "vue-router";
import eCommerce from "@/views/eCommerce.vue";
import SingleProduct from "@/views/SingleProduct.vue";
import Members from "../views/Members.vue";
import News from "../views/NewsIndex.vue";
import NewsPage from "@/components/News/NewsPage.vue";
import RegisterVue from "@/components/Members/Register.vue";
import Login from "@/components/Members/Login.vue";
import ForgetPwd from "@/components/Members/ForgetPwd.vue";
import Orders from "../views/Orders.vue";
import SupportHub from "../views/SupportHub.vue";
import LinePay from "../views/LinePay.vue";
import ActiveRegister from "@/components/Members/ActiveRegister.vue";
import LinePayConfirmPayment from "../views/LinePayConfirmPayment.vue";
import Cart from "@/views/Cart.vue";
import MemberDetial from "@/components/Members/MemberDetial.vue";
import ResetPassword from "@/components/Members/ResetPassword.vue";
import store from "@/store";
import RedirectToLogisticsSelection_Test from "@/components/ECPay/RedirectToLogisticsSelection_Test";

const routes = [
  {
    path: "/",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "",
        name: "Home",
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
          import(/* webpackChunkName: "home" */ "@/views/Home.vue"),
      },
      {
        path: "/Members",
        name: "Members",
        component: Members,
      },
      {
        path: "/News",
        name: "News",
        component: News,
      },
      {
        path: "News/:newsId",
        name: "NewsPage",
        component: NewsPage,
      },
      {
        path: "/Members/Register",
        name: "Register",
        component: RegisterVue,
        beforeEnter: (to, from, next) => {
          if (store.state.isLoggedIn === true) {
            next("/");
          } else {
            next();
          }
        },
      },
      {
        path: "/Members/Login",
        name: "Login",
        component: Login,
        beforeEnter: (to, from, next) => {
          if (store.state.isLoggedIn === true) {
            next("/");
          } else {
            next();
          }
        },
      },
      {
        path: "/Members/ForgetPwd",
        name: "ForgetPwd",
        component: ForgetPwd,
        beforeEnter: (to, from, next) => {
          if (store.state.isLoggedIn === true) {
            next("/");
          } else {
            next();
          }
        },
      },
      {
        path: "/Members/MemberDetial",
        name: "MemberDetial",
        component: MemberDetial,
        meta: { requiresAuth: true }, //表示登入才可以用此頁面
      },
      {
        path: "/Orders",
        name: "Orders",
        component: Orders,
      },
      {
        path: "/SupportHub",
        name: "SupportHub",
        component: SupportHub,
      },
      {
        path: "/LinePay",
        name: "LinePay",
        component: LinePay,
      },
      {
        path: "/Members/ActiveRegister",
        name: "ActiveRegister",
        component: ActiveRegister,
        beforeEnter: (to, from, next) => {
          if (store.state.isLoggedIn === true) {
            next("/");
          } else {
            next();
          }
        },
      },
      {
        path: "/LinePayConfirmPayment",
        name: "LinePayConfirmPayment",
        component: LinePayConfirmPayment,
      },
      {
        path: "/Members/ResetPassword",
        name: "ResetPassword",
        component: ResetPassword,
        beforeEnter: (to, from, next) => {
          if (store.state.isLoggedIn === true) {
            next("/");
          } else {
            next();
          }
        },
        props: (route) => ({
          memberId: parseInt(route.query.memberId),
          confirmCode: route.query.confirmCode,
        }),
      },
    ],
  },
  {
    path: "/eCommerce",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "",
        name: "eCommerce",
        component: eCommerce,
        props: true,
      },
      {
        path: "/eCommerce/Product/:productId",
        name: "SingleProduct",
        component: SingleProduct,
        props: true,
      },
    ],
  },
  {
    path: "/Cart",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "",
        name: "Cart",
        component: Cart,
        props: (route) => ({
          paymentSuccess: route.query.paymentSuccess === "true",
        }),
      },
    ],
  },
  {
    path: "/GameLounge",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "/GameLounge",
        name: "GameLounge",
        component: () => import("@/views/GameLounge.vue"),
      },
      {
        path: "/GameLounge/Board/:boardId",
        name: "GameLoungeBoard",
        component: () => import("@/views/GameLounge.vue"),
      },
      {
        path: "/GameLounge/:account",
        name: "GameLoungeAccount",
        component: () => import("@/views/GameLounge.vue"),
      },
    ],
  },
  {
    path: "/Test",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      { path: "", name: "Test", component: () => import("@/views/Test.vue") },
    ],
  },
  {
    path: "/RedirectToLogisticsSelection_Test",
    name: "RedirectToLogisticsSelection_Test",
    component: RedirectToLogisticsSelection_Test,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

//判斷是否登入，有登入才可以進入該頁面(beforeEach)
router.beforeEach((to, from, next) => {
  if (to.matched.some((route) => route.meta.requiresAuth)) {
    if (store.state.isLoggedIn === true) {
      next();
    } else {
      next("/Members/Login");
    }
  } else {
    next(); // 不需要登入，直接允許
  }
});

router.afterEach((to, from, next) => {
	window.scrollTo(0, 0);
});
export default router;
