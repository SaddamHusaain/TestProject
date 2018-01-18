using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Entities.Request
{
    public class MedicationRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public string Unit { get; set; }
        public string Form { get; set; }
        public string Method { get; set; }
        public string Indication { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Prescriber { get; set; }
        public string RXNumber { get; set; }
        public Boolean? Active { get; set; }
        public string Notes { get; set; }
    }
}
