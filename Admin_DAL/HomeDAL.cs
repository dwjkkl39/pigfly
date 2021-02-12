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
     public class HomeDAL
    {
        //多少用户
        public List<HomeModel> HomeTheuser()
        {
            string sql = "SELECT COUNT(*)uid  FROM userpigfly where isdelete=0";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<HomeModel> homes = new List<HomeModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HomeModel model = new HomeModel();
                    model.uid = Convert.ToInt32(reader["uid"]);
                    homes.Add(model);
                }
                reader.Close();
            }
            return homes;
        }

        //多少加盟项目
        public List<HomeModel> HomeTojoinin()
        {
            string sql = "SELECT COUNT(*)JId  FROM joininfor WHERE Jdelete IS NULL";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<HomeModel> homes = new List<HomeModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HomeModel model = new HomeModel();
                    model.JId = Convert.ToInt32(reader["JId"]);
                    homes.Add(model);
                }
                reader.Close();
            }
            return homes;
        }

        //多少投资项目
        public List<HomeModel> Homeinvestment()
        {
            string sql = "SELECT COUNT(*)investid  FROM invest WHERE investdelete=0 AND Udelete=0";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<HomeModel> homes = new List<HomeModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HomeModel model = new HomeModel();
                    model.investid = Convert.ToInt32(reader["investid"]);
                    homes.Add(model);
                }
                reader.Close();
            }
            return homes;
        }

        //引资项目项目
        public List<HomeModel> HomeThe_capital()
        {
            string sql = "SELECT COUNT(*)Theid  FROM The_capital WHERE Thedelete=0 AND Tdelete=0";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            List<HomeModel> homes = new List<HomeModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HomeModel model = new HomeModel();
                    model.Theid = Convert.ToInt32(reader["Theid"]);
                    homes.Add(model);
                }
                reader.Close();
            }
            return homes;
        }


        //加盟信息汇总
        public HomeJoininforModel HomeJoininfor()
        {
            string sql = "SELECT  COUNT(1) AS Toapply FROM dbo.addjoin;";
            string sql1 = "SELECT COUNT(1)uid FROM dbo.joininfor;";
            string sql2= "SELECT COUNT(1) AS Jiadelete  FROM dbo.joininfor WHERE Jdelete IS NOT NULL";
            string sql3 = "SELECT  COUNT(1) AS Hasbeenback FROM dbo.addjoin WHERE Ire=1";
            string sql4 = "SELECT  COUNT(1) AS Notreturn FROM dbo.addjoin WHERE Ire=0";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            SqlDataReader reader1 = SQLHelper.ExecuteReader(sql1);
            SqlDataReader reader2 = SQLHelper.ExecuteReader(sql2);
            SqlDataReader reader3 = SQLHelper.ExecuteReader(sql3);
            SqlDataReader reader4 = SQLHelper.ExecuteReader(sql4);
            HomeJoininforModel model = new HomeJoininforModel();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                      model.Toapply = Convert.ToInt32(reader["Toapply"]);
                }
                reader.Close();
            }
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    model.uid = Convert.ToInt32(reader1["uid"]);
                }
                reader1.Close();
            }

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    model.Jiadelete = Convert.ToInt32(reader2["Jiadelete"]);
                }
                reader2.Close();
            }

            if (reader3.HasRows)
            {
                while (reader3.Read())
                {
                    model.Hasbeenback = Convert.ToInt32(reader3["Hasbeenback"]);
                }
                reader3.Close();
            }

            if (reader4.HasRows)
            {
                while (reader4.Read())
                {
                    model.Notreturn = Convert.ToInt32(reader4["Notreturn"]);
                }
                reader4.Close();
            }


            return model;
        }


        //引资项目汇总
        public HomeModel HomeProjectreleased()
        {
            HomeModel model = new HomeModel();
            //共有数据
            string sql = "SELECT COUNT(1)AS Count FROM dbo.The_capital";
            string sql1 = "SELECT COUNT(1)AS JiaDelete FROM dbo.The_capital WHERE Thedelete=1 OR Tdelete=1";
            string sql2 = "SELECT COUNT(1)AS Show FROM dbo.The_capital WHERE Thedelete=0 and Tdelete=0";
            string sql3 = "SELECT COUNT(1)AS Successful FROM dbo.The_capital WHERE Thestate=1";
            string sql4 = "SELECT COUNT(1)AS Toaudit FROM dbo.The_capital WHERE Thestate=0 AND Thedelete=0 AND Tdelete=0";
            string sql5 = "SELECT COUNT(1)AS Count1 FROM dbo.invest";
            string sql6 = "SELECT COUNT(1)AS JiaDelete1 FROM dbo.invest WHERE investdelete=1 OR Udelete=1";
            string sql7 = "SELECT COUNT(1)AS Show1 FROM dbo.invest WHERE investstate=1 AND investdelete=0 and Udelete=0";
            string sql8 = "SELECT COUNT(1)AS Successful1 FROM dbo.invest WHERE investstate=1 ";
            string sql9 = "SELECT COUNT(1)AS Toaudit1 FROM dbo.invest WHERE investstate=0 AND investdelete=0 AND Udelete=0";

            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            SqlDataReader reader1 = SQLHelper.ExecuteReader(sql1);
            SqlDataReader reader2 = SQLHelper.ExecuteReader(sql2);
            SqlDataReader reader3 = SQLHelper.ExecuteReader(sql3);
            SqlDataReader reader4 = SQLHelper.ExecuteReader(sql4);
            SqlDataReader reader5 = SQLHelper.ExecuteReader(sql5);
            SqlDataReader reader6 = SQLHelper.ExecuteReader(sql6);
            SqlDataReader reader7 = SQLHelper.ExecuteReader(sql7);
            SqlDataReader reader8 = SQLHelper.ExecuteReader(sql8);
            SqlDataReader reader9 = SQLHelper.ExecuteReader(sql9);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model.Count = Convert.ToInt32(reader["Count"]);
                }
                reader.Close();
            }
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    model.JiaDelete = Convert.ToInt32(reader1["JiaDelete"]);
                }
                reader1.Close();
            }
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    model.Show = Convert.ToInt32(reader2["Show"]);
                }
                reader2.Close();
            }
            if (reader3.HasRows)
            {
                while (reader3.Read())
                {
                    model.Successful = Convert.ToInt32(reader3["Successful"]);
                }
                reader3.Close();
            }
            if (reader4.HasRows)
            {
                while (reader4.Read())
                {
                    model.Toaudit = Convert.ToInt32(reader4["Toaudit"]);
                }
                reader4.Close();
            }
            if (reader5.HasRows)
            {
                while (reader5.Read())
                {
                    model.Count1 = Convert.ToInt32(reader5["Count1"]);
                }
                reader5.Close();
            }
            if (reader6.HasRows)
            {
                while (reader6.Read())
                {
                    model.JiaDelete1 = Convert.ToInt32(reader6["JiaDelete1"]);
                }
                reader6.Close();
            }
            if (reader7.HasRows)
            {
                while (reader7.Read())
                {
                    model.Show1 = Convert.ToInt32(reader7["Show1"]);
                }
                reader7.Close();
            }
            if (reader8.HasRows)
            {
                while (reader8.Read())
                {
                    model.Successful1 = Convert.ToInt32(reader8["Successful1"]);
                }
                reader8.Close();
            }
            if (reader9.HasRows)
            {
                while (reader9.Read())
                {
                    model.Toaudit1 = Convert.ToInt32(reader9["Toaudit1"]);
                }
                reader9.Close();
            }
            return model;

        }

    }
}
