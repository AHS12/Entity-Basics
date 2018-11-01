using System;
using System.Data.Entity;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();
            //LINQ Syntax
//            var query =
//                from c in context.Courses
//                where c.Name.Contains("c#")
//                orderby c.Name
//                select c;
//
//            Console.WriteLine("Using LINQ Syntax");
//            Console.WriteLine("----------------------");
//            foreach (var temp in query)
//            {
//               
//                Console.WriteLine(temp.Name);
//                
//            }
//
//            Console.WriteLine("----------------------");

            //LINQ Extension Method

            Console.WriteLine(@"Using LINQ Extension");
            Console.WriteLine(@"----------------------");
            Console.WriteLine(@"----------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            /*Restriction
            -------------------
             .Where()

            Ordering
            -------------------
             .OrderBy()
             .OrderByDescending()
             .ThenBy()
             .ThenByDescending()
          
          
             Projection
             -------------------
                Note: we can use projection to create a sub result of the query result by using anonymous object

             .Select()
         

             Set Operator
             -------------------
             .Distinct()

            Group By
            -------------------
            Note: It is different from sql.Here we use it for dividing a list into different group
            .GroupBy() uses a key to divide list

            Joining
            -------------------
            1.Inner Join .Join()
            2.Group Join (Not Present In SQL)(close to LEFT JOIN and COUNT(*)) .GroupJoin()
            3.Cross Join .SelectMany()


            Partitioning
            ---------------------
            .Skip()
            .Take()

            Element Operator
            ---------------------
            .First()
            .FirstOrDefault()
            .Last()
            .LastOrDefault()
            .Single()
            .SingleOrDefault()

            Quantifying
            ---------------------
            .All() //returns boolean
            .Any() //returns boolean

            Aggregating
            ---------------------
            .Count()
            .Max()
            .Min()
            .Average()



             */


            var Restriction = context.Courses
                .Where(c => c.Name.Contains("c#"));

            var Ordering = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.FullPrice);


            var projection1 = context.Courses
                .Where(c => c.Level == 1)
                .Select(c => new
                {
                    CourseName = c.Name,
                    AuthorName = c.Author.Name
                });

            var projection2 = context.Courses
                .Where(c => c.Level == 1)
//                .OrderByDescending(c => c.Name)
//                .ThenByDescending(c => c.FullPrice)
                .Select(c => c.Tags);

            var projection3 = context.Courses
                .Where(c => c.Level == 1)
                .SelectMany(c => c.Tags);

            var setoperator = context.Courses
                .Where(c => c.Level == 1)
                .SelectMany(c => c.Tags)
                .Distinct();

            var groupby = context.Courses.GroupBy(c => c.Level);

            //Joining
            //we will join Course and Author Table
            var InnerJoin = context.Courses
                .Join(context.Authors,
                    c => c.AuthorId,
                    a => a.Id,
                    (course, author) => new
                    {
                        CourseName = course.Name,
                        AuthorName = author.Name
                    });

            //Group Join
            var GroupJoin = context.Authors
                .GroupJoin(
                    context.Courses,
                    a => a.Id,
                    c => c.AuthorId,
                    (author, courses) => new
                    {
                        Author = author.Name,
                        Course = courses.Count()
                    });


            //Partitioning

            var partitioning = context.Courses.OrderBy(c => c.Name).Skip(2).Take(3);

            //Element Operator
            var first = context.Courses.OrderBy(c => c.Name).FirstOrDefault(c => c.Level > 2);
            //var last = context.Courses.LastOrDefault();
            var single = context.Courses.OrderBy(c => c.Name).SingleOrDefault(c=>c.Description.Equals("Description for NodeJS"));
            var single2 = context.Courses.SingleOrDefault(c => c.Id.Equals(2));

            //Quantifying
            var AllAbove10usd = context.Courses.All(c => c.FullPrice > 10);
            var IsCourseExists = context.Courses.Any(c => c.Level > 1);

            //Aggregating
            var AllCourseCount = context.Courses.Count();
            var AllCourseCountWithCondition = context.Courses.Count(c => c.Level > 1);
            var max = context.Courses.Max(c=>c.Level);
            var min = context.Courses.Min(c => c.FullPrice);
            var avg = context.Courses.Average(c => c.FullPrice);





            //Restriction
            Console.WriteLine(@"---------Restriction-------------");
            foreach (var temp in Restriction)
            {
                Console.WriteLine(temp.Name + @" " + temp.Author.Name);
            }

            //Ordering
            Console.WriteLine(@"---------Ordering-------------");
            foreach (var temp in Ordering)
            {
                Console.WriteLine(temp.Name + @" " + temp.Author.Name);
            }

            //Projection
            Console.WriteLine(@"--------Projection-------------");
            foreach (var temp in projection1)
            {
                Console.WriteLine(temp.CourseName + @" " + temp.AuthorName);
            }


            Console.WriteLine(@"----------------------");
            foreach (var c in projection2)
            {
                foreach (var tag in c)
                {
                    Console.WriteLine(tag.Name);
                }
            }

            Console.WriteLine(@"----------------------");
            foreach (var tag in projection3)
            {
                Console.WriteLine(tag.Name);
            }

            //Set Operator
            Console.WriteLine(@"----------Set Operator------------");
            foreach (var tag in setoperator)
            {
                Console.WriteLine(tag.Name);
            }

            //Group BY
            Console.WriteLine(@"----------Group by------------");
            foreach (var group in groupby)
            {
                Console.WriteLine(@"Key(Level) : " + group.Key);
                foreach (var course in group)
                {
                    Console.WriteLine("\t" + course.Name);
                }
            }

            //Joining
            Console.WriteLine(@"----------Inner Join------------");
            foreach (var temp in InnerJoin)
            {
                Console.WriteLine(temp.CourseName + "\t" + temp.AuthorName);
            }

            Console.WriteLine(@"----------Group Join------------");
            foreach (var temp in GroupJoin)
            {
                Console.WriteLine(temp.Author + "\t" + temp.Course);
            }

            //Partitioning
            Console.WriteLine(@"----------Partitioning------------");
            foreach (var course in partitioning)
            {
                Console.WriteLine(course.Name);
            }

            //Element Operator
            Console.WriteLine(@"----------Element Operator------------");
            Console.WriteLine(first.Name);
            Console.WriteLine(single2.Name);
            Console.WriteLine(single.Name);

            //Quantifying
            Console.WriteLine(@"--------Quantifying-----------");
            Console.WriteLine(IsCourseExists ? @"Yes!!" : @"NO!!");

            if (AllAbove10usd)
            {
                Console.WriteLine(@"YES!!!");   

            }
            else
            {
                Console.WriteLine(@"NO!!");
            }

            //Aggregating
            Console.WriteLine(@"--------Aggregating-----------");
            Console.WriteLine(AllCourseCount);
            Console.WriteLine(AllCourseCountWithCondition);
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(avg);

            Console.ReadKey();
        }
    }
}