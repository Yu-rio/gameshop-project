<template>
    <div class="login-page">
        <h2>Вход</h2>
        <form @submit.prevent="login">
            <div class="form-group">
                <label for="email">Email:</label>
                <input type="text" id="email" v-model="email" required>
            </div>
            <div class="form-group">
                <label for="password">Пароль:</label>
                <input type="password" id="password" v-model="password" required>
            </div>
            <button type="submit">Войти</button>
        </form>
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
        display: block;
    }

    input[type="text"],
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