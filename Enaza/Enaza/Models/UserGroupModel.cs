using System.ComponentModel.DataAnnotations;

namespace Enaza.Models
{
	public class UserGroupModel
	{
		[Key]
		public int UserGroupId { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
	}
}