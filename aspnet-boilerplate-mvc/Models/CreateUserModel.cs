namespace aspnet_boilerplate_mvc.Models
{
	public class CreateUserModel
	{
		public string? Id { get; set; }
		public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }	

		public string Phone { get; set; }
		
		public bool Enable { get;set; }
		public string RoleId { get; set; }
	}
}
