using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Entities.Response
{
    public class MedicationResponse
    {
        public int MedicationId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public string Dosage { get; set; }
        public string Unit { get; set; }
        public string Form { get; set; }
        public string Method { get; set; }
        public string Indication { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Prescriber { get; set; }
        public string RXNumber { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class SingleMedicationResponse: BaseResponse
    {
        public MedicationResponse medication { get; set; }
    }


    public class SearchMedicationResponse
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
