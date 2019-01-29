using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Asr.Data;
using Asr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Asr.Areas.Identity.Pages.Account
{
    /*
     * Generated code through scaffolding. Added validations and codes to 
     * register user to UserManager.
     * 
     * This code is based on Matthew's Week 9 Example.   
     */  
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [RegularExpression(@"^s\d{7}@student.rmit.edu.au|e\d{5}@rmit.edu.au$",
                ErrorMessage = "Email address is not in a valid format.")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //TODO stil need to add the id of the user s1234567/e12345 to the AspNetUsers Columns StaffID and StudentID
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                //TODO Since StaffID and StudentID are foreign keys at AspNetUsers columns
                //First need to add the user registering to the Student/Staff table
                var id = Input.Email.Substring(0, Input.Email.IndexOf('@'));
                AppUser user;
                string role;

                if (id.StartsWith('e'))
                {
                    user = new AppUser { UserName = Input.Email, Email = Input.Email, Staff = staff, StaffID = id };
                    role = Constants.StaffRole;
                }
                else if (id.StartsWith('s'))
                {
                    var student = new Student { StudentID = id, Name = Input.Name, Email = Input.Email };
                    user = new AppUser { UserName = Input.Email, Email = Input.Email, Student = student, StudentID = id };
                    role = Constants.StudentRole;
                }
                else
                {
                    throw new Exception();
                }

                //var user = Input.Email.StartsWith('e') ?
                    //new AppUser { UserName = Input.Email, Email = Input.Email } ://, StaffID = id } :
                    //Input.Email.StartsWith('s') ?
                    //new AppUser { UserName = Input.Email, Email = Input.Email } ://, StudentID = id } :
                    //throw new Exception();

                //var user = new AppUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                await _userManager.AddToRoleAsync(user, role);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
