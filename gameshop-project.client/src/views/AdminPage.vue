<template>
    <div class="admin-page">
        <h2>Административная панель</h2>
        <h3>Добавить товар</h3>
        <form @submit.prevent="addProduct">
            <div class="form-group">
                <label for="productName">Название товара:</label>
                <input type="text" id="productName" v-model="newProduct.name" required>
            </div>
            <div class="form-group">
                <label for="price">Цена:</label>
                <input type="number" id="price" v-model.number="newProduct.price" required>
            </div>
            <div class="form-group">
                <label for="category">Категория:</label>
                <select id="category" v-model="newProduct.category" required>
                    <option value="C01">Игры</option>
                    <option value="C02">Ваучеры</option>
                    
                </select>
            </div>
            <button type="submit">Добавить товар</button>
        </form>
        <h3>Редактировать товары</h3>
        <div v-for="product in products" :key="product.id" class="product">
            <input type="text" v-model="product.name">
            <input type="number" v-model.number="product.price">
            <select v-model="product.category">
                <option value="C01">Игры</option>
                <option value="C02">Ваучеры</option>
                
            </select>
            <button @click="updateProduct(product)">Сохранить</button>
            <button @click="deleteProduct(product.id)">Удалить</button>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                newProduct: {
                    name: '',
                    price: 0,
                    category: 'C01'
                },
                products: [] 
            };
        },
        created() {
            this.fetchProducts();
        },
        methods: {
            async fetchProducts() {
                try {
                    
                    const response = await this.$axios.get('/Product/GetProductsByCategory', {
                        params: { categoryId: 'C01' } 
                    });
                    this.products = response.data;
                } catch (error) {
                    console.error('Ошибка при загрузке товаров:', error);
                }
            },
            async addProduct() {
                try {
                    
                    await this.$axios.post('/Product/NewProduct', this.newProduct);
                   
                    this.fetchProducts();
                    
                    this.newProduct = { name: '', price: 0, category: 'C01' };
                } catch (error) {
                    console.error('Ошибка при добавлении товара:', error);
                }
            },
            async updateProduct(product) {
                try {
                    
                    await this.$axios.put('/Product/UpdateProduct', product);
                    
                    this.fetchProducts();
                } catch (error) {
                    console.error('Ошибка при обновлении товара:', error);
                }
            },
            async deleteProduct(productId) {
                try {
                    
                    await this.$axios.delete(`/Product/DeleteProduct/${productId}`);
                    
                    this.fetchProducts();
                } catch (error) {
                    console.error('Ошибка при удалении товара:', error);
                }
            }
        }
    };
</script>

<style scoped>
    .admin-page {
        max-width: 800px;
        margin: 0 auto;
    }

    .product {
        margin-bottom: 10px;
    }

    input[type="text"],
    input[type="number"],
    select {
        margin-right: 10px;
    }

    button {
        padding: 5px 10px;
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
    }
</style>