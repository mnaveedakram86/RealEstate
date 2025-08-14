import api from "../api"
import { startTokenTimer, stopTokenTimer } from "./token"

export async function register(user) {
  return await api.post(`auth/register`, user);
}

export async function login(credentials) {
  const res = await api.post(`auth/login`, credentials);
  stopTokenTimer();
  startTokenTimer(res.data.accessTokenExpiry);
  return res;
}

export async function refresh() {
  const res = await api.post("/auth/refresh");
  stopTokenTimer();
  startTokenTimer(res.data.accessTokenExpiry);
  return res;
}

export async function logout() {
  await api.post("/auth/logout");
  stopTokenTimer();
}