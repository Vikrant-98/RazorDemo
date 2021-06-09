using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationDB;
using DemoPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DemoPages.Pages.User
{
    public class UserModel : PageModel
    {
        private readonly Application _app;

        private readonly ILogger<UserModel> _logger;

        [BindProperty]
        public UserInfo Info { get; set; }

        public UserModel(Application app, ILogger<UserModel> logger) 
        {
            _logger = logger;
            _app = app;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            if (ModelState.IsValid == false) 
            {
                return Page();
            }
            _logger.LogInformation("Info " + JsonSerializer.Serialize(Info) + "");

            var result = _app.Users.Add(Info);
            var result1 = await _app.SaveChangesAsync();

            return Redirect("../Index");
        }
    }
}
