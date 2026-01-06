namespace Thesis.Models
{
    public class EnrollmentViewModel
    {
        public Enrollment Enrollment { get; set; } = null!;
        public Grade? ExistingGrade { get; set; }
        public double GradeValue { get; set; }
    }
}