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
    public class IndexModel : PageModel
    {
        private readonly ASP_Razor_Shoes.Data.ApplicationDbContext _context;

        public IndexModel(ASP_Razor_Shoes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Shoe> Shoe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Shoe != null)
            {
                Shoe = await _context.Shoe.ToListAsync();
            }
        }
    }
}
