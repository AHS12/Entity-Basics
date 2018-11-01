using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Entity.EntityContext;
using CRUD.Model;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region Insert
            //            var course = new Course()
            //            {
            //                Name = "New Course1",
            //                Description = "New Description1",
            //                Level = 2,
            //                FullPrice = 55,
            //                AuthorId = 1
            //            };
            //
            //            context.Courses.Add(course);
            //            Console.WriteLine(context.SaveChanges() > 0 ? "Saved!" : "Failed!");


            //Second 
            //            var authorName = "Mosh Hamedani";
            //            var Author = context.Authors.Single(a => a.Name.Equals(authorName));
            //            var course1 = new Course()
            //            {
            //                Name = "New Course11",
            //                Description = "New Description11",
            //                Level = 3,
            //                FullPrice = 58,
            //                AuthorId = Author.Id
            //            };
            //
            //            context.Courses.Add(course1);
            //            Console.WriteLine(context.SaveChanges() > 0 ? "Saved!" : "Failed!");

            #endregion

            #region Update

//            var course = context.Courses.Find(10);
//            course.Name = "New Name";
//            course.Description = "Bew Description";
//            course.AuthorId = 3;
//            Console.WriteLine(context.SaveChanges() > 0 ? "Updated!" : "Failed!");

            #endregion

            #region Remove

//            var course = context.Courses.Find(10);
//            context.Courses.Remove(course);
//            Console.WriteLine(context.SaveChanges() > 0 ? "Removed!" : "Failed!");

            //without cascade delete

            var author = context.Authors.Include(a => a.Courses).Single(a => a.Id == 2);
            context.Courses.RemoveRange(author.Courses);
            context.Authors.Remove(author);
            Console.WriteLine(context.SaveChanges() > 0 ? "Removed!" : "Failed!");


            #endregion

            Console.ReadKey();
        }
    }
}
