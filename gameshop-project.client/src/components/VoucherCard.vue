<template>
    <div class="voucher-card">
        <br>
        <router-link :to="{ name: 'VoucherDetails', params: { id: product.productId } }">
            <h3>{{ product.title }}</h3>
        </router-link>
        <p>Кол-во: {{ product.quantity }}</p>
        <p>{{ product.price }} руб.</p>
        <span v-if="isLoggedIn">
            <span v-if="!cartItem">
                <button @click="addToCart(product.productId)">Добавить в корзину</button>
            </span>
            <span v-if="cartItem" class="horizontal-controls">
                <button @click="incrementQuantity(product.productId)">+</button>
                <p>{{cartItem.quantity}}</p>
                <button @click="decrementQuantity(product.productId)">-</button>
            </span>
        </span>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                cartItem: null
            };
        },
        created() {
            this.fetchCartItems();
        },
        props: {
            product: {
                type: Object,
                required: true
            }
        },

        computed: {
            isLoggedIn() {
                return this.$store.getters.isLoggedIn;
            },
            async inCart() {
                try {
                    const response = await this.$axios.get('/CartItem/GetCartItemByProductIdAndCartId',
                        {
                            params: {
                                productId: this.product.productId,
                                cartId: this.$store.getters.getId
                            }
                        });
                    return response.data == null;
                } catch (error) {
                    console.error('Ошибка при проверке товара в корзине:', error);
                    return false;
                }
            },
        },
        methods: {
            async fetchCartItems() {

                try {
                    const response = await this.$axios.get('/CartItem/GetCartItemByProductIdAndCartId',
                        {
                            params: {
                                productId: this.product.productId,
                                cartId: this.$store.getters.getId
                            }
                        });
                    this.cartItem = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке товара:', error);
                }
            },

            async addToCart(productId) {
                this.$axios.post('/CartItem', {
                    productId: productId,
                    cartId: this.$store.getters.getId,
                    price: this.product.price,
                    quantity: 1
                }).then(response => {
                    console.log('Товар добавлен в корзину:', response.data);
                    this.fetchCartItems();
                }).catch(error => {
                    console.error('Ошибка при добавлении товара в корзину:', error);
                });
            },
            incrementQuantity(productId) {
                if (this.cartItem.quantity < this.product.quantity) {
                    this.updateCartItemQuantity(productId, this.cartItem.quantity + 1);
                }
            },
            decrementQuantity(productId) {
                if (this.cartItem.quantity > -1) {

                    this.updateCartItemQuantity(productId, this.cartItem.quantity - 1);
                }
            },
            async updateCartItemQuantity(productId, quantity) {
                if (quantity <= 0) {
                    try {
                        await this.$axios.delete('/CartItem', {
                            params: {
                                productId: this.product.productId,
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
                        productId: productId,
                        cartId: this.$store.getters.getId,
                        price: this.product.price,
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
    .voucher-card {
        border: 1px solid #ccc;
        padding: 10px;
        margin: 10px;
        width: 20em;
        text-align: center;
        align-items: center;
    }

    button {
        padding: 8px 16px;
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
        align-items: center;
    }

    .horizontal-controls {
        display: flex;
        justify-content: center;
        align-items: center;
    }

        .horizontal-controls button {
            margin: 0 10px;
        }
</style>