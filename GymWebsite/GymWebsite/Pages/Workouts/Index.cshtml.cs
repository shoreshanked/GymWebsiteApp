﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Data;
using GymWebsite.Model;
using Microsoft.AspNetCore.Authorization;

namespace GymWebsite.Pages.Workouts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GymWebsite.Data.GymWebsiteContext _context;

        public IndexModel(GymWebsite.Data.GymWebsiteContext context)
        {
            _context = context;
        }

        public IList<Workout> Workout { get;set; }

        public async Task OnGetAsync(int? id)
        {

            if (id != null)
            {
                Workout = await _context.Workout
                                .Include(e => e.TrainingBlock)
                                .Where(w => w.TrainingBlockID == id)
                                .ToListAsync();
            }
            else
            {
                Workout = await _context.Workout
                                .Include(e => e.TrainingBlock).ToListAsync();
            }
        }

    }
}
