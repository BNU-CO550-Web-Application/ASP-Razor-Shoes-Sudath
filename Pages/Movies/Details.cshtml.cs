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
    public class DetailsModel : PageModel
    {
        private readonly ASP_Razor_Shoes.Data.ApplicationDbContext _context;

        public DetailsModel(ASP_Razor_Shoes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
