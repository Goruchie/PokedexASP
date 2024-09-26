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
    public partial class PokeList : System.Web.UI.Page
    {
        public bool ConfirmDelete { get; set; }
        public int DeleteId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            ConfirmDelete = false;
            PokeServices service = new PokeServices();
            dgvPokemon.DataSource = service.listIsActiveRequired(true);
            dgvPokemon.DataBind();            
            }
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
    }
}