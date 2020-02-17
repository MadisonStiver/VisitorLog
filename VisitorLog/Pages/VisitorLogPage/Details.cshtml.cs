using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisitorLog.Data;
using VisitorLog.Models;

namespace VisitorLog
{
    public class DetailsModel : PageModel
    {
        private readonly VisitorLog.Data.VisitorLogContext _context;

        public DetailsModel(VisitorLog.Data.VisitorLogContext context)
        {
            _context = context;
        }

        public Visit Visit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visit.FirstOrDefaultAsync(m => m.Id == id);

            if (Visit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
