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
    public class FeedbackDAL
    {
        public List<opinionModel> OpinionsList()
        {
            string sql = "SELECT * FROM opinion,userpigfly WHERE userpigfly.uid=dbo.opinion.opinionUid AND opDelete=0";
            List<opinionModel> opinions = new List<opinionModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    opinionModel model = new opinionModel();
                    model.opId = Convert.ToInt32(reader["opId"]);
                    model.username = reader["username"].ToString();
                    model.uphone = reader["uphone"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.opContent = reader["opContent"].ToString();
                    model.opTime = Convert.ToDateTime(reader["opTime"]);
                    model.opBrowsed = Convert.ToInt32(reader["opBrowsed"]);
                    model.opType = Convert.ToInt32(reader["opType"]);
                    opinions.Add(model);
                }
                reader.Close();
            }
            return opinions;
        }
        //已回复
        public List<opinionModel> Havetoreply()
        {
            string sql = "SELECT * FROM opinion,userpigfly WHERE userpigfly.uid=dbo.opinion.opinionUid AND opDelete=0 AND opBrowsed=1";
            List<opinionModel> opinions = new List<opinionModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    opinionModel model = new opinionModel();
                    model.opId = Convert.ToInt32(reader["opId"]);
                    model.username = reader["username"].ToString();
                    model.uphone = reader["uphone"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.opContent = reader["opContent"].ToString();
                    model.opTime = Convert.ToDateTime(reader["opTime"]);
                    model.opBrowsed = Convert.ToInt32(reader["opBrowsed"]);
                    model.opType = Convert.ToInt32(reader["opType"]);
                    opinions.Add(model);
                }
                reader.Close();
            }
            return opinions;
        }
        //未回复
        public List<opinionModel> Didnotreturn()
        {
            string sql = "SELECT * FROM opinion,userpigfly WHERE userpigfly.uid=dbo.opinion.opinionUid AND opDelete=0 AND opBrowsed=0";
            List<opinionModel> opinions = new List<opinionModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    opinionModel model = new opinionModel();
                    model.opId = Convert.ToInt32(reader["opId"]);
                    model.username = reader["username"].ToString();
                    model.uphone = reader["uphone"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.opContent = reader["opContent"].ToString();
                    model.opTime = Convert.ToDateTime(reader["opTime"]);
                    model.opBrowsed = Convert.ToInt32(reader["opBrowsed"]);
                    model.opType = Convert.ToInt32(reader["opType"]);
                    opinions.Add(model);
                }
                reader.Close();
            }
            return opinions;
        }

        //投诉
        public List<opinionModel> Complaints(int opBrowsed,int opType)
        {
            StringBuilder stringBuilder = new StringBuilder("SELECT * FROM opinion,userpigfly WHERE userpigfly.uid=dbo.opinion.opinionUid AND opDelete=0 AND ");
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> Wherelist = new List<string>();
            Wherelist.Add("opBrowsed=@opBrowsed");
            parameters.Add(new SqlParameter("@opBrowsed",opBrowsed));
            Wherelist.Add("opType=@opType");
            parameters.Add(new SqlParameter("@opType", opType));
            if (Wherelist.Count>0)
            {
                string pj = string.Join(" and ", Wherelist.ToArray());
                stringBuilder.Append(pj);
            }
            List<opinionModel> opinions = new List<opinionModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(stringBuilder.ToString(),parameters.ToArray());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    opinionModel model = new opinionModel();
                    model.opId = Convert.ToInt32(reader["opId"]);
                    model.username = reader["username"].ToString();
                    model.uphone = reader["uphone"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.opContent = reader["opContent"].ToString();
                    model.opTime = Convert.ToDateTime(reader["opTime"]);
                    model.opBrowsed = Convert.ToInt32(reader["opBrowsed"]);
                    model.opType = Convert.ToInt32(reader["opType"]);
                    opinions.Add(model);
                }
                reader.Close();
            }
            return opinions;
        }

        //查询  未完善
        public List<opinionModel> Thequery(string opContent)
        {
            string sql = "SELECT * FROM opinion,userpigfly WHERE userpigfly.uid=dbo.opinion.opinionUid AND opDelete=0";
            if (!string.IsNullOrWhiteSpace(opContent))
            {
                sql += " and opContent like'%"+ opContent + "%'";
            }
            List<opinionModel> opinions = new List<opinionModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    opinionModel model = new opinionModel();
                    model.opId = Convert.ToInt32(reader["opId"]);
                    model.username = reader["username"].ToString();
                    model.uphone = reader["uphone"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.opContent = reader["opContent"].ToString();
                    model.opTime = Convert.ToDateTime(reader["opTime"]);
                    model.opBrowsed = Convert.ToInt32(reader["opBrowsed"]);
                    model.opType = Convert.ToInt32(reader["opType"]);
                    opinions.Add(model);
                }
                reader.Close();
            }
            return opinions;
        }
        //删除
        public int DeleteFeedback(int opId,int mid)
        {
            string sql = "UPDATE dbo.opinion SET opDelete=1,opMid=@mid WHERE opId=@opId";
            SqlParameter[] parameters = {
            new SqlParameter("@mid",mid),
             new SqlParameter("@opId",opId),
            };
            int count = SQLHelper.ExecuteNonQuery(sql,parameters);
            return count;
        }
    }
}
