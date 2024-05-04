import { createRouter, createWebHistory } from 'vue-router'

import HomePage from '@/views/HomePage.vue';
import GameCatalog from '@/views/GameCatalog.vue';
import VoucherCatalog from '@/views/VoucherCatalog.vue';
import GameDetails from '@/views/GameDetails.vue';
import VoucherDetails from '@/views/VoucherDetails.vue';
import LoginPage from '@/views/LoginPage.vue';
import RegisterPage from '@/views/RegisterPage.vue';
import AccountPage from '@/views/AccountPage.vue';

const routes = [
    { path: '/home', name:'Home', component: HomePage },
    { path: '/games', component: GameCatalog },
    { path: '/vouchers', component: VoucherCatalog },
    { path: '/games/:id', component: GameDetails, name: 'GameDetails' },
    { path: '/vouchers/:id', component: VoucherDetails, name: 'VoucherDetails' },
    { path: '/login', component: LoginPage },
    { path: '/register', component: RegisterPage },
    { path: '/account', component: AccountPage, meta: { requiresAuth: true } }
];
``


const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes
})

router.beforeEach((to, from, next) => {
    if (to.meta.requiresAuth) {
        if (localStorage.getItem('token')) {
            // User is authenticated, proceed to the route
            next();
        } else {
            // User is not authenticated, redirect to login
            next('/login');
        }
    } else {
        // Non-protected route, allow access
       next()
    }
});

export default router