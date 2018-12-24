using Microsoft.EntityFrameworkCore;
using Patient_Demographics_Infrastructure.Entities;
using System;
using System.Collections.Generic;

using System.Text;

namespace Patient_Demographics_Infrastructure.Repositories
{
    public class PatientEFContext : DbContext
    {
        public PatientEFContext(DbContextOptions<PatientEFContext> options) : base(options)
        {
        }
        public DbSet<Patients> Patients { get; set; }
    }
}




