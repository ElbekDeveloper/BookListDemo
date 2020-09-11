using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorUI.Model;

namespace RazorUI.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly RazorUI.Model.ApplicationDbContext _context;

        public IndexModel(RazorUI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BookModel> BookModel { get;set; }

        public async Task OnGetAsync()
        {
            BookModel = await _context.BookModels.ToListAsync();
        }
    }
}
