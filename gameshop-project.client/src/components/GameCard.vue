<template>
    <div class="product-card">
        <img :src="require(`./images/GA0003.jpeg`)" alt="Product Image">
        <h3>{{ product.title }}</h3>
        <p>Кол-во: {{ product.quantity }}</p>
        <p>{{ product.price }} руб.</p>
        <button @click="addToCart">Добавить в корзину</button>
    </div>
</template>

<script>
    export default {
        props: {
            product: {
                type: Object,
                required: true
            }
        },
        methods: {
            addToCart() {
                this.$emit('add-to-cart', this.product);
            },
            getImageUrl(productId) {
                try {
                    return `./images/${productId}.jpeg`;
                }
                catch (error) {console.error(error) }
        }
    }
    };
</script>

<style scoped>
    .product-card {
        border: 1px solid #ccc;
        padding: 10px;
        margin: 10px;
        width: 100em;
        text-align: center;
    }

    img {
        max-width: 100%;
    }

    button {
        padding: 8px 16px;
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
    }
</style>