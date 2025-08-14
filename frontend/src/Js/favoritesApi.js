import api from "./core/api"

export const getFavorites = async ({
  pageNumber = 1,
  pageSize = 10,
}) => {
  const params = {
    pageNumber,
    pageSize,
  };

  Object.keys(params).forEach(key => {
    if (params[key] === "" || params[key] === null) delete params[key];
  });

  const response = await api.get(`favorites`, { params });
  return response.data;
};

// export async function getFavorites( filters) {
//   const res = await api.get('/favorites',{ filters});
//   return res;
//}

export async function addFavorites(id) {
  const res = await api.post(`/favorites/${id}`);
  return res;
}

export async function removeFavorites(id) {
  const res = await api.delete(`/favorites/${id}`);
  return res;
}