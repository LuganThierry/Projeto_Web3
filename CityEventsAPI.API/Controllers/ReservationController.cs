using CityEventsAPI.Application.DTO;
using CityEventsAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityEventsAPI.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateReservation")]
        public async Task<ActionResult> CreateReservationAsync([FromBody] ReservationDTO reservationDTO)
        {
            var result = await _reservationService.CreateReservationAsync(reservationDTO);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetReservationByID/{id}")]
        public async Task<ActionResult> GetReservationByIdAsync(uint id)
        {
            var result = await _reservationService.GetReservationByIDAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetAllReservation")]
        public async Task<ActionResult> GetAllReservationAsync()
        {
            var result = await _reservationService.GetAllReservationAsync();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpGet]
        [Route("GetReservationByPersonNameAndEventTitle/{personName}/{eventTitle}")]
        public async Task<ActionResult> GetReservationByPersonNameAndEventTitleAsync(string personName, string eventTitle)
        {
            var result = await _reservationService.GetReservationByPersonNameAndEventTitleAsync(personName, eventTitle);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateReservation")]
        public async Task<ActionResult> UpdateReservationAsync([FromBody] ReservationDTO reservationDTO)
        {
            var result = await _reservationService.UpdateReservationAsync(reservationDTO);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteReservation/{id}")]
        public async Task<ActionResult> DeleteReservationAsync(uint id)
        {
            var result = await _reservationService.DeleteReservationAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);

        }

    }
}
