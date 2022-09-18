using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.DTO.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.ApiUser_Email)
                    .NotEmpty()
                        .NotNull()
                            .WithMessage("An email address must be informed!");

            RuleFor(x => x.ApiUser_Password)
                     .NotEmpty()
                         .NotNull()
                            .WithMessage("A password must be informed");
                                
        }
    }
}
