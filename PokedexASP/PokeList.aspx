<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokeList.aspx.cs" Inherits="PokedexASP.PokeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pokemon List:</h1>
    <asp:GridView runat="server" ID="dgvPokemon" CssClass="table table-dark" AutoGenerateColumns="false" DataKeyNames="Id" OnRowEditing="dgvPokemon_RowEditing" > 
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Number" HeaderText="Number" />
            <asp:BoundField DataField="Type" HeaderText="Element" />
            <asp:CommandField ButtonType="Button" EditText="✏️" ShowEditButton="true" HeaderText="Modify" ControlStyle-CssClass="btn btn-dark"/>
        </Columns>        
    </asp:GridView>
    <a class="btn btn-dark" href="/PokeForm.aspx">Add</a>
</asp:Content>
