import axios from "axios";
import { base } from "./Api";

const axiosInstance = axios.create({
    baseURL: base,
    timeout: 1000,
});

export default axiosInstance;