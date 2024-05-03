import './assets/headerStyle.css'
import { createApp } from 'vue';
import App from './App.vue';
import axios from 'axios';
import router from './router';

axios.defaults.baseURL = 'https://localhost:7166/api';

const app = createApp(App);
app.config.globalProperties.$https = axios; 
app.use(router);
app.mount('#app');