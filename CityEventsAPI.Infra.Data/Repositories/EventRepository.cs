using CityEventsAPI.Domain.Entities;
using CityEventsAPI.Domain.Repositories;
using CityEventsAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Infra.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly CityEventsAPIDbContext _db;

        public EventRepository(CityEventsAPIDbContext db)
        {
            _db = db;
        }

        public async Task<Event> CreateEventAsync(Event cityEvent)
        {
            _db.Add(cityEvent);
            await _db.SaveChangesAsync();
            return cityEvent;
        }

        public async Task DeleteEventAsync(Event cityEvent)
        {
            _db.Remove(cityEvent);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Event>> GetAllEventsAsync()
        {
            return await _db.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(uint id)
        {
            return await _db.Events.FirstOrDefaultAsync(x => x.Event_Id == id);
        }

        public async Task<ICollection<Event>> GetEventByLocalAndDateAsync(string local, DateTime date)
        {
            return await _db.Events
                                .Where(x => x.Event_Local == local)
                                     .Where(x => x.Event_DataHour == date)
                                        .ToListAsync();
        }

        public async Task<ICollection<Event>> GetEventByPriceAndDateAsync(decimal biggestPrice, decimal smallestPrice, DateTime date)
        {
            return await _db.Events
                                .Where(x => x.Event_Price <= biggestPrice && x.Event_Price >= smallestPrice)  
                                    .Where(x => x.Event_DataHour == date)
                                        .ToListAsync();
        }

        public async Task<ICollection<Event>> GetEventByTitleAsync(string title)
        {
            return await _db.Events.Where(x => x.Event_Title == title).ToListAsync();
            // fix lambda expression so it returns similar event titles
        }

        public async Task<uint> GetEventIdByTitleAsync(string name)
        {
            return (await _db.Events.FirstOrDefaultAsync(x => x.Event_Title == name))?.Event_Id ?? 0;
        }

        //public async Task<string> GetEventTitleByIdAsync(uint id)
        //{
        //    return (await _db.Events.FirstOrDefaultAsync(x => x.Event_Id == id))?.Event_Title ?? "There is not such event";
        //}

        public async Task UpdateEventAsync(Event cityEvent)
        {
            _db.Update(cityEvent);
            await _db.SaveChangesAsync();
        }
    }
}
