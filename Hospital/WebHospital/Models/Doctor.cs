using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHospital
{
    public class Doctor : Person
    {
        public string Qualification { get; set; }
        public virtual IList<Patient> Patients { get; set; }
        public Doctor()
        {
            Patients = new List<Patient>();
        }
        public override string ToString()
        {
            string info = string.Format("ID = {0}, First Name = {1}, Last Name = {2}, Qualification = {3}", 
                                Id, FirstName, LastName, Qualification);
            return info;
        }
    }
}
