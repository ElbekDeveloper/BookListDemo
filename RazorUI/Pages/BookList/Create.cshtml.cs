using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorUI.Model;

namespace RazorUI.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly RazorUI.Model.ApplicationDbContext _context;

        public CreateModel(RazorUI.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookModel BookModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookModels.Add(BookModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
