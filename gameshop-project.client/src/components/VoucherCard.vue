<template>
    <div class="voucher-card">
        <router-link :to="{ name: 'VoucherDetails', params: { id: product.productId } }">
            <h3>{{ product.title }}</h3>
        </router-link>
        <p>Кол-во: {{ product.quantity }}</p>
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