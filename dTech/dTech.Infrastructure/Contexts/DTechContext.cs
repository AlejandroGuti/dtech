using dTech.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dTech.Infrastructure.Contexts
{
    public class DTechContext: IdentityDbContext<User>
    {
        public DTechContext(DbContextOptions<DTechContext> options) :
            base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<PTask> PTasks { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
