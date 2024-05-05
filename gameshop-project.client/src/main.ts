import './assets/headerStyle.css'
import { createApp } from 'vue'
import App from './App.vue'
import axios from 'axios'
import router from './router'
import { createStore } from 'vuex'

axios.defaults.baseURL = 'https://localhost:7166/api'

export const store = createStore({
    state: {
        isAuthenticated: false,
        token: null,
        id: null
    },
    mutations: {
        setAuthentication(state, payload) {
            state.isAuthenticated = payload.isAuthenticated;
            state.token = payload.token;
            state.id = payload.id
        }
    },
    actions: {
        login({ commit }, { token, id }) {
            localStorage.setItem('token', token);
            commit('setAuthentication', { isAuthenticated: true, token, id });
        },
        logout({ commit }) {
            localStorage.removeItem('token');
            commit('setAuthentication', { isAuthenticated: false, token: null , id: null});
        }
    },
    getters: {
        isLoggedIn: state => !!state.token,
        authStatus: state => state.isAuthenticated,
        getId: state => state.id,
        isAdmin: state=> state.id=="CM000000"
    }
})

const app = createApp(App)

app.config.globalProperties.$https = axios
app.config.globalProperties.$axios = axios

localStorage.removeItem('token')


app.use(store)
app.use(router)
app.mount('#app')