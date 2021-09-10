using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProductApp.BLL.Models;
using ProductApp.BLL.Services.Authentication;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            var mappedUser = _mapper.Map<UserDomain>(model);
            var result = await _authenticationService.Register(mappedUser);

            if (!result)
            {
                return BadRequest("incorrect input");
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenResponseModel>> Login([FromBody] LoginUserModel loginUserModel)
        {
            var mappedLoginModel = _mapper.Map<LoginUserDomain>(loginUserModel);

            var loginResult = await _authenticationService.Login(mappedLoginModel);

            if (loginResult == null)
            {
                return BadRequest("User with provided credentials not found");
            }

            var mappedTokenModel = _mapper.Map<TokenResponseModel>(loginResult);

            return Ok(mappedTokenModel);
        }
    }
}
