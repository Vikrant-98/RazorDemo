using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPageDemoProject.Data;
using RazorPageDemoProject.Models;

namespace DemoPages.Pages.User
{
    public class UserModel : PageModel
    {

         private readonly RazorPageDemoProjectContext _context;

        private readonly ILogger<UserModel> _logger;

        [BindProperty]
        public Users Info { get; set; }

        public UserModel(RazorPageDemoProjectContext context, ILogger<UserModel> logger) 
        {
            _logger = logger;
            _context = context;
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

            var result = _context.UserCredentials.Add(Info);
            var result1 = await _context.SaveChangesAsync();

            return RedirectToPage("./LoginPage");
        }
    }
}
