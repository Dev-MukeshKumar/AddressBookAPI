using AddressBookAPI.Helpers.RequestParameters;
using AddressBookAPI.Services;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System;
using AddressBookAPI.Entities.Models;
using AutoMapper;
using AddressBookAPI.Entities.DataSets;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;

namespace AddressBookAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/asset")]
    public class AssetController: ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<AssetController> _logger;
        private readonly ILog _log;

        public AssetController(IAssetService assetService, IUserService userService,ILogger<AssetController> logger, IMapper mapper)
        {
            _assetService = assetService;
            _userService = userService;
            _logger = logger;
            _log = LogManager.GetLogger(typeof(AssetController));
            _mapper = mapper;
        }

        [HttpPost("{addressBookId}")]
        public IActionResult UploadAsset(Guid addressBookId,[FromForm]IFormFile file)
        {

            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn("User with invalid token, trying to upload user data");
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                _log.Error("Invalid user updation details used by user Id: " + tokenUserId);
                return BadRequest("Not a valid asset request data");
            }

            if (addressBookId == null || addressBookId == Guid.Empty)
            {
                _log.Error("Trying to update address book data with not a valid addressbook Id by user: " + tokenUserId);
                return BadRequest("Not a valid address book ID.");
            }

            var asset = new Asset();
            asset.Id = Guid.NewGuid();
            asset.DownloadUrl = GenerateDownloadUrl(asset.Id);
            var response = _assetService.AddAsset(addressBookId, tokenUserId, asset, file);

            if (!response.IsSuccess && response.Message.Contains("not found"))
            {
                return NotFound(response.Message);
            }

            if (!response.IsSuccess && response.Message.Contains("exists"))
            {
                return Conflict(response.Message);
            }

            var assetToReturn = _mapper.Map<AssetToReturnDTO>(response.Asset);

            return Ok(assetToReturn);
        }

        [HttpGet("{Id}",Name ="DownloadImage")]
        public IActionResult DownloadAsset(Guid Id)
        {
            Guid tokenUserId;
            var isValidToken = Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out tokenUserId);

            if (!isValidToken)
            {
                _log.Warn("User with invalid token, trying to upload user data");
                return Unauthorized();
            }

            if (Id == null || Id == Guid.Empty)
            {
                _log.Error("Trying to access asset data with not a valid user id by user: " + tokenUserId);
                return BadRequest("Not a valid user ID.");
            }

            var response = _assetService.GetAsset(Id, tokenUserId);

            if (!response.IsSuccess)
            {
                return NotFound(response.Message);
            }

            byte[] bytes = Convert.FromBase64String(response.Asset.Content);

            return File(bytes,response.Asset.FileType,response.Asset.FileName);
        }

        private string GenerateDownloadUrl(Guid assetId)
        {
            return Url.Link("DownloadImage", new { Id = assetId });
        }
    }
}
