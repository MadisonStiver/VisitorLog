using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitorLog.Models;

namespace VisitorLog.Data
{
    public class VisitorLogContext : DbContext
    {
        public VisitorLogContext (DbContextOptions<VisitorLogContext> options)
            : base(options)
        {
        }

        public DbSet<VisitorLog.Models.Visit> Visit { get; set; }
    }
}
