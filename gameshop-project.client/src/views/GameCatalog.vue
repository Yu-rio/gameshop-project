<template>
    <Header/>
    <main>
    <div>
        <h2>Список игр</h2>
        <ul>
            <li v-for="product in products" :key="product.productId">
                {{ product.Title }}
            </li>
        </ul>
    </div>
    </main>
</template>

<script>
    import axios from 'axios';

    export default {
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
                    const response = await axios.get('https://localhost:7166/api/Product/GetProductsByCategory?categoryId=C01');
                    this.products = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке игр:', error);
                }
            }
        }
    };
</script>