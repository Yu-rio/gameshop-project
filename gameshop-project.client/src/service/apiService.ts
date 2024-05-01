import axios from 'axios'
import { API_URL } from "./apiConfig"

const apiClient = axios.create({
    baseURL: API_URL
})

export default apiClient