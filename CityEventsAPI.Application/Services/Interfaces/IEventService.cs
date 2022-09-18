using CityEventsAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.Services.Interfaces
{
    public interface IEventService
    {
        Task<ResultService<EventDTO>> CreateEventAsync(EventDTO eventDTO);
        Task<ResultService<ICollection<EventDTO>>> GetAllEventsAsync();
        Task<ResultService<ICollection<EventDTO>>> GetEventByLocalAndDateAsync(string local, DateTime date);
        Task<ResultService<ICollection<EventDTO>>> GetEventByPriceAndDateAsync(decimal biggestPrice, decimal smallestPrice, DateTime date);
        Task<ResultService<ICollection<EventDTO>>> GetEventByTitleAsync(string title);
        Task<ResultService<EventDTO>> GetEventByIdAsync(uint id);
        Task<ResultService> UpdateEventAsync(EventDTO eventDTO);
        Task<ResultService> DeleteEventAsync(uint id); 

    }
}
