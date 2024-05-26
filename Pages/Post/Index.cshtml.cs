using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using portifolio_web_site.Data;
using portifolio_web_site.Models;

namespace portifolio_web_site.Pages.Post
{
    public class IndexModel : PageModel
    {
        private readonly portifolio_web_site.Data.portifolio_web_siteContext _context;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public IndexModel(portifolio_web_site.Data.portifolio_web_siteContext context)
        {
            _context = context;
        }

        public IList<PostModel> PostModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            int pageSize = 6;
            int totalPosts = await _context.PostModel.CountAsync();

            PostModel =  await _context.PostModel
                                .OrderBy(p => p.DateCreate)
                                .Skip((CurrentPage - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            TotalPages = (int)Math.Ceiling((double)totalPosts / pageSize);
        }
    }
}
