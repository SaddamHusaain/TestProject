using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalHealthCare.Entities.Response
{
    public class MedicationListResponse : BaseResponse
    {
        public List<MedicationResponse> MedicationList { get; set; }
    }

    public class SearchMedicationListResponse : BaseResponse
    {
        public List<SearchMedicationResponse> SearchMedicationList { get; set; }
    }
}
