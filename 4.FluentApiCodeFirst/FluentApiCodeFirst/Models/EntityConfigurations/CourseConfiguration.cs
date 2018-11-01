using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Models;

namespace FluentApiCodeFirst.Models.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {

            /*Some Fluent Api Methods:
         ---------------------------------

            .ToTable()
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

        /*

            Configuration Sorting Style:
          -----------------------------------
           1. Table Configuration
           2. key Configuration
           3. Property Configuration
           4. RelationShip Configuration 
           
        */


            //Table Configuration
            ToTable("tbl_Courses");

            //key Configuration
            HasKey(c => c.Id);


            //Property Configuration
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);


            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);


            //RelationShip Configuration
            HasRequired(c => c.Author)
                .WithMany(c => c.Courses)
                .HasForeignKey(a => a.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m => m.ToTable("CourseTags").MapLeftKey("CourseId").MapRightKey("TagId"));

           
        }
    }
}