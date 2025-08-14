import React, { useEffect, useState } from 'react';
import PropertyCard from "../shared/PropertyCard";
import { Box, Typography, Grid, Paper,Pagination } from "@mui/material";
import {getFavorites} from "../../Js/favoritesApi"
import { ITEMS_PER_PAGE } from "../../Js/core/constants"

export default function Favorites(){
  const [list, setList] = useState([]);
  const [totalRecords, setTotalRecords] = useState(0);
  const [filters, setFilters] = useState({
    pageNumber: 1,
    pageSize: ITEMS_PER_PAGE
  });
  
   useEffect(()=>{ getFavoritesList(filters); },[filters]);

   async function getFavoritesList(filters){
      const data  = await getFavorites(filters);
      setList(data.listing);
       setTotalRecords(data.totalRecords);
  }
  return (
    <Box sx={{ }}>
      <Typography sx={{ mb: 4 }} variant="h4" fontWeight="bold" gutterBottom>
        Favorites ❤️
      </Typography>

      {(list.length === 0) ? (
        <Paper
          elevation={3}
          sx={{
            p: 4,
            textAlign: "center",
            backgroundColor: "#fafafa",
            borderRadius: 2,
          }}
        >
          <Typography variant="h6" color="text.secondary">
            No favorites yet. Start adding some!
          </Typography>
        </Paper>
      ) : (
        <Grid container spacing={2} sx={{ml:2}}>
          <Grid container spacing={2}>
          {list && list.map((p) => (
            
              <PropertyCard property={p} />
            
          ))}
          </Grid>
          {list && list.length > 0 && (
                  <Pagination
                  sx={{ mt: 2 }}
                  count={totalRecords}
                  page={filters.pageNumber}
                  onChange={(e, value) => setFilters({ ...filters, pageNumber: value })}
                  color="primary"
                />
                )}
        </Grid>
      )}
    </Box>
  );
}
