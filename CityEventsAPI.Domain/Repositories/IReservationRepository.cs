using CityEventsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);   
        Task DeleteReservationAsync(Reservation reservation);
        Task<ICollection<Reservation>> GetReservationByPersonNameAndEventTitleAsync(string personName, uint eventId);
        Task<ICollection<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(uint id);
    }
}
