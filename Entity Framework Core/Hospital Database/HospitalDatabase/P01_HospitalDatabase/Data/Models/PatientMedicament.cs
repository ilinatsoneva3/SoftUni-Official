namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PatientMedicament
    {      

        [Required]
        public int PatientId { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        [Required]
        public int MedicamentId { get; set; }

        [Required]
        public virtual Medicament Medicament { get; set; } 
    }
}
