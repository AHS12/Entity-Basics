using System.ComponentModel.DataAnnotations;

namespace CodeFirstExistingDB
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //Category Column Deleted.Migration-201810221555294_DeleteCategoryColumnFromCourseTable
        //public Category Category { get; set; }

        //date Column Deleted.Migration-201810221550446_DeleteDateColumnFromCourseTable
        // public DateTime? Date { get; set; }
        public int Level { get; set; }

        public float FullPrice { get; set; }

        public int? Author_Id { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}