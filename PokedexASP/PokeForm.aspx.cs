using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using System.Data.SqlClient;

namespace PokedexASP
{
    public partial class PokeForm : System.Web.UI.Page
    {
        public string TypeOfPage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            TypeOfPage = id == "" ? "New " : "Modify ";
            try
            {
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
                if (id != "" && !IsPostBack)
                {
                    PokeServices service = new PokeServices();
                    Pokemon selected = (service.getPokemon(int.Parse(id)))[0];
                    txtId.Text = selected.Id.ToString();
                    txtName.Text = selected.Name;
                    txtNumber.Text = selected.Number.ToString();
                    txtDescription.Text = selected.Description;
                    txtUrlImage.Text = selected.UrlImage;
                    ddlType.SelectedValue = selected.Type.Id.ToString();
                    ddlWeakness.SelectedValue = selected.Weakness.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error: ", ex);
                throw;
            }

        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
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
                if (Request.QueryString["Id"] == null)
                    service.addSP(pokemon);
                else
                {
                    pokemon.Id = int.Parse(txtId.Text);
                    service.modify(pokemon);
                }
                Response.Redirect("PokeList.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error: ", ex);
                throw;
            }
        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {
            pokeImage.ImageUrl = txtUrlImage.Text;
        }
    }
}