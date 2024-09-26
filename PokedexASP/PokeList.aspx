<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokeList.aspx.cs" Inherits="PokedexASP.PokeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pokemon List:</h1>
    <asp:GridView runat="server" ID="dgvPokemon" CssClass="table table-dark" AutoGenerateColumns="false" DataKeyNames="Id" OnRowEditing="dgvPokemon_RowEditing" OnRowDeleting="dgvPokemon_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Number" HeaderText="Number" />
            <asp:BoundField DataField="Type" HeaderText="Element" />
            <asp:TemplateField HeaderText="Active">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="cbActive" Checked='<%# Bind("Active") %>' OnCheckedChanged="cbActive_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" EditText="✏️" ShowEditButton="true" HeaderText="Modify" ControlStyle-CssClass="btn btn-dark" />
            <asp:CommandField ButtonType="Button" DeleteText="🗑️" ShowDeleteButton="true" HeaderText="Delete" ControlStyle-CssClass="btn btn-dark" />
        </Columns>
    </asp:GridView>
    <div class="row d-flex justify-content-between mb-3">
        <a class="col-2 btn btn-dark" href="/PokeForm.aspx">Add</a>
        <%if (ConfirmDelete)
            {%>
        <div class="col-4">
            <asp:CheckBox Text="Are you sure you want to delete this Pokemon?" ID="cbxConfirmDelete" runat="server" />
            <asp:Button ID="btnConfirmDelete" OnClick="btnConfirmDelete_Click" class="btn btn-danger" Text="Delete" runat="server" />
        </div>
        <% 
            }
        %>
    </div>
</asp:Content>
