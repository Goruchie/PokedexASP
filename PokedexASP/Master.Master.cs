using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using service;
using domain;

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
                else
                {
                    Trainee trainee = (Trainee)Session["trainee"];
                    traineeName.InnerText = trainee.Email;
                    if (!string.IsNullOrEmpty(trainee.ProfileImage))                    
                        avatarImg.ImageUrl = "~/Assets/Images/" + trainee.ProfileImage;                    
                }
            }
            if (SecurityService.sessionActive(Session["trainee"]))
                avatarImg.ImageUrl = "~/Assets/Images/" + ((Trainee)Session["trainee"]).ProfileImage;
            else
                avatarImg.ImageUrl = "Assets/Images/profile.png";


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