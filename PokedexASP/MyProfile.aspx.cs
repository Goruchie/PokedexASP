using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;

namespace PokedexASP
{
    public partial class MyProfileForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeService traineeService = new TraineeService();
                string ruta = Server.MapPath("./Assets/Images/");
                Trainee trainee = (Trainee)Session["trainee"];
                txtImage.PostedFile.SaveAs(ruta + "profile-" + trainee.Id + ".jpg");
                trainee.ProfileImage = "profile-" + trainee.Id + ".jpg";
                traineeService.update(trainee);
                Image img = (Image)Master.FindControl("avatarImg");
                img.ImageUrl = "~/Images/Assets/" + trainee.ProfileImage;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
            

        }
    }
}