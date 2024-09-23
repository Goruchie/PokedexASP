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

            txtId.Enabled = false;
            if (!IsPostBack)
            {
                ElementServices service = new ElementServices();
                List<Element> list = service.list();
                ddlType.DataSource = list;
                ddlType.DataValueField = "Id";
                ddlType.DataTextField = "Description";
                ddlType.DataBind();
                ddlWeakness.DataSource = list;
                ddlWeakness.DataValueField = "Id";
                ddlWeakness.DataTextField = "Description";
                ddlWeakness.DataBind();
            }
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            PokeServices service = new PokeServices();
            Pokemon pokemon = new Pokemon();
            pokemon.Name = txtName.Text;
            pokemon.Number = int.Parse(txtNumber.Text);
            pokemon.Description = txtDescription.Text;
            pokemon.UrlImage = txtUrlImage.Text;
            pokemon.Weakness = new Element();
            pokemon.Weakness.Id = int.Parse(ddlWeakness.SelectedValue);
            pokemon.Type = new Element();
            pokemon.Type.Id = int.Parse(ddlType.SelectedValue);
            service.addSP(pokemon);
            Response.Redirect("PokeList.aspx", false);            
        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {
            pokeImage.ImageUrl = txtUrlImage.Text;
        }
    }
}