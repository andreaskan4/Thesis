using System.ComponentModel.DataAnnotations;

namespace Thesis.Components.Models
{
    public class AdminSystemSettings
    {
        [Key]
        public int Id { get; set; }
        public string AcademicYear { get; set; } = "2024-2025";
        public string GradingScale { get; set; } = "0-100";
        public bool AutoBackup { get; set; } = false;
        public string BackupFrequency { get; set; } = "weekly";
        public bool AllowStudentRegistration { get; set; } = true;
        public string DefaultUserRole { get; set; } = "Student";
        public string PasswordPolicy { get; set; } = "medium";
        public int SessionTimeout { get; set; } = 60;
        public bool EmailNotifications { get; set; } = true;
        public bool GradeAlerts { get; set; } = true;
        public bool NewUserAlerts { get; set; } = true;
        public bool MaintenanceAlerts { get; set; } = false;
        public DateTime? LastBackup { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public override bool Equals(object? obj)
        {
            if (obj is not AdminSystemSettings other) return false;
            return AcademicYear == other.AcademicYear &&
                   GradingScale == other.GradingScale &&
                   AutoBackup == other.AutoBackup &&
                   BackupFrequency == other.BackupFrequency &&
                   AllowStudentRegistration == other.AllowStudentRegistration &&
                   DefaultUserRole == other.DefaultUserRole &&
                   PasswordPolicy == other.PasswordPolicy &&
                   SessionTimeout == other.SessionTimeout &&
                   EmailNotifications == other.EmailNotifications &&
                   GradeAlerts == other.GradeAlerts &&
                   NewUserAlerts == other.NewUserAlerts &&
                   MaintenanceAlerts == other.MaintenanceAlerts;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
