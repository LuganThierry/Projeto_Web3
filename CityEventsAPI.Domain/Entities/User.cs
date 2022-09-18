using CityEventsAPI.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Domain.Entities
{
    public class User
    {
        public uint ApiUser_Id { get; set; }
        public string ApiUser_Email { get; set; }
        public string ApiUser_Password { get; set; }

        public User(string apiUser_Email, string apiUser_Password)
        {
            Validation(apiUser_Email, apiUser_Password);
        }

        public User(uint apiUser_Id, string apiUser_Email, string apiUser_Password)
        {
            DomainValidationException.When(apiUser_Id <= 0, "The user identity number must be informed!");
            ApiUser_Id = apiUser_Id;
            Validation(apiUser_Email, apiUser_Password);
        }

        private void Validation(string userEmail, string userPassword)
        {
            DomainValidationException.When(string.IsNullOrEmpty(userEmail), "An email adress must be informed");
            DomainValidationException.When(string.IsNullOrEmpty(userPassword), "A password must be informed");

            ApiUser_Email = userEmail;
            ApiUser_Password = userPassword; 
        }

        /*
            Usuários de testes
            Id = 2, Email = luganthierry@gmail.com, Password = 010203
        */
    }
}
