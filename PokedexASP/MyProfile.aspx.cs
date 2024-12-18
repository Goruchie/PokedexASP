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
            if (!IsPostBack)
            {

            if (SecurityService.sessionActive(Session["trainee"]))
            {
                Trainee trainee = (Trainee)Session["trainee"];
                if (trainee.Date != null)
                    txtBirthDate.Text = trainee.Date.ToString("yyyy-MM-dd");
                if (trainee.Name != null)
                    txtName.Text = trainee.Name;
                if (trainee.LastName != null)
                    txtLastName.Text = trainee.LastName;
                if (trainee.Email != null)
                    txtEmail.Text = trainee.Email;
                if (!string.IsNullOrEmpty(trainee.ProfileImage))
                    profileImage.ImageUrl = "~/Assets/Images/" + trainee.ProfileImage;
            }
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeService traineeService = new TraineeService();
                Trainee trainee = (Trainee)Session["trainee"];
                if (txtImage.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Assets/Images/");
                    txtImage.PostedFile.SaveAs(ruta + "profile-" + trainee.Id + ".png");
                    trainee.ProfileImage = "profile-" + trainee.Id + ".png";
                }
                trainee.Name = txtName.Text;
                trainee.LastName = txtLastName.Text;
                trainee.Date = DateTime.Parse(txtBirthDate.Text);

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