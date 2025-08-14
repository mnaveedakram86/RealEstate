import {useState} from "react"
import { useNavigate } from "react-router-dom";
import { AppBar, Toolbar, Typography, Button, Box, Stack, Avatar,Menu, MenuItem, IconButton   } from "@mui/material";
import { useAuth } from "../../context/AuthContext"
import { logout } from "../../Js/core/auth/auth"

export default function NavigationBar() {
  const navigate = useNavigate();
  const { user, logoutUser } = useAuth();

  return (
    <AppBar
      position="sticky"
      sx={{
        background: "linear-gradient(90deg, #2196F3 0%, #21CBF3 100%)",
        boxShadow: "0 3px 10px rgba(0,0,0,0.2)",
        marginBottom: "20px"
      }}
    >
      <Toolbar sx={{ justifyContent: "space-between" }}>
        {/* Logo / Brand */}
        <Typography variant="h6" sx={{ fontWeight: "bold" }}>
          RealEstate Portal
        </Typography>

        {/* Menu Items */}
        <Box
          display="flex"
          alignItems="center"
          justifyContent="space-between"
          px={3}
          py={2}
        >
          <Stack direction="row" spacing={2}>
            <Button color="inherit" onClick={() => navigate("/")}>
              Home
            </Button>
            
          </Stack>
          {user ? (
            <Stack direction="row" spacing={2} alignItems="center">
              <Button color="inherit" onClick={() => navigate("/favorites")}>
                Favorites
              </Button>
              <Avatar sx={{ bgcolor: "secondary.main" }}>
                {user.userName?.[0]?.toUpperCase()}
              </Avatar>
              <Typography variant="body1">Welcome, {user.userName}</Typography>
              <Button
                color="inherit"
                onClick={() => {
                  logout();
                  logoutUser();
                }}
              >
                Logout
              </Button>
            </Stack>
          ) : (
            <Stack direction="row" spacing={2}>
              <Button
                color="inherit"
                onClick={() => navigate("/register")}
              >
                Register
              </Button>
              <Button
                color="inherit"
                onClick={() => navigate("/login")}
              >
                Login
              </Button>
            </Stack>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
}
