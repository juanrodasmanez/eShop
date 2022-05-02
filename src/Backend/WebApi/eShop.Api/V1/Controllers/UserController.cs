using AutoMapper;
using eShop.Core.Interfaces.Repositories;
using eShop.Core.Interfaces.Services;
using eShop.Core.Models;
using eShop.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eShop.Api.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<UserDtoResponse>> GetListEntities()
        {
            List<UserModel> users = _userService.GetListEntities();

            return _mapper.Map<List<UserDtoResponse>>(users);

        }

    }
}
