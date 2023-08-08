// Composables
import { createRouter, createWebHistory } from 'vue-router'
import eCommerce from '../views/eCommerceIndex.vue'
import SingleProduct from '../views/SingleProduct.vue'
import Members from '../views/Members.vue'
import News from '../views/NewsIndex.vue'
import RegisterVue from '@/components/Members/Register.vue'
import Login from '@/components/Members/Login.vue'
import ForgetPwd from '@/components/Members/ForgetPwd.vue'
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
        path: '/eCommerce',
        name: 'eCommerce',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: eCommerce,
      },
      {
        path: '/eCommerce/Product',
        name: 'SingleProduct',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: SingleProduct,
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
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
