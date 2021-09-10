import React from 'react'
import TokenService from './TokenService'
import "./SignInUp.css"



const Logout = () => {

    const onSubmit = (e) => {
        e.preventDefault();
        TokenService.removeUser();

    }

    return (
        <div className="form">
            <form className="register-form" onSubmit={onSubmit}>
                <h2>Log Out</h2>
                <button type="submit">Log Out</button>
            </form>
        </div>
    )

}

export default Logout