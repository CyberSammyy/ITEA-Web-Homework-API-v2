using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITEA_Web_Homework_API_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet("{id}")]
        public User GetUserById(Guid id)
        {
            return _service.GetUserById(id);
        }

        [HttpPost]
        public async Task<Guid> PostUser(User user)
        {
            return await _service.AddUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteById(Guid id)
        {
            return await _service.DeleteUserById(id);
        }

        [HttpPut]
        public async Task<bool> PutUser(User user)
        {
            return await _service.PutUser(user);
        }
    }
}
