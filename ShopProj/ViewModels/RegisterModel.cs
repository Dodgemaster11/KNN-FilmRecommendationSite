using System.ComponentModel.DataAnnotations;

namespace ShopProj.ViewModels
{
    public class RegisterModel
    {   
        [EmailAddress]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано Имя")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Логин")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано Отчество")]
        [DataType(DataType.Text)]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указана Фамилия")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан возраст")]
        [DataType(DataType.Text)]
        public string DateOfBirth{ get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}