import React, { useState,useEffect } from "react";
import {  IconButton, Tooltip } from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import { addFavorites,removeFavorites } from "../../Js/favoritesApi"
import { useAuth } from "../../context/AuthContext";

export default function LikeIcon({id, isFavorite }) {
  const { user } = useAuth();
  const [isLiked, setisLiked] = useState(isFavorite);
  const [isLoggedIn, setisLoggedIn] = useState(false);
  const handleFavoriteClick = async () => {
    if (isLiked) 
    {
      const res = await removeFavorites(id);
      if(res.status == 204 || res.status == 404)
        setisLiked(false)
    }
    else
    {
      const res = await addFavorites(id);
      if(res.status == 201)
        setisLiked(true)
    }
  };
  useEffect(() => { 
    if(user) 
      setisLoggedIn(true) 
    else  
      setisLoggedIn(false);
    }, [user]);
  return (
      <Tooltip title={isLoggedIn ?  isLiked ? "Remove from favorites" : "Add to favorites" : "Login to add favorites" }>
        <span>
          <IconButton
            onClick={handleFavoriteClick}
            disabled={!isLoggedIn}
            sx={{
              position: "absolute",
              top: 10,
              right: 10,
              backgroundColor: "rgba(255,255,255,0.8)"
            }}
          >
            <FavoriteIcon sx={{ color: isLoggedIn ? isLiked ? "red" : "white" : "#ccc"  }} />
          </IconButton>
        </span>
      </Tooltip>
    
  );
}
