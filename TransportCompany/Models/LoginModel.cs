using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models
{
    public class LoginModel
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool WasError { get; set; }

        public LoginModel(string phonrNumber, string password, bool wasError = false)
        {
            PhoneNumber = phonrNumber;
            Password = password;
            WasError = wasError;
        }

        public LoginModel()
        {

        }
    }
}
