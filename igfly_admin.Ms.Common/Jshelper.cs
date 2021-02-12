using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace pigfly_admin.Ms.Common
{
  
        public static class JSHelper
        {
            public static void Alert(Page page, string msg)
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "", $"alert('{msg}')", true);
            }
            public static void Alert(Page page, string msg, string href)
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "", $"alert('{msg}');location.href='{href}'", true);
            }
        }
    
}
