using CodeFirstEF.Models;
using FluentApiCodeFirst.Models.EntityConfigurations;

namespace CodeFirstExistingDB
{
    using System.Data.Entity;

    public partial class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }



        /*Some Fluent Api Methods:

            .Property()
            .IsRequired()
            .HasKey()
            .HasColumnName()
            .HasColumnType()
            .HasColumnOrder()
            .HasDatabaseGeneratedOption()
            .HasMaxLength()



        
        Relations :

        .HasMany()         .WithMany()
        .HasRequired()     .WithRequired()
        .HasOptional()     .WithOptional()
                           .WithRequiredPrinciple()
                           .WithRequiredDependent()

            .WillCascadeOnDelete()


        .Map(m => m.ToTable("TableName"))
        */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
//            base.OnModelCreating(modelBuilder);
        }


        //        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<Author>()
        //                .HasMany(e => e.Courses)
        //                .WithOptional(e => e.Author)
        //                .HasForeignKey(e => e.Author_Id);
        //
        //            modelBuilder.Entity<Course>()
        //                .HasMany(e => e.Tags)
        //                .WithMany(e => e.Courses)
        //                .Map(m => m.ToTable("TagCourses").MapLeftKey("Course_Id"));
        //        }
    }
}
