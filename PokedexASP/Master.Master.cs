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
            if (!(Page is LoginForm || Page is Error))
            {
                if (!SecurityService.sessionActive(Session["trainee"]))
                {
                    Response.Redirect("LoginForm.aspx", false);
                }
            }
        }
    }
}