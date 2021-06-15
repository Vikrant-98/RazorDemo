using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoProject.Data;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public IndexModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Club Clubh { get; set; }
        public string Session { get; set; }
        public IList<Club> Club { get;set; }
        public string Username { get; set; }
        public List<City> City { get; set; }
        public List<State> State { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Session = HttpContext.Session.GetString("username");
            if(Session != null)
            {
                Username = HttpContext.Session.GetString("username");
                Club = await _context.Club.ToListAsync();
                State = await _context.State.ToListAsync();
                return Page();
            }
            return RedirectToPage("./LoginPage");
        }

        public async Task OnGetCity(int id) 
        {
            City = await _context.City.Where(m => m.StateId == id).ToListAsync();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Club.Add(Clubh);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
