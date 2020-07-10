namespace P01_HospitalDatabase.Data.Models
{
    using System;    
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}
