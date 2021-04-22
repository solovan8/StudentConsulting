using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentIdentityUser> Students { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<ConsultingRequest> ConsultingRequests { get; set; }

        public DbSet<ConsultingArrange> ConsultingArranges { get; set; }

    }
}
