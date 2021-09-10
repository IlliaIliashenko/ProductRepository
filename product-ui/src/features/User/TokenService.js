class TokenService {

  getLocalAccessToken() {
    const user = JSON.parse(localStorage.getItem("user"));
    return user?.accessToken;
  }

  getUser() {
    return JSON.parse(localStorage.getItem("user"));
  }

  getUserRoles() {
    return localStorage.getItem("roles")
  }

  removeUser() {
    localStorage.removeItem("user");
    localStorage.removeItem("roles");
  }
}

export default new TokenService();