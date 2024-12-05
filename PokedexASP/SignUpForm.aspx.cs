using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using service;

namespace PokedexASP
{
    public partial class SignUpForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeService traineeService = new TraineeService();
            EmailService emailService = new EmailService();

            trainee.Email = txtEmail.Text;
            trainee.Pass = txtPass.Text;
            int id = traineeService.insertNew(trainee);
            emailService.setEmail(trainee.Email, "Correito nuevo", "hola bro, felicidades, te registaste wachin!");
            emailService.sendEmail();
            Response.Redirect("Home.aspx", false);
        }
    }
}