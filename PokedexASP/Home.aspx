<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PokedexASP.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--<%
            foreach (domain.Pokemon pokemon in PokeList)
            {
                %>
                <div class="col">
                    <div class="card">
                        <img src="<%: pokemon.UrlImage %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: pokemon.Name %></h5>
                            <p class="card-text"><%: pokemon.Description %></p>
                        </div>
                        <a href="Details.aspx?id=<%: pokemon.Id %>">Details</a>
                    </div>
                </div>
                <% 
            }
        %>--%>
        <asp:Repeater runat="server" ID="repeaterID">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImage") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Name") %></h5>
                            <p class="card-text"><%#Eval("Description") %></p>
                        </div>
                        <asp:Button Text="Details" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonID" ID="btnPokemonDetails" OnClick="btnPokemonDetails_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
