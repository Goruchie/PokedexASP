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
    public partial class Home : System.Web.UI.Page
    {
        public List<Pokemon> PokeList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokeServices service = new PokeServices();
            PokeList = service.listIsActiveRequired(false);
            if (!IsPostBack)
            {
            repeaterID.DataSource = PokeList;
            repeaterID.DataBind();
            }
        }

        protected void btnPokemonDetails_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("Details.aspx?id=" + id);
        }
    }
}