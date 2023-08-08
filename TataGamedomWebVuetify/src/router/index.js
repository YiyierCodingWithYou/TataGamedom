// Composables
import { createRouter, createWebHistory } from 'vue-router'
import eCommerce from '../views/eCommerceIndex.vue'
import SingleProduct from '../views/SingleProduct.vue'
import Members from '../views/Members.vue'
import News from '../views/NewsIndex.vue'
import LoginVue from '@/components/Members/Login.vue'
import RegisterVue from '@/components/Members/Register.vue'
import Orders from '../views/Orders.vue'
import OrderDetails from '../views/OrderDetails.vue'
import OrderItemReturn from '../views/OrderItemReturn.vue'
import SupportHub from '../views/SupportHub.vue'



const routes = [
  {
    path: '/',
    component: () => import('@/layouts/default/Default.vue'),
    children: [
      {
        path: '',
        name: 'Home',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "home" */ '@/views/Home.vue'),
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
        path: '/Members/Login',
        name: 'Login',
        component: LoginVue,
      },
      {
        path: '/Members/Register',
        name: 'Register',
        component: RegisterVue,
      },
      {
        path: '/Orders',
        name: 'Orders',
        component: Orders
      },
      {
        path: '/Orders/:id',
        name: 'OrderDetails',
        component: OrderDetails,
        // children: [
        //   {
        //     path: 'OrderItemReturn', name: 'OrderItemReturn', component: OrderItemReturn
        //   }
        // ]
      },
      {
        path: '/OrderItemReturn/:id/:gameChiName',  //id
        name: 'OrderItemReturn',
        component: OrderItemReturn
      },
      {
        path: '/SupportHub',
        name: 'SupportHub',
        component: SupportHub
      },
    ],
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
