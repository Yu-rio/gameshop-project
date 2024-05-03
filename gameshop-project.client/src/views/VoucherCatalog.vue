<template>
    <div>
        <h2>Список ваучеров</h2>
        <voucher-card v-for="product in products" :key="product.productId" :product="product" />
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