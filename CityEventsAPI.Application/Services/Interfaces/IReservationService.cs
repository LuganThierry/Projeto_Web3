using CityEventsAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ResultService<ReservationDTO>> CreateReservationAsync(ReservationDTO reservationDTO);
        Task<ResultService<ICollection<ReservationDTO>>> GetReservationByPersonNameAndEventTitleAsync(string personName, string eventTitle);
        Task<ResultService<ReservationDTO>> GetReservationByIDAsync(uint id);
        Task<ResultService<ICollection<ReservationDTO>>> GetAllReservationAsync();
        Task<ResultService> UpdateReservationAsync(ReservationDTO reservationDTO);
        Task<ResultService> DeleteReservationAsync(uint id);
    }
}
