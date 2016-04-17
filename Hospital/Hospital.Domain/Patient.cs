namespace Hospital.Domain
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
