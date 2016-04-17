namespace Hospital.Domain.Entities
{
	public abstract class Person
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName 
		{
			get
			{
				return  FirstName + " " + LastName;
			}
		}
	}
}
