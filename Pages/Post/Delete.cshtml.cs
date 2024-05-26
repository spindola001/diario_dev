using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using portifolio_web_site.Data;
using portifolio_web_site.Models;

namespace portifolio_web_site.Pages.Post
{
    public class DeleteModel : PageModel
    {
        private readonly portifolio_web_site.Data.portifolio_web_siteContext _context;

        public DeleteModel(portifolio_web_site.Data.portifolio_web_siteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PostModel PostModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postmodel = await _context.PostModel.FirstOrDefaultAsync(m => m.Id == id);

            if (postmodel == null)
            {
                return NotFound();
            }
            else
            {
                PostModel = postmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postmodel = await _context.PostModel.FindAsync(id);
            if (postmodel != null)
            {
                PostModel = postmodel;
                _context.PostModel.Remove(PostModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
