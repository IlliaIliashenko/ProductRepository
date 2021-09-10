import { createSlice,createAsyncThunk } from "@reduxjs/toolkit";
import api from '../User/api'

export const getProducts = createAsyncThunk(
    'products/getProducts',
    async (requestPage) => {
        const { data } = await api
            .get('https://localhost:44369/api/Product',{params: {page : requestPage}})
        return data
    }
)
export const editProduct = createAsyncThunk(
    'products/editProduct',
    async (entity,{dispatch}) => {
        await api
            .post('https://localhost:44369/api/Product/'+entity.innerEntity.id, entity.innerEntity)
        dispatch(getProducts(entity.page))
    }
)

export const deleteProduct = createAsyncThunk(
    'products/deleteProduct',
    async (entity, {dispatch}) => {
        await api
            .delete('https://localhost:44369/api/Product/'+entity.innerEntity)
        dispatch(getProducts(entity.page))
    }
)

export const createProduct = createAsyncThunk(
    'products/createProduct',
    async (entity, {dispatch}) => {
        await api
            .post('https://localhost:44369/api/Product', entity.innerEntity)
        dispatch(getProducts(entity.page))
    }
)

export const getProductByName = createAsyncThunk(
    'products/getProductByName',
    async (entity) => {
        const { data } = await api
            .get('https://localhost:44369/api/Product/by-name/',{params: {name : entity.name}})
            return data
    }
)

const productsSlice = createSlice({
    name: 'products',
    initialState: {
        listProducts: [],
        pagingModel : {},
        status: null,
    },
    extraReducers: {
        [getProducts.pending]: (state,action) => {
            state.status = 'loading'
        },
        [getProducts.fulfilled]: (state,{ payload }) => {
            state.listProducts = payload.products
            state.pagingModel = payload.pageModel
            state.status = 'success'
        },
        [getProducts.rejected]: (state) => {
            state.status = 'rejected'
        },
        [editProduct.pending]: (state) => {
            state.status = 'loading'
        },
        [editProduct.fulfilled]: (state) => {
            state.status = 'success'
        },
        [editProduct.rejected]: (state) => {
            state.status = 'rejected'
        },
        [deleteProduct.pending]: (state) => {
            state.status = 'loading'
        },
        [deleteProduct.fulfilled]: (state) => {
            state.status = 'success'
        },
        [deleteProduct.rejected]: (state) => {
            state.status = 'rejected'
        },
        [getProductByName.pending]: (state) => {
            state.status = 'loading'
        },
        [getProductByName.fulfilled]: (state,{ payload }) => {
            state.listProducts = payload
            state.status = 'success'
        },
        [getProductByName.rejected]: (state) => {
            state.status = 'rejected'
        },
    }
})

export const selectProducts = ({ products }) => products;

export default productsSlice.reducer