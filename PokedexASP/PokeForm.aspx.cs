using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexASP
{
    public partial class PokeForm : System.Web.UI.Page
    {
        public string TypeOfPage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Id"] == null)
            {
                TypeOfPage = "New ";
            }
            else
            {
                TypeOfPage = "Modify ";
            }
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}