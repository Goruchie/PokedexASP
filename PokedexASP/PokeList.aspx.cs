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
        protected void Page_Load(object sender, EventArgs e)
        {
            PokeServices service = new PokeServices();
            dgvPokemon.DataSource = service.listSP();
            dgvPokemon.DataBind();
        }

        protected void dgvPokemon_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = (int)dgvPokemon.DataKeys[e.NewEditIndex].Value;
            Response.Redirect("PokeForm.aspx?Id=" + id);
        }
    }
}