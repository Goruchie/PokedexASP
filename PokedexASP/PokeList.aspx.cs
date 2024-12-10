using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using service;

namespace PokedexASP
{
    public partial class PokeList : System.Web.UI.Page
    {
        public bool ConfirmDelete { get; set; }
        public int DeleteId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityService.isAdmin(Session["trainee"]))
            {
                Session.Add("error", "Access denied, you are not allowed to access this feature");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
            {
                ConfirmDelete = false;
                loadList();
            }
        }

        public void loadList()
        {
            PokeServices service = new PokeServices();
            //dgvPokemon.DataSource = service.listIsActiveRequired(true);
            Session.Add("list", service.listIsActiveRequired(true));
            dgvPokemon.DataSource = Session["list"];
            dgvPokemon.DataBind();
        }

        protected void dgvPokemon_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = (int)dgvPokemon.DataKeys[e.NewEditIndex].Value;
            Response.Redirect("PokeForm.aspx?Id=" + id);
        }

        protected void dgvPokemon_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DeleteId = (int)dgvPokemon.DataKeys[e.RowIndex].Value;
            ViewState["DeleteId"] = DeleteId;
            ConfirmDelete = true;
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            if (cbxConfirmDelete.Checked)
            {
                if (ViewState["DeleteId"] != null)
                {
                    PokeServices service = new PokeServices();
                    DeleteId = (int)ViewState["DeleteId"];
                    service.delete(DeleteId);
                }
            }
            Response.Redirect("PokeList.aspx");
        }

        protected void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)cb.NamingContainer;
            int id = Convert.ToInt32(dgvPokemon.DataKeys[row.RowIndex].Value);
            PokeServices service = new PokeServices();
            service.deleteLogically(id, cb.Checked);
        }

        protected void txtFilter_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> list = (List<Pokemon>)Session["list"];
            List<Pokemon> listf = list.FindAll(x => x.Name.ToUpper().Contains(txtFilter.Text.ToUpper()));
            dgvPokemon.DataSource = listf;
            dgvPokemon.DataBind();
        }
        public void criteriaItems()
        {
            if (ddlField.SelectedValue == "Number")
            {
                ddlCriteria.Items.Add("Equal to");
                ddlCriteria.Items.Add("Bigger than");
                ddlCriteria.Items.Add("Less than");
            }
            else
            {
                ddlCriteria.Items.Add("Contains");
                ddlCriteria.Items.Add("Starts with");
                ddlCriteria.Items.Add("Ends with");
            }
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriteria.Items.Clear();
            criteriaItems();
        }

        protected void ckbFilter_CheckedChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            ddlCriteria.Items.Clear();
            criteriaItems();
            if (!ckbFilter.Checked)
            {
                txtFilter.Enabled = true;
                loadList();
            }
            else
                txtFilter.Enabled = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PokeServices pokeServices = new PokeServices();
            dgvPokemon.DataSource = pokeServices.filter(
                ddlField.SelectedItem.ToString(),
                ddlCriteria.SelectedItem.ToString(),
                txtAdFilter.Text,
                ddlState.SelectedItem.ToString());
            dgvPokemon.DataBind();
        }
    }
}