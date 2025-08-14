import api from "./core/api"

export const searchProperties = async ({
  pageNumber = 1,
  pageSize = 10,
  propertyType = "",
  search = "",
  minPrice = "",
  maxPrice = "",
  minBedrooms = "",
  maxBedrooms = "",
}) => {
  const params = {
    pageNumber,
    pageSize,
    propertyType,
    search,
    minPrice,
    maxPrice,
    minBedrooms,
    maxBedrooms
  };

  Object.keys(params).forEach(key => {
    if (params[key] === "" || params[key] === null) delete params[key];
  });

  const response = await api.get(`properties`, { params });
  return response.data;
};

 export async function getProperty(id){
    return await api.get(`/properties/${id}`);
}
