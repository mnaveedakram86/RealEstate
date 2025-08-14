import React, { createContext, useState, useEffect,useContext } from 'react';

export const AuthContext = createContext(null);

export function useAuth() {
  return useContext(AuthContext);
}

export const AuthProvider = ({ children }) => {

  const [user, setUser] = useState(null);
  useEffect(() => {
    const userName = localStorage.getItem('userName');
    setUser(userName ? { userName } : null);
  }, []);

  const loginUser = (userName) => {
    localStorage.setItem('userName', userName);
    setUser({ userName });
  };

  const logoutUser = () => {
    localStorage.removeItem('userName');
    setUser(null);
  };

  return <AuthContext.Provider value={{ user, loginUser, logoutUser }}>{children}</AuthContext.Provider>
};
