import { createRouter, createWebHistory } from 'vue-router'

import HomePage from '@/views/HomePage.vue';
import GameCatalog from '../views/GameCatalog.vue';
import VoucherCatalog from '../views/VoucherCatalog.vue';
import GameDetails from '../views/GameDetails.vue';
import VoucherDetails from '../views/VoucherDetails.vue';
import LoginPage from '../views/LoginPage.vue';
import RegisterPage from '../views/RegisterPage.vue';
import AccountPage from '../views/AccountPage.vue';

const routes = [
    { path: '/home', name:'Home', component: HomePage },
    { path: '/games', component: GameCatalog },
    { path: '/vouchers', component: VoucherCatalog },
    { path: '/games/:id', component: GameDetails },
    { path: '/vouchers/:id', component: VoucherDetails },
    { path: '/login', component: LoginPage },
    { path: '/register', component: RegisterPage },
    { path: '/account', component: AccountPage, meta: { requiresAuth: true } }
];

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router