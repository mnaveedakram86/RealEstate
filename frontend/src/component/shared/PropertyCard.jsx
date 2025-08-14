import React  from "react";
import { Card, CardContent, CardMedia, Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { DEFAULT_PROPERTY_IMAGE } from "../../Js/core/constants"
import LikeIcon from "./LikeIcon"

export default function PropertyCard({ property }) {
  const navigate = useNavigate();
  
  return (
    <Card sx={{ maxWidth: 460, margin: 2, position: "relative" }}>
      <CardMedia
        component="img"
        image={property.imageUrl || DEFAULT_PROPERTY_IMAGE}
        alt={property.title}
        width="460"
        onClick={() => navigate(`/property/${property.id}`)}
      />
      <CardContent>
        <Typography variant="h6">{property.title}</Typography>
        <Typography variant="h8">{property.propertyType}</Typography>
        <Typography variant="body2" color="text.secondary">
          {property.address} — ${property.price}
        </Typography>
        <Button onClick={() => navigate(`/property/${property.id}`)}>View</Button>
      </CardContent>
      <LikeIcon key={property.id} id = {property.id} isFavorite={property.isFavorite}/>
    </Card>
  );
}
