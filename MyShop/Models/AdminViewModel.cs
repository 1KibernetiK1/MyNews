using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyShop.Models
{
	public class AdminViewModel
	{
		[HiddenInput(DisplayValue = false)]
		public string Id { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Пароль")]
		[Required(ErrorMessage = "Укажите пароль")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

		[Display(Name = "Роль")]
		[Required(ErrorMessage = "Выберите роль")]
		public string Role { get; set; }

		public AdminViewModel()
		{

		}

		public AdminViewModel(IdentityUser identityUser)
		{
			Id = identityUser.Id;
			Email = identityUser.Email;
			Password = identityUser.PasswordHash;
		}
	}
}
