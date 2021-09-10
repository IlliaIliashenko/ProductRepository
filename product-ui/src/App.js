import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Login from './features/User/Login'
import Register from './features/User/Register'
import Products from './features/Product/Products';
import Logout from './features/User/Logout';
import TokenService from './features/User/TokenService';

import './App.css';


function App() {

  const isUserLogined = TokenService.getUser();

  return (
    <div className="App">
     
      <Router>
      <div className=".App-header">
        {isUserLogined && <Logout/>}
        {isUserLogined && <Products/>}
        {isUserLogined === null && <Login/> }
        {isUserLogined === null && <Register/> }
      </div>
      </Router>
    </div>
  );
}

export default App;
