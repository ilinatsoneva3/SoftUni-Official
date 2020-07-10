﻿namespace P01_HospitalDatabase.Data.Models
{    
    using System.ComponentModel.DataAnnotations;
    

    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        [Required]
        public int PatientId { get; set; }
        
        [Required]
        public Patient Patient { get; set; }
    }
}
