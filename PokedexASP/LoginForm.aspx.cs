using domain;
using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexASP
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeService traineeService = new TraineeService();
            try
            {
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPass.Text;
                if (traineeService.login(trainee))
                {
                    Session.Add("Trainee", trainee);
                    Response.Redirect("MyProfile.aspx", false);
                }
                else
                {
                    Session.Add("error", "User or pass incorrect");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {                                
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}