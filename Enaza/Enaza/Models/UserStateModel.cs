using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enaza.Models
{
	public class UserStateModel
	{
		[Key]
		public int UserStateId { get; private set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public ICollection<UserModel> Users { get; set; }
	}
}