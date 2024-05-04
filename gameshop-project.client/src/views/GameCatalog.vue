<template>
    <div>
        <h2 class="center">Список игр</h2>
        <game-card v-for="product in products" :key="product.productId" :product="product" />
    </div>
</template>

<script>
    import axios from 'axios';
    import GameCard from '@/components/GameCard.vue';

    export default {
        components: {
            GameCard
        },
        data() {
            return {
                products: []
            };
        },
        mounted() {
            this.getGames();
        },
        methods: {
            async getGames() {
                try {
                    const response = await axios.get('/Product/GetProductsByCategory?categoryId=C01');
                    this.products = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке игр:', error);
                }
            }
        }
    };
</script>

<style>
    .center {
        text-align: center;
    }
</style>