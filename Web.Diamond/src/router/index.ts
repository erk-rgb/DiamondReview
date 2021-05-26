import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
    {
        path: "/",
        alias: "/",
        name: "",
        component: () => import("../components/Home.vue")
    },
    {
        path: "/Diamonds",
        name: "Diamonds",
        component: () => import("../components/Diamonds.vue")
    },
    {
        path: "/AddItem",
        name: "AddItem",
        component: () => import("../components/AddItem.vue")
    },
    {
        path: "/Details/:id",
        name: "Details",
        component: () => import("../components/Details.vue")
    }
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes
});

export default router;