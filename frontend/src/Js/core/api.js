import axios from 'axios';
import {API_BASE_URL} from "./constants"

const api = axios.create({
  baseURL : API_BASE_URL,
  withCredentials: true
});

export function setupInterceptors(navigate,logoutUser) {
  api.interceptors.response.use(
    res => res,
    err => {
      if (err.response && err.response.status === 401) {
        logoutUser();
      }
      return Promise.reject(err);
    }
  );
}

export default api;
