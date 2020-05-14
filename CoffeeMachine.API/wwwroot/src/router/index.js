import Vue from 'vue'
import Router from 'vue-router'
import Home from "../components/Home";
import Badges from "../components/Badges";
import Orders from "../components/Orders";

Vue.use(Router)

const router = new Router({
    mode: 'hash',
    base: process.env.BASE_URL,
    routes: [
    {
        path: '/',
        name: 'home',
        component: Home
    },
    {
        path: '/badges',
        name: 'badges',
        component : Badges

    },
    {
        path: '/badges/:id/orders',
        name: 'orders',
        component: Orders

    }

    ],

})


export default router;