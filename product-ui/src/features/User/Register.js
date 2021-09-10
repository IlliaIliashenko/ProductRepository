import React,{ useState,useEffect } from 'react'
import { useDispatch } from 'react-redux'
import { register } from './UserSlice'
import "./SignInUp.css"

const Register = () => {

    const dispatch = useDispatch()
    const [user,setUser] = useState();


    const onSubmit = (e) => {
        e.preventDefault();
        dispatch(register(user));

    }

    return <div className="form">
        <form className="register-form" onSubmit={onSubmit}>
        <h2>Sign In</h2>
            <input onChange={(e) => setUser({ ...user,login: e.target.value })} placeholder="Login" />
            <input onChange={(e) => setUser({ ...user,password: e.target.value })} placeholder="Password" />
            <input onChange={(e) => setUser({ ...user,confirmPassword: e.target.value })} placeholder="ConfirmPassword" />
            <button type="submit"> sign in</button>
        </form>
    </div>
}

export default Register;