import './assets/headerStyle.css'
import { createApp } from 'vue';
import App from './App.vue';
import axios from 'axios';
import router from './router';
axios.defaults.baseURL = 'https://localhost:7166/';

const app = createApp(App);
app.config.globalProperties.$http = axios; 
app.use(router);
app.mount('#app');