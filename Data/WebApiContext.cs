using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi;

namespace WebApi.Data
{
    public class WebApiContext : DbContext
    {
        public WebApiContext (DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<WebApi.User> User { get; set; }
        public DbSet<WebApi.Message> Message { get; set; }
        public DbSet<WebApi.Chat> Chat { get; set; }
        public DbSet<WebApi.Book> Book { get; set; }
        public DbSet<WebApi.File> File { get; set; }

        public DbSet<WebApi.UserStatistics> UserStatistics { get; set; }
        public DbSet<WebApi.ChatStatistics> ChatStatistics { get; set; }
        public DbSet<WebApi.AdminStatistics> AdminStatistics { get; set; }
    }
}
