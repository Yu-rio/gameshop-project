<template>
    <div class="admin-page">
        <h2>���������������� ������</h2>
        <h3>�������� �����</h3>
        <form @submit.prevent="addProduct">
            <div class="form-group">
                <label for="productName">�������� ������:</label>
                <input type="text" id="productName" v-model="newProduct.name" required>
            </div>
            <div class="form-group">
                <label for="price">����:</label>
                <input type="number" id="price" v-model.number="newProduct.price" required>
            </div>
            <div class="form-group">
                <label for="category">���������:</label>
                <select id="category" v-model="newProduct.category" required>
                    <option value="C01">����</option>
                    <option value="C02">�������</option>
                    
                </select>
            </div>
            <button type="submit">�������� �����</button>
        </form>
        <h3>������������� ������</h3>
        <div v-for="product in products" :key="product.id" class="product">
            <input type="text" v-model="product.name">
            <input type="number" v-model.number="product.price">
            <select v-model="product.category">
                <option value="C01">����</option>
                <option value="C02">�������</option>
                
            </select>
            <button @click="updateProduct(product)">���������</button>
            <button @click="deleteProduct(product.id)">�������</button>
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
                    console.error('������ ��� �������� �������:', error);
                }
            },
            async addProduct() {
                try {
                    
                    await this.$axios.post('/Product/NewProduct', this.newProduct);
                   
                    this.fetchProducts();
                    
                    this.newProduct = { name: '', price: 0, category: 'C01' };
                } catch (error) {
                    console.error('������ ��� ���������� ������:', error);
                }
            },
            async updateProduct(product) {
                try {
                    
                    await this.$axios.put('/Product/UpdateProduct', product);
                    
                    this.fetchProducts();
                } catch (error) {
                    console.error('������ ��� ���������� ������:', error);
                }
            },
            async deleteProduct(productId) {
                try {
                    
                    await this.$axios.delete(`/Product/DeleteProduct/${productId}`);
                    
                    this.fetchProducts();
                } catch (error) {
                    console.error('������ ��� �������� ������:', error);
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