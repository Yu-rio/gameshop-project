<template>
    <div class="account-page">
        <div class="user-info">
            <h2>Личный кабинет</h2>
            <div v-if="user">
                <p><strong>Имя:</strong> {{ user.firstName }}</p>
                <p><strong>Фамилия:</strong> {{ user.lastName }}</p>
                <p><strong>Фамилия:</strong> {{ user.patronymicName }}</p>
                <p><strong>Email:</strong> {{ user.email }}</p>
                <p><strong>Дата рождения:</strong> {{ user.birthday }}</p>
                <p><strong>Адрес:</strong> {{ user.address }}</p>
            </div>
        </div>
        <div class="orders">
            <h3>Мои заказы</h3>
            <div v-if="orders.length === 0">
                <p>У вас пока нет заказов.</p>
            </div>
            <div v-else>
                <div v-for="order in orders" :key="order.id" class="order-item">
                    <p><strong>Номер заказа:</strong> {{ order.orderId }}</p>
                    <p><strong>Дата:</strong> {{ order.orederDate }}</p>
                    <p><strong>Сумма:</strong> {{ order.sum }} руб.</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
        user: null,
        orders: []
    };
  },
  created() {
      this.getUserData();
      this.fetchOrders();
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
      },
      async fetchOrders() {
          try {
              const customerId = this.$store.getters.getId;
              const response = await this.$axios.get(`/Order/GetOrdersByCustomerId?customerId=${customerId}`);
              this.orders = response.data;
          } catch (error) {
              console.error('Ошибка при загрузке заказов:', error);
          }
      },
  }
};
</script>

<style scoped>
    .account-page {
        display: flex;
         justify-content: space-between;
         margin: 20px;
    }

    .user-info {
        flex: 1;
    }

    .orders {
        flex: 1;
    }

    .order-item {
        border-bottom: 1px solid #ccc;
        padding: 10px 0;
    }

    button {
        padding: 8px 16px;
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
    }
</style>