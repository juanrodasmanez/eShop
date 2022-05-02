using eShop.Core.Interfaces.Repositories;
using eShop.Core.Interfaces.Services;
using eShop.Core.Models;
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

        public UserController(IUserService userService)
        {
            _userService = userService?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public ActionResult<List<User>> GetListEntities()
        {
            List<User> users = _userService.GetListEntities();
            return users;
        }

    }
}
