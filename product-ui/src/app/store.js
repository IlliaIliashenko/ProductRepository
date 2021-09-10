import { configureStore } from '@reduxjs/toolkit';
import productReducer from '../features/Product/ProductSlice'
import userReducer from '../features/User/UserSlice.js'


export const store = configureStore({
  reducer: {
    products : productReducer,
    user : userReducer,
  },
});
