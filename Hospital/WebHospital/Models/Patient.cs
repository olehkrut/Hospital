using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHospital
{
    public class Patient : Person
    {
        public string Disease { get; set; }
        //foreing key
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public override string ToString()
        {
            string info = string.Format("ID = {0}, First Name = {1}, Last Name = {2}, Disease = {3}",
                                    Id, FirstName, LastName, Disease);
            return info;
        }
    }
}
