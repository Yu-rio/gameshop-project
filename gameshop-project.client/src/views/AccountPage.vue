<template>
    <div>
        <h2>Моя учетная запись</h2>
        <p>Имя пользователя: {{ user.FirstName }}</p>
        <p>Email: {{ user.Email }}</p>
       
    </div>
</template>

<script>
export default {
  data() {
    return {
      user: null
    };
  },
  mounted() {
    this.getUserData();
  },
  methods: {
    async getUserData() {
      try {
        const response = await this.$http.get('/api/User/GetUserData');
        this.user = response.data;
      } catch (error) {
        console.error('Ошибка при получении данных пользователя:', error);
      }
    }
  }
};
</script>