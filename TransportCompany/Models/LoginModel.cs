using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан телефон")]
        [RegularExpression(@"^[+][7][0-9]{10}", ErrorMessage = "Введите телефон в формате +7ХХХХХХХХХХ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [RegularExpression(@"^[A-Za-z1-9]{6,20}$", ErrorMessage = "От 6 до 20 символов латинского алфавита и цифр")]
        public string Password { get; set; }
    }
}
