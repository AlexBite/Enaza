using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enaza.Models
{
	public class UserStateModel
	{
		[Key]
		public int UserStateId { get; private set; }

		[Column(TypeName = "nvarchar(max)")]
		public UserState Code { get; set; }

		public string Description { get; set; }
		public ICollection<UserModel> Users { get; set; }
	}
}