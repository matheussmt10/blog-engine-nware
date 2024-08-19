import axios from 'axios';

const axiosInstance = axios.create({ baseURL: 'http://localhost:7208' });

export default axiosInstance;
