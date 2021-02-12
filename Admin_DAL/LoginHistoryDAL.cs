using Admin_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_DAL
{
    public class LoginHistoryDAL
    {
        public int insert(int Id, string Name, string IP)
        {

            string sql = "insert into LoginHistory values(@Id,'登录成功',@Adderss,@MindName,getdate()) ";
            SqlParameter[] parameters =
                      {
               new SqlParameter ("@Id",Id),
               new SqlParameter ("@Adderss",IP),
               new SqlParameter ("@MindName",Name)
            };
            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }

        public List<LoginHistoryModel> SelectLogin()
        {

            string sql = "select *from LoginHistory ORDER BY CheckTime desc";
            List<LoginHistoryModel> loginHistories = new List<LoginHistoryModel>();
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    LoginHistoryModel login = new LoginHistoryModel();
                    login.Adderss = sdr["Adderss"].ToString();
                    login.CheckTime = Convert.ToDateTime(sdr["CheckTime"]);
                    login.Type = sdr["Type"].ToString();
                    login.UserName = sdr["UserName"].ToString(); ;
                    login.Uid = Convert.ToInt32(sdr["Uid"]);
                    loginHistories.Add(login);
                }
                sdr.Close();
            }
            return loginHistories;
        }
    }
}
