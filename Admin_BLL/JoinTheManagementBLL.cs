using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;

namespace Admin_BLL
{
    public class JoinTheManagementBLL
    {
        //查询以发布的加盟信息
        public List<JoininforModel> joininfors()
        {
            JoinTheManagementDAL joinThe = new JoinTheManagementDAL();
            return joinThe.joininfors();
        }

        //是否在前台展示
        public int Disable(int Jshow, int JId)
        {
            JoinTheManagementDAL joinThe = new JoinTheManagementDAL();
            return joinThe.Disable(Jshow,JId);
        }

        //记录管理员删除
        public int Joindelete(int Jdelete, int JId)
        {
            JoinTheManagementDAL joinThe = new JoinTheManagementDAL();
            return joinThe.Joindelete(Jdelete, JId);
        }
        //查询
        public List<JoininforModel> Thequery(string Jname)
        {
            JoinTheManagementDAL joinThe = new JoinTheManagementDAL();
            return joinThe.Thequery(Jname);
        }
        //添加加盟项目
        public int Addjoininfor(JoininforModel model)
        {
            JoinTheManagementDAL joinThe = new JoinTheManagementDAL();
            return joinThe.Addjoininfor(model);
        }
    }
}
