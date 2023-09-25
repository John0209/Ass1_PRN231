using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ResponeModel
{
	public class OrderRespone
	{
		public int OrderId { get; set; }
		public string Email { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime? RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		public decimal? Freight { get; set; }
	}
}
