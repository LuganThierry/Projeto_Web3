using CityEventsAPI.Domain.Authentication;
using CityEventsAPI.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("ApiUser_Email", user.ApiUser_Email),
                new Claim("ApiUser_Id", user.ApiUser_Id.ToString())
            };

            var expires = DateTime.Now.AddDays(10);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("he0ErCNloe4J7Id0Ry2SEDg09lKkZkfsRiGsdX_vgEg"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return new
            {
                acess_token = token,
                expirations = expires
            };
        }
    }
}
