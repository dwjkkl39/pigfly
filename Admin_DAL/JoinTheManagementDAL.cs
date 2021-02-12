using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_Model;
using System.Data;
using System.Data.SqlClient;

namespace Admin_DAL
{
    public class JoinTheManagementDAL
    {
        //查询以发布的加盟信息
        public List<JoininforModel> joininfors()
        {
            string sql = "select*from joininfor WHERE Jdelete is null";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<JoininforModel> joininfors = new List<JoininforModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    JoininforModel model = new JoininforModel();
                    model.JId = Convert.ToInt32(reader["JId"]);
                    model.Jname = reader["Jname"].ToString();
                    model.Jprice = reader["Jprice"].ToString();
                    model.Jperson = Convert.ToInt32(reader["Jperson"]);
                    model.Jclassification = reader["Jclassification"].ToString();
                    model.Jtime = Convert.ToDateTime(reader["Jtime"]);
                    model.JToapplyfor = Convert.ToInt32(reader["JToapplyfor"]);
                    model.Jshow = Convert.ToInt32(reader["Jshow"]);
                    joininfors.Add(model);
                }
                reader.Close();
            }
            return joininfors;
        }

        //是否在前台展示
        public int Disable(int Jshow,int JId) 
        {
            string sql = "UPDATE dbo.joininfor SET Jshow=@Jshow WHERE JId=@JId";
            SqlParameter[] parameters = { 
            new SqlParameter("@Jshow",Jshow),
            new SqlParameter("@JId",JId)
            };
            int count = SQLHelper.ExecuteNonQuery(sql,parameters);
            return count;
        }

        //删除  管理员删除
        public int Joindelete(int Jdelete, int JId)
        {
            string sql = "UPDATE dbo.joininfor SET Jdelete=@Jdelete WHERE JId=@JId";
            SqlParameter[] parameters = {
            new SqlParameter("@Jdelete",Jdelete),
            new SqlParameter("@JId",JId)
            };
            int count = SQLHelper.ExecuteNonQuery(sql, parameters);
            return count;
        }

        //查询
        public List<JoininforModel> Thequery(string Jname)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT  * FROM dbo.joininfor WHERE Jdelete IS NULL ");
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> Wherelist = new List<string>();
            if (!string.IsNullOrWhiteSpace(Jname))
            {
                Wherelist.Add("Jname=@Jname");
                parameters.Add(new SqlParameter("@Jname", Jname));
            }
            if (Wherelist.Count > 0)
            {
                string pj = string.Join(" and ", Wherelist.ToArray());
                stringBuilder.Append($" and {pj}");
            }
            SqlDataReader reader = SQLHelper.ExecuteReader(stringBuilder.ToString(),parameters.ToArray());
            List<JoininforModel> joininfors = new List<JoininforModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    JoininforModel model = new JoininforModel();
                    model.JId = Convert.ToInt32(reader["JId"]);
                    model.Jname = reader["Jname"].ToString();
                    model.Jprice = reader["Jprice"].ToString();
                    model.Jperson = Convert.ToInt32(reader["Jperson"]);
                    model.Jclassification = reader["Jclassification"].ToString();
                    model.Jtime = Convert.ToDateTime(reader["Jtime"]);
                    model.JToapplyfor = Convert.ToInt32(reader["JToapplyfor"]);
                    model.Jshow = Convert.ToInt32(reader["Jshow"]);
                    joininfors.Add(model);
                }
                reader.Close();
            }
            return joininfors;
        }

        //添加加盟项目
        public int Addjoininfor(JoininforModel model)
        {
            string sql = "insert into joininfor values(@Jname,@Jprice,@Jperson,@Jother,0,getdate(),@mId,'河南郑州',@Jintroduce,@Jsquare,@Jclassification,0,null,@Jlogo)";
            SqlParameter[] Parameters = {
            new SqlParameter("@Jname",model.Jname),
            new SqlParameter("@Jprice",model.Jprice),
            new SqlParameter("@Jperson",model.Jperson),
            new SqlParameter("@Jother",model.Jother),
            new SqlParameter("@mId",model.mId),
            new SqlParameter("@Jintroduce",model.Jintroduce),
            new SqlParameter("@Jsquare",model.Jsquare),
            new SqlParameter("@Jclassification",model.Jclassification),
            new SqlParameter("@Jlogo",model.Jlogo)
            };
            int count = SQLHelper.ExecuteNonQuery(sql, Parameters);
            return count;
        }
    }
}
