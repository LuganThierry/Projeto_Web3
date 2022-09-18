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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<EventDTO>> CreateEventAsync(EventDTO eventDTO)
        {
            if (eventDTO == null)
                return ResultService.Fail<EventDTO>("An object must be informed!");

            var result = new EventDTOValidator().Validate(eventDTO);

            if (!result.IsValid)
                return ResultService.RequestError<EventDTO>("Validation problems", result);

            var cityEvent = _mapper.Map<Event>(eventDTO);
            var data = await _eventRepository.CreateEventAsync(cityEvent);
            return ResultService.Ok<EventDTO>(_mapper.Map<EventDTO>(data));
        }

        public async Task<ResultService<ICollection<EventDTO>>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return ResultService.Ok<ICollection<EventDTO>>(_mapper.Map<ICollection<EventDTO>>(events));
        }

        public async Task<ResultService<ICollection<EventDTO>>> GetEventByLocalAndDateAsync(string local, DateTime date)
        {
            var events = await _eventRepository.GetEventByLocalAndDateAsync(local, date);
            return ResultService.Ok<ICollection<EventDTO>>(_mapper.Map<ICollection<EventDTO>>(events));
        }

        public async Task<ResultService<ICollection<EventDTO>>> GetEventByPriceAndDateAsync(decimal biggestPrice, decimal smallestPrice, DateTime date)
        {
            var events = await _eventRepository.GetEventByPriceAndDateAsync(biggestPrice, smallestPrice, date);
            return ResultService.Ok<ICollection<EventDTO>>(_mapper.Map<ICollection<EventDTO>>(events));
        }

        public async Task<ResultService<ICollection<EventDTO>>> GetEventByTitleAsync(string title)
        {
            var events = await _eventRepository.GetEventByTitleAsync(title);
            return ResultService.Ok<ICollection<EventDTO>>(_mapper.Map<ICollection<EventDTO>>(events));
        }

        public async Task<ResultService<EventDTO>> GetEventByIdAsync(uint id)
        {
            var events = await _eventRepository.GetEventByIdAsync(id);
            if (events == null)
                return ResultService.Fail<EventDTO>("Event could not be found");
            return ResultService.Ok(_mapper.Map<EventDTO>(events));
        }

        public async Task<ResultService> UpdateEventAsync(EventDTO eventDTO)
        {
            if (eventDTO == null)
                return ResultService.Fail("An event must be informed!");

            var validation = new EventDTOValidator().Validate(eventDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("There're problems in the field validations", validation);

            var cityEvent = await _eventRepository.GetEventByIdAsync(eventDTO.Event_Id);
            if (cityEvent == null)
                return ResultService.Fail("Event could not be found");

            cityEvent = _mapper.Map<EventDTO, Event>(eventDTO, cityEvent);
            await _eventRepository.UpdateEventAsync(cityEvent);
                return ResultService.Ok($"The {cityEvent.Event_Id} identity event was successfully updated");
        }

        public async Task<ResultService> DeleteEventAsync(uint id)
        {
            var cityEvent = await _eventRepository.GetEventByIdAsync(id);
            if (cityEvent == null)
                return ResultService.Fail("Event could not be found");
            await _eventRepository.DeleteEventAsync(cityEvent);
            return ResultService.Ok($"The {id} identity event was successfully deleted");

        }
    }
}
