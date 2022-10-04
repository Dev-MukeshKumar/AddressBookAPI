using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers.RequestParameters;
using AddressBookAPI.Services;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

namespace AddressBookAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/address-book")]
    public class AddressBookController: ControllerBase
    {

        private readonly IAddressBookService _addressBookService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressBookController> _logger;
        private readonly ILog _log;

        public AddressBookController(IAddressBookService addressBookService,IMapper mapper,ILogger<AddressBookController> logger)
        {
            _addressBookService = addressBookService;
            _mapper = mapper;
            _logger = logger;
            _log = LogManager.GetLogger(typeof(AddressBookController));
        }

        [HttpGet("{AddressBookId}", Name = "GetAddressBook")]
        public IActionResult GetAnAddressBook(Guid addressBookId) {
            
            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn($"User with invalid token, trying to access user data");
                return Unauthorized();
            }

            if (addressBookId == null || addressBookId == Guid.Empty)
            {
                _log.Error("Trying to access address book with not a valid address book id by user: " + tokenUserId);
                return BadRequest("Not a valid address book ID.");
            }

            var response = _addressBookService.GetAddressBook(addressBookId, tokenUserId);

            if (!response.IsSuccess && response.Message.Contains("found"))
            { 
                return NotFound(response.Message);
            }

            if (!response.IsSuccess && response.Message.Contains("User"))
            {
                return NotFound("Address book not found");
            }

            return Ok(response.addressBook);

        }

        [HttpPost]
        public IActionResult CreateAddressBook([FromBody]AddressBookRequestParameter addressBookData)
        {
            if (!ModelState.IsValid)
            {
                _log.Error("Invalid addressbook details used.");
                return BadRequest("Enter valid addressbook data");
            }

            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn($"User with invalid token, trying to access address book data");
                return Unauthorized();
            }

            if (tokenUserId == null || tokenUserId == Guid.Empty)
            {
                _log.Error("Trying to access address book count with not a valid user id by user: " + tokenUserId);
                return BadRequest("Not a valid user ID.");
            }

            var response = _addressBookService.CreateAddressBook(addressBookData, tokenUserId);

            if (!response.IsSuccess && response.Message.Contains("already exists") || response.Message.Contains("not valid"))
            {
                return Conflict(response.Message);
            }

            if(!response.IsSuccess && response.Message.Contains("not found"))
            {
                return NotFound(response.Message);
            }

            return Ok($"Address book created with Id: {response.AddressBook.Id}");
        }

        [HttpGet("count")]
        public IActionResult GetAddressBookCount()
        {
            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn($"User with invalid token, trying to access address book data");
                return Unauthorized();
            }

            if (tokenUserId == null || tokenUserId == Guid.Empty)
            {
                _log.Error("Trying to access address book count with not a valid user id by user: " + tokenUserId);
                return BadRequest("Not a valid user ID.");
            }

            var response = _addressBookService.GetCount(tokenUserId);
            if(!response.IsSuccess && response.Message.Contains("User"))
            {
                _log.Error($"User with Id:{tokenUserId}");
                return NotFound("user not found");
            }
            return Ok(response.Count);
        }

        [HttpDelete("{addressBookId}")]
        public IActionResult DeleteAddressBook(Guid addressBookId)
        {
            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn($"User with invalid token, trying to access address book data");
                return Unauthorized();
            }

            var addressBookResponseData = _addressBookService.GetAddressBook(addressBookId,tokenUserId);

            if (!addressBookResponseData.IsSuccess || addressBookResponseData.Message.Contains("not"))
            {
                _log.Info($"Address book with Id: {addressBookId}, does not exists");
                return NotFound("Address book not found.");
            }

            if (!addressBookResponseData.IsSuccess || addressBookResponseData.Message.Contains("User"))
            {
                _log.Info($"Address book with Id: {addressBookId}, was tried to delete by user Id:{tokenUserId}.");
                return NotFound("Address book not found.");
            }

            var deleteResponse = _addressBookService.DeleteAddressBook(addressBookId, tokenUserId);

            if (!deleteResponse.IsSuccess)
                return NotFound("Address Book not found");

            return Ok(addressBookResponseData.addressBook);

        }


    }
}
