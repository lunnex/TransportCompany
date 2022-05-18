using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Passenger
    {
        [Required(ErrorMessage = "Не указан телефон")]
        [RegularExpression(@"^[+][7][0-9]{10}", ErrorMessage = "Введите телефон в формате +7ХХХХХХХХХХ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [RegularExpression(@"^[A-Za-z1-9]{6,20}$", ErrorMessage = "От 6 до 20 символов латинского алфавита и цифр")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(90, ErrorMessage = "Не больше 90 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(90, ErrorMessage = "Не больше 90 символов")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [StringLength(90, ErrorMessage = "Не больше 90 символов")]
        public string Patronym { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime BirthDate { get; set; }

        public Passenger(string phoneNumber, string password, string firstName, string secondName, string patronym, DateTime birthDate)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
            Patronym = patronym;
            BirthDate = birthDate;
        }

        public static string HashPass(string pass)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));

            return Convert.ToBase64String(hash);
        }
    }
}




