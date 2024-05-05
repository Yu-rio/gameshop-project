<template>
    <div class="register-page">
        <h2>Регистрация</h2>
        <form @submit.prevent="register">
            <div class="form-group">
                <label for="id">ID:</label>
                <input type="text" id="id" v-model="id" required>
            </div>
            <div class="form-group">
                <label for="lastName">Фамилия:</label>
                <input type="text" id="lastName" v-model="lastName" required>
            </div>
            <div class="form-group">
                <label for="firstName">Имя:</label>
                <input type="text" id="firstName" v-model="firstName" required>
            </div>
            <div class="form-group">
                <label for="patronymicName">Отчество:</label>
                <input type="text" id="patronymicName" v-model="patronymicName" required>
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="email" required>
            </div>
            <div class="form-group">
                <label for="passwordHash">Пароль:</label>
                <input type="passwordHash" id="passwordHash" v-model="passwordHash" required>
            </div>
            <div class="form-group">
                <label for="birthday">Дата рождения:</label>
                <input type="date" id="birthday" v-model="birthday" required>
            </div>
            <div class="form-group">
                <label for="address">Адрес:</label>
                <input type="text" id="address" v-model="address" required>
            </div>
            <button type="submit">Зарегистрироваться</button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                id:'',
                firstName: '',
                lastName: '',
                patronymicName: '',
                email: '',
                address: '',
                birthday: '',
                passwordHash: ''

            };
        },
        methods: {
            async register() {
                try {
                    
                    await this.$axios.post('/Customer', {
                        id: this.id,
                        firstName: this.firstName,
                        lastName: this.lastName,
                        patronymicName: this.patronymicName,
                        email: this.email,
                        birthday: this.birthday,
                        address: this.address,
                        passwordHash: this.passwordHash
                    });
                    const date = new Date().toISOString()
                    await this.$axios.post('/Cart', {
                        id: this.id,
                        createdAt: date,
                        customerId: this.id
                    }) 
                    this.$router.push('/login');
                } catch (error) {
                    console.error('Ошибка при регистрации:', error);
                }
            }
        }
    };
</script>

<style scoped>
    .register-page {
        max-width: 400px;
        margin: 0 auto;
    }

    .form-group {
        margin-bottom: 15px;
    }

    label {
        display: block;
    }

    input[type="text"],
    input[type="email"],
    input[type="password"] {
        width: 100%;
        padding: 8px;
        font-size: 16px;
    }

    button {
        padding: 10px 20px;
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
    }
</style>