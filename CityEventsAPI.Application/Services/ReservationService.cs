using AutoMapper;
using CityEventsAPI.Application.DTO;
using CityEventsAPI.Application.DTO.Validations;
using CityEventsAPI.Application.Services.Interfaces;
using CityEventsAPI.Domain.Entities;
using CityEventsAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IEventRepository _eventRespository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IEventRepository eventRespository, IReservationRepository reservationRepository, IMapper mapper)
        {
            _eventRespository = eventRespository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ReservationDTO>> CreateReservationAsync(ReservationDTO reservationDTO)
        {
            if (reservationDTO == null)
                return ResultService.Fail<ReservationDTO>("An object must be informed!");

            var result = new ReservationDTOValidator().Validate(reservationDTO);

            if (!result.IsValid)
                return ResultService.RequestError<ReservationDTO>("Validation problems", result);

            var reservation = _mapper.Map<Reservation>(reservationDTO);
            var data = await _reservationRepository.CreateReservationAsync(reservation);
            return ResultService.Ok<ReservationDTO>(_mapper.Map<ReservationDTO>(data));

        }

        public async Task<ResultService> DeleteReservationAsync(uint id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
                return ResultService.Fail("Event could not be found");
            await _reservationRepository.DeleteReservationAsync(reservation);
            return ResultService.Ok($"The {id} identity event was successfully deleted");
        }

        public async Task<ResultService<ICollection<ReservationDTO>>> GetAllReservationAsync()
        {
            var reservation = await _reservationRepository.GetAllReservationsAsync();
            return ResultService.Ok<ICollection<ReservationDTO>>(_mapper.Map<ICollection<ReservationDTO>>(reservation));
        }

        public async Task<ResultService<ReservationDTO>> GetReservationByIDAsync(uint id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
                return ResultService.Fail<ReservationDTO>("Reservation could not be found");
            return ResultService.Ok(_mapper.Map<ReservationDTO>(reservation));
        }

        public async Task<ResultService<ICollection<ReservationDTO>>> GetReservationByPersonNameAndEventTitleAsync(string personName, string eventTitle)
        {
            var eventTitleId = await _eventRespository.GetEventIdByTitleAsync(eventTitle);
            var reservation = await _reservationRepository.GetReservationByPersonNameAndEventTitleAsync(personName, eventTitleId);
            return ResultService.Ok<ICollection<ReservationDTO>>(_mapper.Map<ICollection<ReservationDTO>>(reservation));
        }

        public async Task<ResultService> UpdateReservationAsync(ReservationDTO reservationDTO)
        {
            if (reservationDTO == null)
                return ResultService.Fail("An reservation must be informed!");

            var validation = new ReservationDTOValidator().Validate(reservationDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("There're problems in the field validations", validation);

            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationDTO.Event_Id);
            if (reservation == null)
                return ResultService.Fail("Reservation could not be found");

            reservation = _mapper.Map<ReservationDTO, Reservation>(reservationDTO, reservation);
            await _reservationRepository.UpdateReservationAsync(reservation);
            return ResultService.Ok($"The {reservation.Reservation_Id} identity event was successfully updated");
        }
    }
}
