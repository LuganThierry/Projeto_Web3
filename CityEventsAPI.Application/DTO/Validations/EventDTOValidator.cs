using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.DTO.Validations
{
    public class EventDTOValidator : AbstractValidator<EventDTO>
    {
        public EventDTOValidator()
        {
            RuleFor(x => x.Event_Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("A title must be informed!!");

            RuleFor(x => x.Event_Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("A description must be informed!!");

            RuleFor(x => x.Event_DataHour)
                .NotEmpty()
                .NotNull()
                .WithMessage("A date and an hour must be informed!!");

            RuleFor(x => x.Event_Local)
                .NotEmpty()
                .NotNull()
                .WithMessage("A local must be informed!!");

            RuleFor(x => x.Event_Address)
                .NotEmpty()
                .NotNull()
                .WithMessage("A address must be informed!!");

            RuleFor(x => x.Event_Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("A price  must be informed!!");

        }
    }
}
