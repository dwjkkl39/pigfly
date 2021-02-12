using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_Model;
using System.Data.SqlClient;
namespace Admin_DAL
{
   public class UserListDAL
    {

        public   List<UserpigflyModel> GetUser(string UserName, string dateTimeReg) 
        {
            StringBuilder sql =new StringBuilder ("select*from userpigfly where uisdelete=0");
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> whereList = new List<string>();
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                whereList.Add("UserName=@UserName");
                parameters.Add(new SqlParameter ("@UserName", UserName));
            }

            if (!string.IsNullOrWhiteSpace(dateTimeReg))
            {
                whereList.Add("udatetime<@dateTimeReg");
                parameters.Add(new SqlParameter("@dateTimeReg", dateTimeReg));
            }
            if (whereList.Count > 0)
            {
                string pj = string.Join(" and ", whereList.ToArray());
                sql.Append($" and  {pj}");
            }
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql.ToString(), parameters.ToArray());
            List<UserpigflyModel> userpigflyModels = new List<UserpigflyModel>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    UserpigflyModel userpigfly = new UserpigflyModel();
                    userpigfly.username = sdr["username"].ToString();
                    userpigfly.upassword = sdr["upassword"].ToString();
                    userpigfly.usex = Convert.ToInt32(sdr["usex"]);
                    userpigfly.uphone = sdr["uphone"].ToString();
                    userpigfly.uaddress = sdr["uaddress"].ToString();
                    userpigfly.uimg = sdr["uimg"].ToString();
                    userpigfly.Uid = Convert.ToInt32(sdr["uid"]);
                    userpigfly.ustate = Convert.ToInt32(sdr["ustate"]);
                    userpigfly.uemail = sdr["uemail"].ToString();
                    userpigfly.udatetime =Convert.ToDateTime( sdr["udatetime"].ToString());
                   
                    userpigflyModels.Add(userpigfly);
                }
                sdr.Close();
            }
            return userpigflyModels;
        }
        public int delete(int Id) 
        {
            string sql = $"UPDATE userpigfly SET uisdelete=1 WHERE uid={Id}";
            return SQLHelper.ExecuteNonQuery(sql);
        }
    }
}
