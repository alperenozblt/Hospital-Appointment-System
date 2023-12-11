using System.ComponentModel.DataAnnotations;

namespace Round1.Models
{
	public class Admin
	{
		public int AdminId { get; set; }
		[Required]
		public string AdminName { get; set; }
		[Required]
		[RegularExpression("^([A-Z0-9_.-@#$%^&()<>/?])([a-z0-9_.-@#$%^&()<>/?])([0-9])*$")]
		public string AdminPassword { get; set; }
	}
}
