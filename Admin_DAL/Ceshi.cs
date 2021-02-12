using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Admin_DAL
{
    public class Ceshi
    {
        public List<CeshiModel> Listceshi()
        {
            string sql = "select*from ImgUrl WHERE Id=2";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<CeshiModel> ceshis = new List<CeshiModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CeshiModel model = new CeshiModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.length = reader["length"].ToString();
                    ceshis.Add(model);
                }
                reader.Close();
            }
            return ceshis;
        }

        public int Addseshi(string length)
        {
            string sql = "INSERT INTO ImgUrl VALUES(@length)";
            SqlParameter[] parameters = {
            new SqlParameter("@length",length)
            };
            return SQLHelper.ExecuteNonQuery(sql,parameters);
        }
    }
}
