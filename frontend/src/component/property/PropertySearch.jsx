import React, { useEffect, useState } from 'react';
import { searchProperties } from "../../Js/propertyApi";
import { TextField, Select, MenuItem, Button, Grid, Pagination,InputAdornment,Typography, Paper,CircularProgress,Box } from "@mui/material";
import PropertyCard from "../shared/PropertyCard";
import { ITEMS_PER_PAGE } from "../../Js/core/constants"

export default function PropertySearch(){

  const [properties, setProperties] = useState([]);
  const [totalRecords, setTotalRecords] = useState(0);
  const [loading, setLoading] = useState(false); // loading state
  const [error, setError] = useState("");
  const [filters, setFilters] = useState({
    propertyType : "",
    search : "",
    minPrice : "",
    maxPrice : "",
    minBedrooms : "",
    maxBedrooms :"",
    pageNumber: 1,
    pageSize: ITEMS_PER_PAGE
  });
  const loadData = async () => {
    try{
        setLoading(true);
        setError("");
        const data = await searchProperties(filters);
        setProperties(data.listing);
        setTotalRecords(data.totalRecords);
    }catch (err) {
        setError("Failed to load properties.");
      } finally {
        setLoading(false);
      }
    
  };

  useEffect(() => {
    loadData();
    
    
  }, [filters]);

  const handleFilterChange = (field, value) => {
      setFilters((prev) => ({
        ...prev,
        [field]: value,
        pageNumber: 1 
      }));
    };

  return (
    <div>
      <Grid container spacing={2} sx={{ mb: 2 }}>
        <Grid item xs={12} sm={1}>
          <Select
            fullWidth
            value={filters.propertyType}
            onChange={(e) => setFilters({ ...filters, propertyType: e.target.value, pageNumber: 1 })}
            displayEmpty
          >
            <MenuItem value="">All Types</MenuItem>
            <MenuItem value="Rent">Rent</MenuItem>
            <MenuItem value="Sale">Sale</MenuItem>
          </Select>
        </Grid>
        <Grid item xs={12} sm={1}>
          <TextField
            fullWidth
            type="number"
            placeholder="Min Price"
            value={filters.minPrice}
            onChange={(e) => handleFilterChange("minPrice", e.target.value)}
            InputProps={{
              startAdornment: <InputAdornment position="start">$</InputAdornment>
            }}
          />
        </Grid>
        <Grid item xs={12} sm={1}>
          <TextField
            fullWidth
            type="number"
            placeholder="Max Price"
            value={filters.maxPrice}
            onChange={(e) => handleFilterChange("maxPrice", e.target.value)}
            InputProps={{
              startAdornment: <InputAdornment position="start">$</InputAdornment>
            }}
          />
        </Grid>
        <Grid item xs={12} sm={1}>
          <TextField
            fullWidth
            type="number"
            placeholder="Min Beds"
            value={filters.minBedrooms}
            onChange={(e) => handleFilterChange("minBedrooms", e.target.value)}
          />
        </Grid>
        <Grid item xs={12} sm={1}>
          <TextField
            fullWidth
            type="number"
            placeholder="Max Beds"
            value={filters.maxBedrooms}
            onChange={(e) => handleFilterChange("maxBedrooms", e.target.value)}
          />
        </Grid>
         <Grid item xs={12} sm={5}>
          <TextField
            fullWidth
            placeholder="Search by title or address"
            value={filters.search}
            onChange={(e) => setFilters({ ...filters, search: e.target.value, pageNumber: 1 })}
          />
        </Grid>
        <Grid item xs={12} sm={2}>
          <Button variant="contained" fullWidth onClick={loadData} sx={{height:58}}>
            {loading ? (
              <CircularProgress
              size={24}
              sx={{
                color: "white",
                position: "absolute",
              }}
            />
            ) : (
              "Search"
            )}
          </Button>
        </Grid>
      </Grid>
      
      {/* Property List */}
      <Grid container spacing={2}>
        
        
        {error && (
          <Typography color="error" sx={{ mt: 2 }}>
            {error}
          </Typography>
        )}

        {!loading && properties.length === 0 && (
          <Paper
          
          sx={{
            p: 4,
            textAlign: "center",
            backgroundColor: "#fafafa",
            borderRadius: 2,
            width:"100%"
          }}
        >
          <Typography variant="h6" color="text.secondary">
            No properties found.
          </Typography>
        </Paper>
        )}
        {!loading && properties && properties.length > 0 && properties.map((p) => (
          <PropertyCard key={p.id} property={p} />
        ))}
      </Grid>

      {/* Pagination */}
      {!loading && properties.length > 0 && (
        <Pagination
        sx={{ mt: 2 }}
        count={totalRecords}
        page={filters.pageNumber}
        onChange={(e, value) => setFilters({ ...filters, pageNumber: value })}
        color="primary"
      />
      )}
      
    </div>
  );
}
