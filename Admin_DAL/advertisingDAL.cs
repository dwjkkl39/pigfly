using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_Model;
namespace Admin_DAL
{
   public class advertisingDAL
    {

        public List<advertisingModel> Getadvertising()
        {
            string sql = "select*from advertise ";
           
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<advertisingModel> The_capital = new List<advertisingModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    advertisingModel model = new advertisingModel();
                    model.aid = Convert.ToInt32(reader["aid"]);
                    model.aimg = reader["aimg"].ToString();
                    model.aname = reader["aname"].ToString();
                    model.ashow = reader["ashow"].ToString();
                    model.sbefore = Convert.ToInt32(reader["sbefore"]);
                    model.mid =Convert.ToInt32( reader["mid"]);
                 
                    The_capital.Add(model);
                }
                reader.Close();

            }
            return The_capital;
        }

        public int Update(int Id,int sbefore) 
        {
            string sql = $"UPDATE  advertise SET sbefore={sbefore} WHERE aid={Id}";
            return SQLHelper.ExecuteNonQuery(sql);
        }
        public int delete(int Id)
        {
            string sql = $"DELETE FROM advertise WHERE aid={Id}";
            return SQLHelper.ExecuteNonQuery(sql);
        }
    }
}
