namespace KeyboardHub.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeyboardHubDB : DbContext
    {
        public KeyboardHubDB()
            : base("name=KeyboardHubDB")
        {
        }

        public virtual DbSet<Switch> Switches { get; set; }
        //public virtual DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
