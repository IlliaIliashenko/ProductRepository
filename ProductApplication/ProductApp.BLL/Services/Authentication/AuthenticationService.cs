using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductApp.BLL.Configuration;
using ProductApp.BLL.Models;
using ProductApp.DAL.Data.Repository.Interfaces;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.BLL.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper, IOptions<JwtBearerTokenSettings> jwtTokenOptions)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
        }

        public async Task<bool> Register(UserDomain userDomain)
        {
            var isUserExists = await _userRepository.UserExistAsync(userDomain.Login);

            if (isUserExists)
                return false;

            var mappedUser = _mapper.Map<UserEntity>(userDomain);

            await _userRepository.CreateUserAsync(mappedUser);
            return true;


        }
        

        public async Task<TokenDomain> Login(LoginUserDomain loginUserDomain)
        {
            var identity = await GetIdentity(loginUserDomain.Login, loginUserDomain.Password);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);

            var jwt = new JwtSecurityToken(
                issuer: _jwtBearerTokenSettings.Issuer,
                audience: _jwtBearerTokenSettings.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new TokenDomain()
            {
                AccessToken = encodedJwt,
                UserName = identity.Name,
            };

            return response;
        }

        private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            var user = await _userRepository.GetUserAsync(login, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                };

                foreach (var userDomainUserRole in user.UserRoles)
                {
                    claims.Add((new Claim(ClaimsIdentity.DefaultRoleClaimType, userDomainUserRole.Role.RoleName)));
                }

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims,
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }



    }
}