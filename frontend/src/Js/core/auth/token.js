import {refresh} from "./auth"

let refreshTimer;

export function startTokenTimer(expiryTime) {
  const now = Date.now();
  const expiry = new Date(expiryTime).getTime();
  
  // Refresh 1 min before expiry
  const refreshTime = expiry - now - 60_000;

  if (refreshTime > 0) {
    refreshTimer = setTimeout(async () => {
      await refresh();
    }, refreshTime);
  }
}

export function stopTokenTimer() {
  if (refreshTimer) clearTimeout(refreshTimer);
}