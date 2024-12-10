using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using service;

namespace PokedexASP
{
    public partial class Master : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is LoginForm || Page is Error || Page is SignUpForm || Page is Home))
            {
                if (!SecurityService.sessionActive(Session["trainee"]))
                {
                    Response.Redirect("LoginForm.aspx", false);
                }
            }
            
        }
        public bool isActive()
        {
            if (SecurityService.sessionActive(Session["trainee"]))
            {
                return true;
            }
            return false;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
        }
    }
}