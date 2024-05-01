<template>
    <div>
        <h2>Детали ваучера</h2>
        <p>Название: {{ voucher.name }}</p>
        <p>Скидка: {{ voucher.discount }}</p>
        <!-- Дополнительная информация о ваучере -->
    </div>
</template>

<script>
export default {
  data() {
    return {
      voucher: null
    };
  },
  mounted() {
    this.getVoucherData();
  },
  methods: {
    async getVoucherData() {
      try {
        const response = await this.$http.get('/api/Voucher/GetVoucherDetails?id=123'); // Замените на нужный ID ваучера
        this.voucher = response.data;
      } catch (error) {
        console.error('Ошибка при загрузке данных о ваучере:', error);
      }
    }
  }
};
</script>