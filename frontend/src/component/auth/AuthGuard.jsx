import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";

export default function AuthGuard() {
  const { user } = useAuth();

  if (user) {
    return <Outlet />;
  }

  return <Navigate to="/login" replace />;
}
