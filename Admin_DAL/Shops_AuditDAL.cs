using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Admin_Model;

namespace Admin_DAL
{
    public class Shops_AuditDAL
    {
        public List<investModel> Getinvest()
        {
            string sql = "select * from invest where investstate=0 and Udelete=0";
            List<investModel> invests = new List<investModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql) ;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    investModel model = new investModel();
                    model.investid =Convert.ToInt32(reader["investid"]);
                    model.investname = reader["investname"].ToString();
                    model.investprice = reader["investprice"].ToString();
                    model.investaddress = reader["investaddress"].ToString();
                    model.investtime =Convert.ToDateTime(reader["investtime"]);
                    model.investdelete =Convert.ToInt32(reader["investdelete"]);
                    model.investshow =Convert.ToInt32(reader["investshow"]);
                    model.investcontent = reader["investcontent"].ToString();
                    model.investProjectContent = reader["investProjectContent"].ToString();
                    model.investLogo = reader["investLogo"].ToString();
                    model.investweb = reader["investweb"].ToString();
                    model.uid =Convert.ToInt32(reader["uid"]);
                    model.investstate =Convert.ToInt32(reader["investstate"]);
                    model.Udelete = Convert.ToInt32(reader["Udelete"]);
                    invests.Add(model);
                }
                reader.Close();
            }
            return invests;
        }

        public List< UserpigflyModel> Getdetails(int investid)
        {
            string sql = $"select*from invest i,userpigfly u where i.uid=u.uid and investid=@investid";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@investid",investid)                                                                                            
            };
            List<UserpigflyModel> listModel = new List<UserpigflyModel>();
           
            SqlDataReader reader = SQLHelper.ExecuteReader(sql,sqlParameters);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserpigflyModel model = new UserpigflyModel();
                    model.username = reader["username"].ToString();
                    model.usex = Convert.ToInt32(reader["usex"]);
                    model.uphone = reader["uphone"].ToString();
                    model.uaddress = reader["uaddress"].ToString();
                    model.uimg = reader["uimg"].ToString();
                    model.uemail = reader["uemail"].ToString();
                    model.investid = Convert.ToInt32(reader["investid"]);
                    model.investname = reader["investname"].ToString();
                    model.investprice = reader["investprice"].ToString();
                    model.investaddress = reader["investaddress"].ToString();
                    model.investtime = Convert.ToDateTime(reader["investtime"]);
                    model.investdelete = Convert.ToInt32(reader["investdelete"]);
                    model.investshow = Convert.ToInt32(reader["investshow"]);
                    model.investcontent = reader["investcontent"].ToString();
                    model.investProjectContent = reader["investProjectContent"].ToString();
                    model.investLogo = reader["investLogo"].ToString();
                    model.investweb = reader["investweb"].ToString();
                    model.uid = Convert.ToInt32(reader["uid"]);
                    model.investstate = Convert.ToInt32(reader["investstate"]);
                    model.Udelete = Convert.ToInt32(reader["Udelete"]);
                    listModel.Add(model);
                }
            }
            return listModel;
        }

        public int UpDelete(int investid,int mid)
        {
            string sql = "update invest set Udelete=1,mid=@mid where investid=@investid";
            SqlParameter[] sqlParameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@investid",investid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql,sqlParameters);
            return count;
        }
        public int UpInveststate(int investid, int mid)
        {
            string sql = "update invest set investstate=1,mid=@mid where investid=@investid";
            SqlParameter[] sqlParameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@investid",investid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql, sqlParameters);
            return count;
        }
        public int UpRefuse(int investid, int mid)
        {
            string sql = "update invest set investstate=3,mid=@mid where investid=@investid";
            SqlParameter[] sqlParameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@investid",investid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql, sqlParameters);
            return count;
        }
        //统计未查询
       
    }
}
