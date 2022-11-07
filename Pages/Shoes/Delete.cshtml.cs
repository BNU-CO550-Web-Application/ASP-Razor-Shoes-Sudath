using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_Razor_Shoes.Data;
using ASP_Razor_Shoes.Models;

namespace ASP_Razor_Shoes.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly ASP_Razor_Shoes.Data.ApplicationDbContext _context;

        public DeleteModel(ASP_Razor_Shoes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shoe == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.FirstOrDefaultAsync(m => m.Id == id);

            if (shoe == null)
            {
                return NotFound();
            }
            else 
            {
                Shoe = shoe;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shoe == null)
            {
                return NotFound();
            }
            var shoe = await _context.Shoe.FindAsync(id);

            if (shoe != null)
            {
                Shoe = shoe;
                _context.Shoe.Remove(Shoe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
