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
    public class DetailsModel : PageModel
    {
        private readonly portifolio_web_site.Data.portifolio_web_siteContext _context;

        public DetailsModel(portifolio_web_site.Data.portifolio_web_siteContext context)
        {
            _context = context;
        }

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
    }
}
