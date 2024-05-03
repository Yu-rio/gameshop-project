<template>
    <div class="game-card">
        <router-link :to="{ name: 'GameDetails', params: { id: product.productId } }">
            <h3>{{ product.title }}</h3>
        </router-link>
        <p>{{ product.genre.genreName }}</p>
        <p>Цена: {{ product.price }}</p>
        
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
</style>