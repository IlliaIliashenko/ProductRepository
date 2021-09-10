import axios from "axios";
import TokenService from "./TokenService";
import Login from "./Login";

const instance = axios.create({
    baseURL: "https://localhost:44369/api",
    headers: {
        "Content-Type": "application/json",
    },
});

instance.interceptors.request.use(
    (config) => {
        const token = TokenService.getLocalAccessToken();
        if (token) {
            config.headers["Authorization"] = 'Bearer ' + token;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

instance.interceptors.response.use(
    (res) => {
        return res;
    },
    async (err) => {

        if (err.response.status === 401) {
            TokenService.removeUser();
            <Login/>
        }


        return Promise.reject(err);
    }
);

export default instance;