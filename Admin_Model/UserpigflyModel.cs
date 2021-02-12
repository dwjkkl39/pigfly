using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Model
{
    public class UserpigflyModel:investModel
    {
        public int Uid { get; set; }
        public String username { get; set; }
        public String upassword { get; set; }
        public int usex { get; set; }
        public String uphone { get; set; }
        public String uaddress { get; set; }
        public String uimg { get; set; }
        public String uemail { get; set; }
        public int ustate { get; set; }
        public DateTime udatetime { get; set; }
    }
}
