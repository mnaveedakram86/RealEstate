import React,{useEffect} from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import Login from './component/auth/Login';
import Register from './component/auth/Register';
import PropertySearch from './component/property/PropertySearch';
import PropertyDetail from './component/property/PropertyDetail';
import Favorites from './component/favorites/Favorites';
import NavigationBar from './component/shared/NavigationBar';
import { useNavigate } from "react-router-dom";
import { Container } from "@mui/material";
import AuthGuard from "./component/auth/AuthGuard";
import {setupInterceptors} from "./Js/core/api"
import { useAuth } from "./context/AuthContext";

export default function AppRoute() {
  const navigate = useNavigate();
  const { logoutUser } = useAuth();
    useEffect(() => {
    setupInterceptors(navigate,logoutUser);
  }, [navigate]);

  return (
    
        <Container maxWidth="xl" sx={{ py: 3 }}>
          <NavigationBar />
          
        <Routes>
          <Route path="/" element={<PropertySearch />} />
          <Route path="/property/:id" element={<PropertyDetail />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route element={<AuthGuard />}>
          <Route path="/favorites" element={<Favorites />} />
          </Route>
        </Routes>
        </Container>
      
  );
}
