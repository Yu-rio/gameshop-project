<template>
    <div class="catalog-page">
        <h2 class="center">Список игр</h2>
        <br>
        <div class="product-list">
            <game-card v-for="product in products" :key="product.productId" :product="product" />
        </div>
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