using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.DTO.Validations
{
    public class ReservationDTOValidator : AbstractValidator<ReservationDTO>
    {
        public ReservationDTOValidator()
        {
            RuleFor(x => x.Event_Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("A event identity must be informed!!");

            RuleFor(x => x.Person_Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("A person name must be informed!!");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .WithMessage("A quantity must be informed!!");
        }
    }
}
