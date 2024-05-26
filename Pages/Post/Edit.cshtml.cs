using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using portifolio_web_site.Data;
using portifolio_web_site.Models;

namespace portifolio_web_site.Pages.Post
{
    public class EditModel : PageModel
    {
        private readonly portifolio_web_site.Data.portifolio_web_siteContext _context;

        public EditModel(portifolio_web_site.Data.portifolio_web_siteContext context)
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

            var postmodel =  await _context.PostModel.FirstOrDefaultAsync(m => m.Id == id);
            if (postmodel == null)
            {
                return NotFound();
            }
            PostModel = postmodel;
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

            _context.Attach(PostModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostModelExists(PostModel.Id))
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

        private bool PostModelExists(int id)
        {
            return _context.PostModel.Any(e => e.Id == id);
        }
    }
}
