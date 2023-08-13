// Composables
import { createRouter, createWebHistory } from 'vue-router'
import eCommerce from '@/views/eCommerce.vue'
import SingleProduct from '@/views/SingleProduct.vue'
import Members from '../views/Members.vue'
import News from '../views/NewsIndex.vue'
import RegisterVue from '@/components/Members/Register.vue'
import Login from '@/components/Members/Login.vue'
import ForgetPwd from '@/components/Members/ForgetPwd.vue'
import Orders from '../views/Orders.vue'
import OrderDetails from '../views/OrderDetails.vue'
import OrderItemReturn from '../views/OrderItemReturn.vue'
import SupportHub from '../views/SupportHub.vue'
import LinePay from '../views/LinePay.vue'
import Cart from '@/views/Cart.vue'

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
    ],
  },{
    path: "/eCommerce",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "",
        name: "eCommerce",
        component: eCommerce,
        props:true
      },
      {
        path: '/eCommerce/Product/:productId',
        name: 'SingleProduct',
        component: SingleProduct,
        props: true
      },
    ],
  },{
    path: "/Cart",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "",
        name: "Cart",
        component: Cart,
        props:true
      },
    ],
  },
  {
    path: "/GameLounge",
    component: () => import("@/layouts/default/Default.vue"),
    children: [
      {
        path: "",
        name: "GameLounge",
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
          import(/* webpackChunkName: "home" */ "@/views/GameLounge.vue"),
      },
      {
        path: '/Members',
        name: 'Members',
        component: Members,
      },
      {
        path: '/News',
        name: 'News',
        component: News,
      },
      {
        path: '/Members/Register',
        name: 'Register',
        component: RegisterVue,
      },
      {
        path: '/Members/Login',
        name: 'Login',
        component: Login,
      },
      {
        path: '/Members/ForgetPwd',
        name: 'ForgetPwd',
        component: ForgetPwd,
      },
      {
        path: '/Orders',
        name: 'Orders',
        component: Orders
      },
      {
        path: '/Orders/:id',
        name: 'OrderDetails',
        component: OrderDetails
      },
      {
        path: '/OrderItemReturn/:id/:gameChiName',
        name: 'OrderItemReturn',
        component: OrderItemReturn
      },
      {
        path: '/SupportHub',
        name: 'SupportHub',
        component: SupportHub
      },
      {
        path: '/LinePay',
        name: 'LinePay',
        component: LinePay
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
