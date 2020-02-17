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
    public class IndexModel : PageModel
    {
        private readonly VisitorLog.Data.VisitorLogContext _context;

        public IndexModel(VisitorLog.Data.VisitorLogContext context)
        {
            _context = context;
        }

        public IList<Visit> Visit { get;set; }

        public async Task OnGetAsync()
        {
            Visit = await _context.Visit.ToListAsync();
        }
    }
}
