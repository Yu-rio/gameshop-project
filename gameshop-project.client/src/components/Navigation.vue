<template>
  <nav class="navigation">
    <ul>
      <li><a href="#">Игры</a></li>
      <li><a href="#">Ваучеры</a></li>
      <li><a href="#">Личный кабинет</a></li>
    </ul>
  </nav>
</template>

<script>
export default {
  // Логика компонента, если необходимо
}
</script>

<style scoped>
.navigation {
  /* Стили для панели навигации */
}
.navigation ul {
  list-style: none;
  padding: 0;
}
.navigation li {
  display: inline;
  margin-right: 20px;
}
.navigation li:last-child {
  margin-right: 0;
}
.navigation a {
  text-decoration: none;
  color: #333;
  font-weight: bold;
}
.navigation a:hover {
  color: #000; /* Цвет при наведении */
}
</style>