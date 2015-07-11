using System.Data.Entity;
using Webmo.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace Webmo
{
    public class WebmoContext : DbContext
    {
        public WebmoContext() : base()
        {
        }

        virtual public DbSet<Article> Articles { get; set; }
        virtual public DbSet<Comment> Comments {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.Add(new ContextConfiguration());
        }

    }
}