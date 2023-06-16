﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Carpooling.DomainModels;
using CarPooling.API.RequestDTOs;
using AutoMapper;
using CarPooling.Services.Contracts;
using System.Security.Claims;

namespace CarPooling.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class BookRideController : ControllerBase
    {
        private readonly IBookRideService _bookRideService;
        private readonly IMapper _mapper;

        public BookRideController(IBookRideService bookRideService, IMapper mapper)
        {
            this._bookRideService = bookRideService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getBookedRides")]
        [ProducesResponseType(typeof(IEnumerable<BookRide>), StatusCodes.Status200OK)]
        public IEnumerable<BookRide> GetBookedRides()
        {
            return this._bookRideService.GetBookedRides();
        }

        [HttpPost]
        [Route("bookRide")]
        [ProducesResponseType(typeof(BookRide), StatusCodes.Status200OK)]
        public async Task<IActionResult> BookRide(BookRideRequest bookRideRequest)
        {
            try
            {
                ClaimsPrincipal user = HttpContext.User;
                var userId = HttpContext.User.FindFirst("UserId")?.Value;
                BookRide _bookRide = _mapper.Map<BookRide>(bookRideRequest);
                _bookRide.UserId = (int)Convert.ToInt64(userId);
                return Ok(await this._bookRideService.BookRide(_bookRide));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
