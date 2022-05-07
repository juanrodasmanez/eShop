using AutoMapper;
using eShop.Core.Interfaces.Services;
using eShop.Core.Models;
using eShop.Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eShop.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDtoResponse>> GetListEntities()
        {
            IEnumerable<UserModel> users = _userService.GetList();

            return _mapper.Map<List<UserDtoResponse>>(users);

        }
    }
}
