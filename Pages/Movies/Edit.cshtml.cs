using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoProject.Data;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public EditModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Club Club { get; set; }
        public string Session { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Session = HttpContext.Session.GetString("username");
            if (Session != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Club = await _context.Club.FirstOrDefaultAsync(m => m.ID == id);

                if (Club == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return RedirectToPage("./LoginPage");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Club.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Club.Any(e => e.ID == id);
        }
    }
}
