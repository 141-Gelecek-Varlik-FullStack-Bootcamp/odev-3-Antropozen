using AutoMapper;
using Demo.Model;
using Demo.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService,IMapper _mapper)
        {
            _userService = userService;
            mapper = _mapper;
        }

        [HttpPost("add")]
        public General<Model.User.User> Insert([FromBody] Demo.Model.User.User newUser)
        {
            var result = false;
            return _userService.Insert(newUser);
            //return result;
        }
    }
}
