using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Model
{
    public class LoginHistoryModel
    {
		public int Id { get; set; }
		public int Uid { get; set; }
		public string Type { get; set; }
		public string Adderss { get; set; }
		public string UserName { get; set; }
		public DateTime CheckTime { get; set; }
	}
}
