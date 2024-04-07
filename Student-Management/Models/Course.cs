using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Student_Management.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public long Credit { get; set; }

        [Required]
        [ForeignKey("Department")]
        public long DepartmentId { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Status { get; set; }

        [Required]
        [ForeignKey("Classroom")]
        public long ClassroomId { get; set; }

        [Required]
        public long ClassSize { get; set; }

        [Required]
        [StringLength(255)]
        public string CourseCode { get; set; }
    }
}
