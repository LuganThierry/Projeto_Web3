using CityEventsAPI.Application.DTO;
using CityEventsAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CityEventsAPI.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<ActionResult> CreateEventAsync([FromBody] EventDTO eventDTO)
        {
            var result = await _eventService.CreateEventAsync(eventDTO);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetAllEvents")]
        public async Task<ActionResult> GetAllEventsAsync()
        {
            var result = await _eventService.GetAllEventsAsync();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetEventsbyLocalAndDate/{local}/{date}")]
        public async Task<ActionResult> GetEventByLocalAndDateAsync(string local, DateTime date)
        {
            var result = await _eventService.GetEventByLocalAndDateAsync(local, date);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetEventsByPriceAndDate/{biggestprice}/{smallestprice}/{date}")]
        public async Task<ActionResult> GetEventByPriceAndDateAsync(decimal biggestPrice, decimal smallestPrice, DateTime date)
        {
            var result = await _eventService.GetEventByPriceAndDateAsync(biggestPrice, smallestPrice, date);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("GetEventByTitle/{title}")]
        public async Task<ActionResult> GetEventByTitleAsync(string title)
        {
            var result = await _eventService.GetEventByTitleAsync(title);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetEventByID/{id}")]
        public async Task<ActionResult> GetEventByIdAsync(uint id)
        {
            var result = await _eventService.GetEventByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateEvent")]
        public async Task<ActionResult> UpdateEventAsync([FromBody] EventDTO eventDTO)
        {
            var result = await _eventService.UpdateEventAsync(eventDTO);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        public async Task<ActionResult> DeleteEventAsync(uint id)
        {
            var result = await _eventService.DeleteEventAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);

        }

    }
}
