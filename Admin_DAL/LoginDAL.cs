using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Admin_Model;

namespace Admin_DAL
{
 public  class LoginDAL
    {
        public administatorsModel Login(string Name, string Pwd)
        {
            string sql = "select *from administators where midName=@Name and  mpassword=@pwd and State=0";
            SqlParameter[] parameters =
                {
                new SqlParameter ("@Name",Name),
                new SqlParameter ("@pwd",Pwd),
                };

            administatorsModel model = new administatorsModel();
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql, parameters);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    model.midName = sdr["midName"].ToString();
                    model.mpassword = sdr["mpassword"].ToString();
                    model.mid = Convert.ToInt32(sdr["mid"]);
                }
            }
            return model;
        }


    }
}
