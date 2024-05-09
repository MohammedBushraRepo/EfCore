using EfCore.Configration;
using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore
{

    internal class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optons)=>
        
            optons.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EfCore;Integrated Security=True;");



        //** How to Use Fluent Api from the dbContext File 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //** how to use fluent api 
            modelBuilder.Entity<Blog>()
                 .Property(m => m.Url)
                 .IsRequired();


            //** Apply the fluent Api from External Class

            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());

            //  OR
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);

            //###***** Add new table to the db without adding  A DB Set using the fluent api
            modelBuilder.Entity<AuditEntry>();

            //********* how to ignore using fluent Api
            modelBuilder.Ignore<Post>();

            //****** to exclude table from migration
            modelBuilder.Entity<Blog>().ToTable("Blog", b => b.ExcludeFromMigrations());


            //***** How to change Table Name Using fluent Api
            modelBuilder.Entity<Post>().ToTable("Posts");

            //****************8How to Add change Schema Using Fluent API
            modelBuilder.Entity<Post>().ToTable("Posting", schema: "Posting");



            //***************How to Add View From the dataBase through the fluent API
            modelBuilder.Entity<Post>().ToView("Select", schema: "Blogging");

            //*********To Make it As Default Schema
            modelBuilder.HasDefaultSchema("Posting");

            //***************To Exclude Property from the migration Using Fluent Api
            modelBuilder.Entity<Blog>().Ignore(b => b.Date);


            //***********To Change Property Name Using Fluent Api
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .HasColumnName("BlogURL");



            //********how to  change Data Type Using Fluent Api
            modelBuilder.Entity<Blog>()
                .Property(b => b.rating)
                .HasColumnType("decimal(50)");



            //***********how to  change Multible Data Types Using Fluent Api
            modelBuilder.Entity<Blog>(b =>
                {
                    b.Property(b => b.Url).HasColumnType("varchar200");
                    b.Property(b => b.rating).HasColumnType("decimal(50)");
                });


            //********How to Apply the Maxlength Using th ew Fluent Api
            modelBuilder.Entity<Blog>().
                Property(b => b.Url)
                .HasMaxLength(500);

            // *******How to Add Comment to the property using the Fluent Api
            modelBuilder.Entity<Blog>()
                .Property(b => b.rating)
                .HasComment("this is the rating of the blog");



            //*******How to Add Primary Key To A table using  the Fluent APi
            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookKey);

            //*******How to Add Primary Key Name To A table using  the Fluent APi
            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookKey)
                .HasName("pk_bookId");

            //********How to Add Composite Primary Key
            modelBuilder.Entity<Book>()
                .HasKey(b => new { b.BookKey, b.Name });



            //***** hOW TO ADD Default value to the field using fluent api
            modelBuilder.Entity<Blog>()
                .Property(b => b.rating)
                .HasDefaultValue(2);

            //***** hOW TO ADD Default value to Sql Query on the field using fluent api
            modelBuilder.Entity<Blog>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("GetDate()");



            //****** How to Add computed coulumn to the DataBase using  Fluent Api
            modelBuilder.Entity<Author>()
                .Property(b => b.DisplayName)
                .HasComputedColumnSql("[LastName]+', '+[FirstName]");



            //******* How to Add PK Default values using fluent Api
            modelBuilder.Entity<Category>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();






        }


        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
