<template>
    <div class="catalog-page">
        <h2 class="center">Список ваучеров</h2>
        <br>
        <div class="product-list">
            <voucher-card v-for="product in products" :key="product.productId" :product="product" />
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import VoucherCard from '@/components/VoucherCard.vue';

    export default {
        components: {
            VoucherCard
        },
        data() {
            return {
                products: []
            };
        },
        mounted() {
            this.getVouchers();
        },
        methods: {
            async getVouchers() {
                try {
                    const response = await axios.get('/Product/GetProductsByCategory?categoryId=C02');
                    this.products = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке ваучеров:', error);
                }
            }
        }
    };
</script>

<style scoped>
    .catalog-page {
        max-width: 1000px;
        margin: 0 auto;
    }
    .product-list {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
    }
    .center {
        text-align: center;
    }
 </style>