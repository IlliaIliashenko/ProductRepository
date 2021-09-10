import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import api from './api'
import axios from "axios";
import jwtDecode from "jwt-decode";

export const login = createAsyncThunk(
    'user/login',
    async (user) => {
        await api
            .post('https://localhost:44369/api/Authentication/login', user)
            .then(response => {
                if (response.data.accessToken) {
                    localStorage.setItem("user",JSON.stringify(response.data));
                }
            });

    }
)

export const register = createAsyncThunk(
    'user/register',
    async (user) => {
        await axios
            .post('https://localhost:44369/api/Authentication/register',user)

    }
)

const userSlice = createSlice({
    name: 'user',
    initialState: {
        status: null,
        roles : []
    },
    extraReducers: {
        [register.pending]: (state,action) => {
            state.status = 'loading'
        },
        [register.fulfilled]: (state,{ payload }) => {
            state.status = 'success'
        },
        [register.rejected]: (state) => {
            state.status = 'rejected'
        },
        [login.pending]: (state,action) => {
            state.status = 'loading'
        },
        [login.fulfilled]: (state,action) => {
            let user = JSON.parse(localStorage.getItem("user"));
            let decoded = jwtDecode(user.accessToken)
            localStorage.setItem("roles", decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
            state.status = 'success'
        },
        [login.rejected]: (state) => {
            state.status = 'rejected'
        },
    }
})

export const selectUser = ({ user }) => user;

export default userSlice.reducer