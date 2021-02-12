using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;

namespace Admin_BLL
{
   public class HomeBLL
    {
        //多少 加盟项目
        public List<HomeModel> HomeTheuser()
        {
            HomeDAL home = new HomeDAL();
            return home.HomeTheuser();
        }


        public List<HomeModel> HomeTojoinin()
        {
            HomeDAL home = new HomeDAL();
            return home.HomeTojoinin();
        }

        public List<HomeModel> Homeinvestment()
        {
            HomeDAL home = new HomeDAL();
            return home.Homeinvestment();
        }

        public List<HomeModel> HomeThe_capital()
        {
            HomeDAL home = new HomeDAL();
            return home.HomeThe_capital();
        }

        public HomeJoininforModel HomeJoininfor()
        {
            HomeDAL home = new HomeDAL();
            return home.HomeJoininfor();
        }
        public HomeModel HomeProjectreleased()
        {
            HomeDAL home = new HomeDAL();
            return home.HomeProjectreleased();
        }


    }
}
