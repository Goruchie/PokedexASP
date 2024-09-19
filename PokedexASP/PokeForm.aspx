<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokeForm.aspx.cs" Inherits="PokedexASP.PokeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6">
        <div class="mb-3">
            <label class="form-label">Id:</label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Number:</label>
            <asp:TextBox ID="txtNumber" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Description:</label>
            <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label class="form-label">Type:</label>
            <asp:DropDownList ID="ddlType" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>        
        <div class="mb-3">
            <label class="form-label">Weakness:</label>
            <asp:DropDownList ID="ddlWeakness" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Button ID="btnAccept" Text="Accept" runat="server" CssClass="btn btn-dark" OnClick="btnAccept_Click" />
            <a class="btn btn-dark" href="/PokeList.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>
