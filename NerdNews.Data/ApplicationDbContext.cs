using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NerdNews.Data.DataModels;

namespace NerdNews.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CommentHistory> CommentHistory { get; set; }
     
    }

   
}
