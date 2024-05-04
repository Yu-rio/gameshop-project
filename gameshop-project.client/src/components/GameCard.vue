<template>
    <div class="game-card">
        <br>
        <router-link :to="{ name: 'GameDetails', params: { id: product.productId } }">
            <h3 class="center">{{ product.title }}</h3>
        </router-link>
        <p class="center">{{ product.genre.genreName }}</p>
        <p class="center">Цена: {{ product.price }}</p>
        
    </div>
</template>

<script>
export default {
  props: {
    product: {
      type: Object,
      required: true
    }
  }
};
</script>

<style scoped>
    .product-card {
        border: 1px solid #ccc;
        padding: 10px;
        margin-bottom: 10px;
        cursor: pointer; /* Добавим стиль, чтобы курсор менялся при наведении */
    }
    .center {
        text-align: center;
    }
</style>