using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email указан не верно")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не указан")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
