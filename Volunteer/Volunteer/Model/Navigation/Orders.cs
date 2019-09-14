using System;
using System.Collections.Generic;
using System.Text;

namespace Volunteer.Model.Navigation
{
   public class Orders
    {
        public int ApplicationOrganizationID { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public string AdditionalInformation { get; set; }
        public string NecessarySkills { get; set; }
    }
}
