<template>
    <div>
        <h2>Детали игры</h2>
        <p>Название: {{ game.title }}</p>
        <p>Жанр: {{ game.genre }}</p>
        <!-- Дополнительная информация о игре -->
    </div>
</template>

<script>
export default {
  data() {
    return {
      game: null
    };
  },
  mounted() {
    this.getGameData();
  },
  methods: {
    async getGameData() {
      try {
        const response = await this.$http.get('/api/Game/GetGameDetails?id=123'); // Замените на нужный ID игры
        this.game = response.data;
      } catch (error) {
        console.error('Ошибка при получении данных об игре:', error);
      }
    }
  }
};
</script>