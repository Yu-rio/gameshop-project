<template>
<header>
    
    <nav class="header-nav container flex-container">

        <h1 class="logo"><router-link class="logo-link" to="/home">GameShop</router-link></h1>
        <ul class="header-menu flex-container">
            <li><router-link class="header-menu-link" to="/games">Игры</router-link></li>
            <li><router-link class="header-menu-link" to="/vouchers">Ваучеры</router-link></li>
            <li><router-link class="header-menu-link" to="/account">Личный кабинет</router-link></li>
        </ul>
        <router-link to="/cart"><button class="ghost-button">Корзина</button></router-link>
        <router-link v-if="!isLoggedIn" class="header-menu-link" to="/login">Вход</router-link>
        <span v-if="isLoggedIn"> | <a @click="logout">Выход</a></span>
        <span v-if="isAdmin"><router-link class="header-menu-link" to="/games">Admin</router-link></span>
    </nav>
</header>
</template>

<script setap lang="ts">
    import { RouterLink } from 'vue-router'

  export default {
        computed: {
          isLoggedIn: function () { return this.$store.getters.isLoggedIn },
          isAdmin: function () { return this.$store.getters.isAdmin }
        },
        methods: {
            logout: function () {
                this.$store.dispatch('logout')
                    .then(() => {
                        this.$router.push('/login')
                    })
            }
        },
    }
</script>



<style scoped>
@import './src/assets/headerStyle.css';
</style>