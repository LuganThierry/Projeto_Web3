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
    public class ReservationRepository : IReservationRepository
    {
        private readonly CityEventsAPIDbContext _db;

        public ReservationRepository(CityEventsAPIDbContext db)
        {
            _db = db;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            _db.Add(reservation);
            await _db.SaveChangesAsync();
            return reservation;
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            _db.Remove(reservation);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Reservation>> GetAllReservationsAsync()
        {
            return await _db.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(uint id)
        {
            return await _db.Reservations.FirstOrDefaultAsync(x => x.Reservation_Id == id);
        }


        public async Task<ICollection<Reservation>> GetReservationByPersonNameAndEventTitleAsync(string personName, uint eventId)
        {
            return await _db.Reservations
                                .Where(x => x.Person_Name == personName)
                                    .Where(x => x.Event_Id == eventId)
                                        .ToListAsync(); 
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _db.Update(reservation);
            await _db.SaveChangesAsync();
        }


    }
}
