using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;
using Microsoft.AspNetCore.Authorization;

namespace GymWebsite.Pages.TrainingBlocks
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public IndexModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public IList<TrainingBlock> TrainingBlock { get;set; }

        public async Task OnGetAsync()
        {
            TrainingBlock = await _context.TrainingBlock
                .Include(t => t.User).ToListAsync();
        }
    }
}
