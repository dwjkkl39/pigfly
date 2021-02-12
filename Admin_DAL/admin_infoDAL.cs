using Admin_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_DAL
{
    public class admin_infoDAL
    {
        public administatorsModel  QuerymidName(string midName)
        {
            StringBuilder stringBuilder = new StringBuilder("select* from administators");
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<string> whereList = new List<string>();

            if (!string.IsNullOrWhiteSpace(midName))
            {
                whereList.Add("midName=@midName");
                sqlParameters.Add(new SqlParameter("@midName", midName));
            }
            if (whereList.Count > 0)
            {
                string pj = string.Join(" and ", whereList.ToArray());
                stringBuilder.Append($" where {pj}");
            }

            administatorsModel model = new administatorsModel();
            SqlDataReader reader = SQLHelper.ExecuteReader(stringBuilder.ToString(), sqlParameters.ToArray());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   
                    model.mid = Convert.ToInt32(reader["mid"]);
                    model.midName = reader["midName"].ToString();
                    model.mpassword = reader["mpassword"].ToString();
                    model.mphone = reader["mphone"].ToString();
                    model.Addtime = Convert.ToDateTime(reader["Addtime"]);
                    model.mailbox = reader["mailbox"].ToString();
                    model.State = Convert.ToInt32(reader["State"]);
                    model.Age = Convert.ToInt32(reader["Age"]);
                    model.Sex = Convert.ToInt32(reader["Sex"]);
             
                }
                reader.Close();
            }
            return model;
        }
        public int Updateadministators(administatorsModel administators,string SessionName)
        {
            string sql = @"update administators set midName=@midName,mphone=@mphone,mailbox=@mailbox,Age=@Age,Sex=@Sex where midName=@SessionName";
            SqlParameter[] parmt = { new SqlParameter("@midName", administators.midName),
            new SqlParameter("@mphone", administators.mphone),
            new SqlParameter("@mailbox", administators.mailbox),
            new SqlParameter("@Age", administators.Age),
             new SqlParameter("@Sex", administators.Sex),
             new SqlParameter("@SessionName",SessionName)
            };
            return Convert.ToInt32(SQLHelper.ExecuteNonQuery(sql, parmt));
        }
    }
}