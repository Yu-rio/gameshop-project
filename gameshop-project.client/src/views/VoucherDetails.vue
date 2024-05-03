<template>
    <div>
        <h2>{{ voucher.title }}</h2>
        <p><strong>Описание:</strong> {{ voucher.content }}</p>
        <p><strong>Цена:</strong> {{ voucher.price }}</p>
        <!-- Добавьте другие детали игры, если необходимо -->
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                voucher: null
            };
        },
        created() {
            this.getVoucherDetails();
        },
        methods: {
            async getVoucherDetails() {
                const voucherId = this.$route.params.id;
                try {
                    const response = await axios.get(`/Product/GetProductById?id=${voucherId}`);
                    this.voucher = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке данных ваучера:', error);
                }
            }
        }
    };
</script>