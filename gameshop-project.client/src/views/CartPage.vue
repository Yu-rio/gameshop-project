<template>
    <div class="cart-page">
        <h2>Корзина</h2>
        <div v-if="cartItems.length === 0">
            <p>Ваша корзина пуста.</p>
        </div>
        <div v-else>
            <div v-for="item in cartItems" :key="item.productId" class="cart-item">
                <p>{{ item.product.title }}</p>
                <p>{{ item.price }} руб.</p>
                <p>Количество: {{ item.quantity }}</p>
                <button @click="incrementQuantity(item)">+</button>
                <button @click="decrementQuantity(item)">-</button>
                <button @click="removeItem(item.productId)">Удалить</button>
            </div>
            <p>Общая стоимость: {{ total }} руб.</p>
            <button @click="buy">Оформить заказ</button>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                cartItems: []
            };
        },
        created() {
            this.fetchCartItems();
        },
        computed: {
            total() {
                return this.cartItems.reduce((acc, item) => acc + item.price * item.quantity, 0);
            }
        },
        methods: {
            async fetchCartItems() {
                try {
                    const id = this.$store.getters.getId;
                    const response = await this.$axios.get('/CartItem/GetCartItemsByCartId', {
                        params: { cartId: id}
                    });
                    this.cartItems = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке товаров в корзине:', error);
                }
            },
            async removeItem(itemId) {
                try {
                    const id = this.$store.getters.getId
                    await this.$axios.delete('/CartItem', {
                        params: {
                            productId: itemId,
                            cartId: id,
                        }
                    });
                    this.fetchCartItems();
                } catch (error) {
                    console.error('Ошибка при удалении товара из корзины:', error);
                }
            },
            async buy() {
                try {
                    //Логика перемещения в заказы
                    this.$router.push('/orders');
                } catch (error) {
                    console.error('Ошибка при оформлении заказа:', error);
                }
            },
            incrementQuantity(item) {
                if (item.quantity < item.product.quantity) {
                    this.updateCartItemQuantity(item, item.quantity + 1);
                }
            },
            decrementQuantity(item) {
                if (item.quantity > -1) {

                    this.updateCartItemQuantity(item, item.quantity - 1);
                }
            },
            async updateCartItemQuantity(item, quantity) {
                if (quantity <= 0) {
                    try {
                        await this.$axios.delete('/CartItem', {
                            params: {
                                productId: item.productId,
                                cartId: this.$store.getters.getId
                            }
                        })
                        this.fetchCartItems();
                    } catch (error) {
                        console.error('Ошибка при удалении товара:', error);
                    }
                }
                else {
                    await this.$axios.put('/CartItem', {
                        productId: item.productId,
                        cartId: this.$store.getters.getId,
                        price: item.product.price,
                        quantity: quantity
                    }).then(response => {
                        this.fetchCartItems();
                        console.log('Количество товара обновлено:', response.data);
                    }).catch(error => {
                        console.error('Ошибка при обновлении количества товара:', error);
                    });
                }
            }
        }
    };
</script>

<style scoped>
    .cart-page {
        max-width: 800px;
        margin: 0 auto;
    }

    .cart-item {
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