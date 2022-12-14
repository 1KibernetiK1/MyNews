using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Controllers
{
	public class AdminController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}
		public IActionResult Index()
		{
            var model = userManager.Users.ToList()
                                         .Select(s => new AdminViewModel(s));


            return View(model);
        }

	

		public IActionResult Create()
		{
			AdminViewModel model = new AdminViewModel();
			ViewBag.Roles = new List<string> { "Administrator", "Redactor", "Moderator" };
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(AdminViewModel model)
		{
			if (ModelState.IsValid)
			{
				var manager = new IdentityUser
				{
					UserName = model.Email,
					Email = model.Email,
					EmailConfirmed = true
				};

				IdentityResult userResult = userManager.CreateAsync(manager, model.Password).Result;

				if (userResult.Succeeded)
				{
					userResult = userManager.AddToRoleAsync(manager, model.Role).Result;
				}
				return RedirectToAction("Index");
			}
			else
			{
				return View(model);
			}

		}

		public IActionResult Edit(string id)
		{
			IdentityUser user = userManager.FindByIdAsync(id).Result;
			if (user == null)
			{
				return NotFound();
			}
			IdentityRole role = roleManager.FindByIdAsync(id).Result;
			AdminViewModel model = new AdminViewModel { Id = user.Id, Email = user.Email, Password = user.PasswordHash, Role = role.Name };
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(AdminViewModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityRole role = roleManager.FindByIdAsync(model.Id).Result;
				IdentityUser user = userManager.FindByIdAsync(model.Id).Result;
				if (user != null)
				{
					user.Email = model.Email;
					user.UserName = model.Email;
					user.PasswordHash = model.Password;
					role.Name = model.Role;

					var result = userManager.UpdateAsync(user);
					result = roleManager.UpdateAsync(role);

					return RedirectToAction("Index");

				}
			}
			return View(model);
		}

		public IActionResult Delete(string id)
		{
			IdentityUser user = userManager.FindByIdAsync(id).Result;
			if (user != null)
			{
				IdentityResult result = userManager.DeleteAsync(user).Result;
			}
			return RedirectToAction("Index");


		}
	}
}
