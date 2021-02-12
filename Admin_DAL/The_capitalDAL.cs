using Admin_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_DAL
{
    public class The_capitalDAL
    {
        //查询全部
        public List<The_capitalModel> the_CapitalsList()
        {
            string sql = "select*from The_capital where Thedelete=0 and Thestate=0 and Tdelete=0";
           
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<The_capitalModel> The_capital = new List<The_capitalModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    The_capitalModel model = new The_capitalModel();
                    model.Theid = Convert.ToInt32(reader["Theid"]);
                    model.Thename = reader["Thename"].ToString();
                    model.Thecontent = reader["Thecontent"].ToString();
                    model.Theprice = reader["Theprice"].ToString();
                    model.TheProject = reader["TheProject"].ToString();
                    model.Thetime = Convert.ToDateTime(reader["Thetime"]);
                    model.Thestate = Convert.ToInt32(reader["Thestate"]);
                    The_capital.Add(model);
                }
                reader.Close();

            }
            return The_capital;
        }
        //详情
        public List<The_capitalModel> GetTheusList(int Theid)
        {
            string sql = "SELECT*FROM The_capital,userpigfly WHERE userpigfly.uid=dbo.The_capital.Theuid AND Theid=@Theid";
            SqlParameter[] parameters = { 
            new SqlParameter("@Theid",Theid)
            };
            List<The_capitalModel> Capitals = new List<The_capitalModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql,parameters);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    The_capitalModel model = new The_capitalModel();
                    model.username = reader["username"].ToString();
                    model.usex = Convert.ToInt32(reader["usex"]);
                    model.uphone = reader["uphone"].ToString();
                    model.uimg = reader["uimg"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.Thename = reader["Thename"].ToString();
                    model.Thecontent = reader["Thecontent"].ToString();
                    model.Thetime = Convert.ToDateTime(reader["Thetime"]);
                    model.Thestate = Convert.ToInt32(reader["Thestate"]);
                    model.TheProjectContent = reader["TheProjectContent"].ToString();
                    Capitals.Add(model);
                }
                reader.Close();
            }
            return Capitals;
        }
        //审核通过
        public int through(int Theid,int mid)
        {
            String sql = "UPDATE dbo.The_capital SET Thestate=1,Themid=@mid WHERE Theid=@Theid";
            SqlParameter[] parameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@Theid",Theid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql,parameters);
            return count;
        }
        //拒绝通过
        public int RefusedTo(int Theid, int mid)
        {
            string sql = "UPDATE dbo.The_capital SET Thestate=2,Themid=@mid WHERE Theid=@Theid";
            SqlParameter[] parameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@Theid",Theid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql, parameters);
            return count;
        }
        //查询审核通过的
        public List<The_capitalModel> ApprovedList()
        {
            string sql = "SELECT*FROM The_capital WHERE Thedelete=0 AND Thestate=1 AND Tdelete=0";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<The_capitalModel> thes = new List<The_capitalModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    The_capitalModel model = new The_capitalModel();
                    model.Theid = Convert.ToInt32(reader["Theid"]);
                    model.Thename = reader["Thename"].ToString();
                    model.Theprice = reader["Theprice"].ToString();
                    model.Theaddress = reader["Theaddress"].ToString();
                    model.Thetime = Convert.ToDateTime(reader["Thetime"]);
                    model.Thecontent = reader["Thecontent"].ToString();
                    model.TheProjectContent = reader["TheProjectContent"].ToString();
                    thes.Add(model);
                }
                reader.Close();
            }
            return thes;
        }
        //删除
        public int ManagementToDelete(int Theid, int mid)
        {
            string sql = "UPDATE dbo.The_capital SET Themid=@mid,Tdelete=1 WHERE Theid=@Theid";
            SqlParameter[] parameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@Theid",Theid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql,parameters);
            return count;
        }
        //查询
        public List<The_capitalModel> the_Thequery( string Thename)
        {
            string sql =string.Format("select*from The_capital where Thedelete=0 and Thestate=0 and Tdelete=0 and Thename ='{0}'",Thename);

            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<The_capitalModel> The_capital = new List<The_capitalModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    The_capitalModel model = new The_capitalModel();
                    model.Theid = Convert.ToInt32(reader["Theid"]);
                    model.Thename = reader["Thename"].ToString();
                    model.Thecontent = reader["Thecontent"].ToString();
                    model.Theprice = reader["Theprice"].ToString();
                    model.TheProject = reader["TheProject"].ToString();
                    model.Thetime = Convert.ToDateTime(reader["Thetime"]);
                    model.Thestate = Convert.ToInt32(reader["Thestate"]);
                    The_capital.Add(model);
                }
                reader.Close();

            }
            return The_capital;
        }


    }
}
