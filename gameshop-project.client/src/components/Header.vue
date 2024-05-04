<template>
<header>
    
    <nav class="header-nav container flex-container">

        <h1 class="logo"><RouterLink class="logo-link" to="/home">GameShop</RouterLink></h1>
        <ul class="header-menu flex-container">
            <li><RouterLink class="header-menu-link" to="/games">Игры</RouterLink></li>
            <li><RouterLink class="header-menu-link" to="/vouchers">Ваучеры</RouterLink></li>
            <li><RouterLink class="header-menu-link" to="/account">Личный кабинет</RouterLink></li>
        </ul>
        <button class="ghost-button">Корзина</button>
        <router-link v-if="!isLoggedIn" class="header-menu-link" to="/login">Вход</router-link>
        <span v-if="isLoggedIn"> | <a @click="logout">Выход</a></span>
    </nav>
</header>
</template>

<script setap lang="ts">
    import { RouterLink, RouterView } from 'vue-router'

  export default {
        computed: {
            isLoggedIn: function () { return this.$store.getters.isLoggedIn }
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