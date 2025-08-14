import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getProperty } from "../../Js/propertyApi";
import { Grid,  Typography, Container, Box,Paper, Chip,Divider } from "@mui/material";
import LikeIcon from "../shared/LikeIcon"

export default function PropertyDetail(){
  const { id } = useParams();
  const [property, setProp] = useState(null);

  useEffect(()=>{ fetchProp(); },[]);

  async function fetchProp(){
    const { data } = await getProperty(id);
    setProp(data);
  }

  if (property) 
  return (
    <Container maxWidth="lg" sx={{ py: 4 }}>
      <Paper elevation={3} sx={{ p: 3, borderRadius: 3 }}>
        <Grid container spacing={2}>
          {/* Left: Image Gallery */}
          <Grid item xs={12} md={6} sx={{position: "relative"}}>
            <Box
              component="img"
              src={property.imageUrl || "https://via.placeholder.com/600x400?text=No+Image"}
              alt={property.title}
              sx={{
                width: "100%",
                height: 400,
                objectFit: "cover",
                borderRadius: 2,
                boxShadow: 3,
                
              }}
            />
              <LikeIcon key={property.id} id = {property.id} isFavorite={property.isFavorite}/>
          </Grid>
          
          {/* Right: Property Info */}
          <Grid item xs={12} md={6}>
            
            <Typography variant="h4" fontWeight="bold" gutterBottom>
              {property.title}
            </Typography>
            <Typography variant="h5" color="primary" gutterBottom>
              ${property.price.toLocaleString()}
            </Typography>

            <Box sx={{ display: "flex", gap: 1, flexWrap: "wrap", mb: 2 }}>
              <Chip label={`${property.bedrooms} Beds`} color="primary" />
              <Chip label={`${property.bathrooms} Baths`} color="secondary" />
              <Chip label={`${property.city} sqft`} variant="outlined" />
              <Chip label={property.propertyType} variant="outlined" />
            </Box>

            <Divider sx={{ my: 2 }} />

            <Typography variant="body1" sx={{ mb: 3 }}>
              {property.description}
            </Typography>
          </Grid>
        </Grid>
      </Paper>
    </Container>
  );
  return <div>Loading...</div>;
}
