<template>
<header>
    
    <nav class="header-nav container flex-container">

            <h1 class="logo"><RouterLink class="logo-link" to="/home">GameShop</RouterLink></h1>
            <ul class="header-menu flex-container">
                <li><RouterLink class="header-menu-link" to="/games">Игры</RouterLink></li>
                <li><RouterLink class="header-menu-link" to="/vouchers">Ваучеры</RouterLink></li>
                <li><RouterLink class="header-menu-link" to="/login">Личный кабинет</RouterLink></li>
            </ul>

        <button class="ghost-button">Корзина</button>
    </nav>
</header>
</template>

<script setap lang="ts">
    import { RouterLink, RouterView } from 'vue-router'
</script>
<style scoped>
@import './src/assets/headerStyle.css';
</style>