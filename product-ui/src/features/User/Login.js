import React,{ useState } from 'react'
import { useDispatch } from 'react-redux'
import { login } from './UserSlice'
import TokenService from './TokenService'
import "./SignInUp.css"



const Login = () => {
    const dispatch = useDispatch()
    const [user,setUser] = useState();

    const onSubmit = (e) => {
        e.preventDefault();
        dispatch(login(user));

    }
    const isLogin = TokenService.getUser();

    return (
        <div className="form">
        <form className="register-form" onSubmit={onSubmit}>
            <h2>Sign Up</h2>
            <input onChange={(e) => setUser({ ...user,login: e.target.value })} placeholder="Login" />
            <input onChange={(e) => setUser({ ...user,password: e.target.value })} placeholder="Password" />
            <button type="submit"> sign un</button>
        </form>
    </div>
    )
 

}

export default Login