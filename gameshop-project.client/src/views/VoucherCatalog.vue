<template>
    <div>
        <h2>Каталог ваучеров</h2>
        <ul>
            <li v-for="voucher in vouchers" :key="voucher.id">
                {{ voucher.name }}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
  data() {
    return {
      vouchers: []
    };
  },
  mounted() {
    this.getVouchers();
  },
  methods: {
    async getVouchers() {
      try {
        const response = await this.$http.get('/api/Voucher/GetAllVouchers');
        this.vouchers = response.data;
      } catch (error) {
        console.error('Ошибка при загрузке ваучеров:', error);
      }
    }
  }
};
</script>