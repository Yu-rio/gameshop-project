<template>
    <div>
        <h2>{{ game.title }}</h2>
        <p><strong>Описание:</strong> {{ game.content }}</p>
        <p><strong>Цена:</strong> {{ game.price }}</p>
        <!-- Добавьте другие детали игры, если необходимо -->
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                game: null
            };
        },
        created() {
            this.getGameDetails();
        },
        methods: {
            async getGameDetails() {
                const gameId = this.$route.params.id;
                try {
                    const response = await axios.get(`/Product/GetProductById?id=${gameId}`);
                    this.game = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке данных игры:', error);
                }
            }
        }
    };
</script>