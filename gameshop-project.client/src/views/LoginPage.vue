<template>
    <div class="login-page">
        <h2>Вход</h2>
        <br>
        <form @submit.prevent="login">
            <div class="form-group">
                <label for="email">Email:</label>
                <input type="text" id="email" v-model="email" required>
            </div>
            <div class="form-group">
                <label for="password">Пароль:</label>
                <input type="password" id="password" v-model="password" required>
            </div>
            <div class="center">
            <button class="login_button" type="submit">Войти</button>
            </div>
        </form>
        <br><br>
        <div class="center">
            <p>Еще не зарегестрирован?<br>
            ||<br>
            \/</p>
        <button class="type-button"><router-link to="/register">Регистрация</router-link></button>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                email: '',
                password: ''
            };
        },
        methods: {
            async login() {
                try {
                    // Отправляем запрос на сервер для аутентификации
                    const response = await this.$axios.post('/Login', {
                        email: this.email,
                        password: this.password
                    });

                    this.$store.dispatch('login', { token: response.data.token, id: response.data.id });
                    this.$router.push('/'); 
                } catch (error) {
                    console.error('Ошибка при входе:', error);
                }
            }
        }
    };
</script>

<style scoped>
    .login-page {
        max-width: 400px;
        margin: 0 auto;
    }

    .form-group {
        margin-bottom: 15px;
    }

    label {
        display: flex;
    }

    input[type="text"],
    input[type="password"] {
        width: 100%;
        padding: 8px;
        font-size: 16px;
    }

    .login_button {
        padding: 10px 20px;
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
    }
    .center{
        text-align:center;
    }
</style>