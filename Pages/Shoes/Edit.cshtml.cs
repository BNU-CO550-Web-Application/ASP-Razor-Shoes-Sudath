using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Razor_Shoes.Data;
using ASP_Razor_Shoes.Models;

namespace ASP_Razor_Shoes.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly ASP_Razor_Shoes.Data.ApplicationDbContext _context;

        public EditModel(ASP_Razor_Shoes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shoe Shoe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shoe == null)
            {
                return NotFound();
            }

            var shoe =  await _context.Shoe.FirstOrDefaultAsync(m => m.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }
            Shoe = shoe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(Shoe.Id))
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

        private bool ShoeExists(int id)
        {
          return _context.Shoe.Any(e => e.Id == id);
        }
    }
}
