<template>
  <button class="cart-button" @click="handleClick">
    <img src="@/components/icons/cart-icon.svg" alt="Корзина">
    <span>Корзина</span>
  </button>
</template>

<script>
export default {
  methods: {
    handleClick() {
      // Логика для обработки нажатия на кнопку корзины
    }
  }
}
</script>

<style scoped>
    .cart-button {
        display: flex;
        align-items: center;
        background-color: transparent;
        border: none;
        cursor: pointer;
        /* Другие стили для кнопки корзины */
    }

        .cart-button span {
            margin-left: 8px;
        }
</style>