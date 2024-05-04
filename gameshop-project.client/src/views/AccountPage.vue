<template>
    <div>
        <h2>Моя учетная запись</h2>
        <p>Имя пользователя: {{ user.firstName }}</p>
        <p>Email: {{ user.email }}</p>
       
    </div>
</template>

<script>
export default {
  data() {
    return {
      user: null
    };
  },
  created() {
    this.getUserData();
  },
  methods: {
    async getUserData() {
         const id = this.$store.getters.getId;
try {
    const response = await this.$axios.get(`/Customer/GetCustomerById?id=${id}`);
        this.user = response.data;
      } catch (error) {
        console.error('Ошибка при получении данных пользователя:', error);
      }
    }
  }
};
</script>