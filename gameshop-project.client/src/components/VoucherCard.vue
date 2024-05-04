<template>
    <div class="voucher-card">
        <br>
        <router-link :to="{ name: 'VoucherDetails', params: { id: product.productId } }">
            <h3 class="center">  {{ product.title }}</h3>
        </router-link>
        <p class="center">   Кол-во: {{ product.quantity }}</p>
        <p class="center">   Цена: {{ product.price }}</p>
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
    .center{
        text-align:center;
    }
</style>