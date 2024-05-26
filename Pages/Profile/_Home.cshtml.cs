using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using portifolio_web_site.Data;
using portifolio_web_site.Models;

namespace portifolio_web_site.Pages.Profile
{
    public class _HomeModel : PageModel
    {

        public IActionResult OnGetPartial() => Partial("_Home");

        private readonly portifolio_web_site.Data.portifolio_web_siteContext _context;

        public _HomeModel(portifolio_web_site.Data.portifolio_web_siteContext context)
        {
            _context = context;
        }

        public IList<ProfileModel> ProfileModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProfileModel != null)
            {
                ProfileModel = await _context.ProfileModel.ToListAsync();
            }
        }
    }
}
