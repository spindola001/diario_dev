using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using portifolio_web_site.Data;
using portifolio_web_site.Models;

namespace portifolio_web_site.Pages.Post
{
    public class CreateModel : PageModel
    {
        private readonly portifolio_web_site.Data.portifolio_web_siteContext _context;

        public CreateModel(portifolio_web_site.Data.portifolio_web_siteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PostModel PostModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PostModel.Add(PostModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
