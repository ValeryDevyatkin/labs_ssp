using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ssp2.Models;

namespace ssp2.Controllers
{
    public class WorkerContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
    }
}