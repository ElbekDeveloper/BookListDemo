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
    public class DeleteModel : PageModel
    {
        private readonly RazorUI.Model.ApplicationDbContext _context;

        public DeleteModel(RazorUI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookModel BookModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookModel = await _context.BookModels.FirstOrDefaultAsync(m => m.Id == id);

            if (BookModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookModel = await _context.BookModels.FindAsync(id);

            if (BookModel != null)
            {
                _context.BookModels.Remove(BookModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
