using CityEventsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<Event> CreateEventAsync(Event cityEvent);
        Task UpdateEventAsync(Event cityEvent);
        Task DeleteEventAsync(Event cityEvent);
        Task<ICollection<Event>> GetEventByTitleAsync(string title);
        Task<ICollection<Event>> GetEventByLocalAndDateAsync(string local, DateTime date); 
        Task<ICollection<Event>> GetEventByPriceAndDateAsync(decimal biggestPrice, decimal smallestPrice, DateTime date);
        // GetAllEventsAsync is dedicated for testing
        Task<ICollection<Event>> GetAllEventsAsync(); 
        Task<Event> GetEventByIdAsync(uint id);
        //Task<string> GetEventTitleByIdAsync(uint id);
        Task<uint> GetEventIdByTitleAsync(string name);
    }
}
