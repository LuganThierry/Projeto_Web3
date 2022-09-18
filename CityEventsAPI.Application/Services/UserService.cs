using CityEventsAPI.Application.DTO;
using CityEventsAPI.Application.DTO.Validations;
using CityEventsAPI.Application.Services.Interfaces;
using CityEventsAPI.Domain.Authentication;
using CityEventsAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("An object must be informed");

            var validator = new UserDTOValidator().Validate(userDTO);
            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("There're validations problems!", validator);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.ApiUser_Email, userDTO.ApiUser_Password);
            if (user == null)
                return ResultService.Fail<dynamic>("User or password could not be found");

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}
