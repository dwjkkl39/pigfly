using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;

namespace Admin_BLL
{
    public class The_capitalBLL
    {
        public List<The_capitalModel> the_CapitalsList()
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.the_CapitalsList();
        }
        public List<The_capitalModel> GetTheusList(int Theid)
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.GetTheusList(Theid);
        }
        public int through(int Theid, int mid)
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.through(Theid,mid);
        }
        public int RefusedTo(int Theid, int mid)
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.through(Theid, mid);
        }
        public List<The_capitalModel> ApprovedList()
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.ApprovedList();
        }
        public int ManagementToDelete(int Theid, int mid)
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.ManagementToDelete(Theid,mid);
        }
        public List<The_capitalModel> the_Thequery(string Thename)
        {
            The_capitalDAL the_Capital = new The_capitalDAL();
            return the_Capital.the_Thequery(Thename);
        }
    }
}
