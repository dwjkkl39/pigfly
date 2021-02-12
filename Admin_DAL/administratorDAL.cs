using Admin_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_DAL
{
    public class administratorDAL
    {
        public List<administatorsModel> administators(string Name, string Addtime)
        {
            StringBuilder stringBuilder = new StringBuilder("select* from administators");
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<string> whereList = new List<string>();
            if (!string.IsNullOrWhiteSpace(Addtime)&&DateTime.TryParse(Addtime,out DateTime addtime))
            {
                whereList.Add("Addtime>@Addtime");
                sqlParameters.Add(new SqlParameter ( "@Addtime", addtime));
            }
            if (!string.IsNullOrWhiteSpace(Name))
            {
                whereList.Add("midName=@midName");
                sqlParameters.Add(new SqlParameter("@midName", Name));
            }
            if (whereList.Count>0)
            {
                string pj = string.Join(" and ", whereList.ToArray());
                stringBuilder.Append($" where {pj}");
            }

            List<administatorsModel> models = new List<administatorsModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(stringBuilder.ToString(), sqlParameters.ToArray());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    administatorsModel model = new administatorsModel();
                    model.mid = Convert.ToInt32(reader["mid"]);
                    model.midName = reader["midName"].ToString();
                    model.mpassword = reader["mpassword"].ToString();
                    model.mphone = reader["mphone"].ToString();
                    model.Addtime = Convert.ToDateTime(reader["Addtime"]);
                    model.mailbox = reader["mailbox"].ToString();
                    model.State = Convert.ToInt32(reader["State"]);
                    models.Add(model);
                }
                reader.Close();
            }
            return models;
        }
        public int insert(administatorsModel administators) 
        {
            string sql = "insert administators values(@midName,@mpassword,@mphone,getdate(),@mailbox,1,24,0)";
            SqlParameter[] parameters =
                {
            new SqlParameter ("@midName",administators.midName),
             new SqlParameter ("@mpassword",administators.mpassword),
              new SqlParameter ("@mphone",administators.mphone),
               new SqlParameter ("@mailbox",administators.mailbox)
            };
            return SQLHelper.ExecuteNonQuery(sql, parameters);
        }
        public int Deleteadministators(int mid)
        {
            string sql = $"update administators set State=1  where mid=@mid";
            SqlParameter[] sqlParameters = { new SqlParameter("@mid", mid) };
            int count = SQLHelper.ExecuteNonQuery(sql, sqlParameters);
            return count;
        }
        public int Updatedministators(int mid)
        {
            string sql = $"update administators set State=0 where mid=@mid";
            SqlParameter[] sqlParameters = { new SqlParameter("@mid", mid) };
            int count = SQLHelper.ExecuteNonQuery(sql, sqlParameters);
            return count;
        }
    }
}
