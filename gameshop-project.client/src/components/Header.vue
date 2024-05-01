<template>
<header>
  <nav class="header-nav container flex-container">
    <h1 class="logo"><router-link class="logo-link" to="/home">GameShop</router-link></h1>
    <ul class="header-menu flex-container">
      <li><router-link class="header-menu-link" to="/games">Игры</router-link></li>
      <li><a class="header-menu-link" href="">Ваучеры</a></li>
      <li><a class="header-menu-link" href="">Личный кабинет</a></li>
    </ul>
    <button class="ghost-button">Корзина</button>
  </nav>
</header>
</template>

<style scoped>
@import './src/assets/headerStyle.css';
</style>