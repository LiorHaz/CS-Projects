using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project
{
    public class ComboBoxOptions
    {

        public List<String> Speciality { get; set; }
        public List<String> TherapyType { get; set; }
        public List<String> Payment { get; set; }
        public List<int> Rate { get; set; }
        public List<string> Region { set; get; }
        public ComboBoxOptions()
        {
            Speciality = new List<string>
            {
                "Masseur", "Holistic Therapist","Reflexologist","Manager"
            };
            TherapyType = new List<string>
            {
                "Medical Massage","Hot Stones Massage","Swedish Massage","Thai Massage","Shiatsu","Acupuncture"
            };
            Payment = new List<string>
            {
                "Isracard","Diners","Cash","Visa"
            };
            Rate = new List<int>
            {
                1,2,3,4,5,6,7,8,9,10
            };
            Region = new List<string>
            {
                "North","South","Center"
            };
        }




    }
}
