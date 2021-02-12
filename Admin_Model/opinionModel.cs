using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Model
{
    public class opinionModel: UserpigflyModel
    {
        public int opId { get; set; }
        public int opinionUid { get; set; }
        public string opContent { get; set; }
        public DateTime opTime { get; set; }
        public int opType { get; set; }
        public int opBrowsed { get; set; }
        public int opDelete { get; set; }
        public int opMid { get; set; }
    }
}
