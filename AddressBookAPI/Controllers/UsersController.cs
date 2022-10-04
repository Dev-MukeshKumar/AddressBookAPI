using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers.Responses;
using AddressBookAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using log4net;

namespace AddressBookAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly ILog _log;

        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _log = LogManager.GetLogger(typeof(UsersController));
            _logger = logger;
        }

        //Authentication and user creation controller
        [HttpPost, AllowAnonymous]
        [Route("auth")]
        public IActionResult AuthUser([FromBody]UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                _log.Error("Invalid login details used.");
                return BadRequest("Enter valid user data");
            }
            var response = _userService.AuthUser(user);

            if (!response.IsSuccess)
            {
                _log.Info(user.UserName +" tried to access address book api with wrong credentials");
                return Unauthorized("User not authenticated");
            }

            _log.Info(user.UserName + " user logged in.");
            var token = new Token(response.AccessToken, response.TokenType);
            return Ok(token);
        }

        [HttpPost,AllowAnonymous]
        [Route("register")]
        public IActionResult CreateUser([FromBody] UserCreationDTO user)
        {
            if (!ModelState.IsValid)
            {
                _log.Error("Invalid user details used.");
                return BadRequest("Enter valid user data");
            }
            var response = _userService.CreateUser(user);

            if (!response.IsSuccess)
                return Conflict(response.Message);

            _log.Info("User created with username: "+user.UserName);
            var userToReturn = _mapper.Map<UserToReturnDTO>(response.user);
            return Ok(userToReturn);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetUser(Guid Id)
        {
            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if(!isValidToken)
            {
                _log.Warn($"User with invalid token, trying to access user data");
                return Unauthorized();
            }

            if (Id == null || Id == Guid.Empty)
            {
                _log.Error("Trying to access user data with not a valid user ID with user Id: "+tokenUserId);
                return BadRequest("Not a valid user ID");
            }


            var response = _userService.GetUserById(Id, tokenUserId);

            if (!response.IsSuccess)
            {
                return NotFound(response.Message);
            }

            _log.Info("User with ID: "+Id+", viewed the data.");
            var user = _mapper.Map<UserToReturnDTO>(response.user);

            return Ok(user);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateUser(Guid Id, [FromBody]UserUpdationDTO userData)
        {
            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn($"User with invalid token, trying to access user data");
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                _log.Error("Invalid user updation details used by user Id: "+tokenUserId);
                return BadRequest("Not a valid user data");
            }

            if (Id == null || Id == Guid.Empty)
            {
                _log.Error("Trying to update user data with not a valid user id by user: "+tokenUserId);
                return BadRequest("Not a valid user ID.");
            }

            var response = _userService.UpdateUser(Id, tokenUserId, userData);

            if(!response.IsSuccess)
            {
                return NotFound(response.Message);
            }

            var user = _mapper.Map<UserToReturnDTO>(response.user);

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(Guid Id)
        {

            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn("User with invalid token, trying to delete user data.");
                return Unauthorized();
            }

            if (Id == null || Id == Guid.Empty)
            {
                _log.Error("Trying to delete user data with not a valid user ID by user Id: "+tokenUserId);
                return BadRequest("Not a valid user ID.");
            }


            var response = _userService.DeleteUser(Id, tokenUserId);

            if (!response.IsSuccess)
            {
                return NotFound(response.Message);
            }

            _log.Info($"User with ID: {response.user.Id}, deleted successfully.");

            return NoContent();
        }
    }
}
