using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_Model;
using System.Data.SqlClient;
namespace Admin_DAL
{
   public class ShopLIstDAL
    {
        public List<investModel> GetInvests() 
        {
            string sql = "select*from invest where investstate=1 and Udelete=0";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            List<investModel> investModels = new List<investModel>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    investModel invest = new investModel();
                    invest.investid =Convert.ToInt32( sdr["investid"]);
                    invest.investname = sdr["investname"].ToString();
                    invest.investprice = sdr["investprice"].ToString(); ;
                    invest.investaddress = sdr["investaddress"].ToString(); ;
                    invest.investtime =Convert.ToDateTime( sdr["investtime"]);
                    invest.investProjectContent = sdr["investProjectContent"].ToString(); ;
                    invest.investcontent = sdr["investcontent"].ToString();
                    investModels.Add(invest);
                }
                sdr.Close();

            }
            return investModels;


        }
        public int UpDelete(int investid, int mid)
        {
            string sql = "update invest set Udelete=1,mid=@mid where investid=@investid";
            SqlParameter[] sqlParameters = {
            new SqlParameter("@mid",mid),
            new SqlParameter("@investid",investid)
            };
            int count = SQLHelper.ExecuteNonQuery(sql, sqlParameters);
            return count;
        }

        public List<investModel> QueryInvests(string investname,string investprice,string investcontent,string Investtime)
        {
            StringBuilder sql =new StringBuilder("select*from invest where investstate=1 and Udelete=0 ");
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<string> wherelist = new List<string>();
            if (!string.IsNullOrWhiteSpace(investname))
            {
                wherelist.Add("investname=@investname");
                sqlParameters.Add(new SqlParameter("@investname", investname));
            }
            if (!string.IsNullOrWhiteSpace(investprice))
            {
                wherelist.Add("investprice=@investprice");
                sqlParameters.Add(new SqlParameter("@investprice", investprice));
            }
            if (!string.IsNullOrWhiteSpace(investcontent))
            {
                wherelist.Add("investcontent=@investcontent");
                sqlParameters.Add(new SqlParameter("@investcontent", investcontent));
            }
            if (!string.IsNullOrWhiteSpace(Investtime) && DateTime.TryParse(Investtime, out DateTime investtime))
            {
                wherelist.Add("Investtime>@Investtime");
                sqlParameters.Add(new SqlParameter("@investtime", investtime));
            }

            if (wherelist.Count>0)
            {
                string pj = string.Join(" and ", wherelist.ToArray());
                sql.Append($" and {pj}");
            }
            List<investModel> invests = new List<investModel>();
            SqlDataReader reader = SQLHelper.ExecuteReader(sql.ToString(), sqlParameters.ToArray());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    investModel invest = new investModel();
                    invest.investid = Convert.ToInt32(reader["investid"]);
                    invest.investname = reader["investname"].ToString();
                    invest.investprice = reader["investprice"].ToString(); ;
                    invest.investaddress = reader["investaddress"].ToString(); ;
                    invest.investtime = Convert.ToDateTime(reader["investtime"]);
                    invest.investProjectContent = reader["investProjectContent"].ToString(); ;
                    invest.investcontent = reader["investcontent"].ToString();
                    invests.Add(invest);
                }
                reader.Close();

            }
            return invests;
        }

    }
}
