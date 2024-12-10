<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="PokedexASP.LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label class="h1 mb-5 d-flex justify-content-center display-1">Log in</label>
    <div class="d-flex justify-content-center">
        <div class="col-md-4">
            <div class="row mb-5">                
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" aria-label="Email"/>
            </div>
            <div class="row mb-5">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" placeholder="Password" aria-label="Password"/>
            </div>
            <div class="row mb-5">
                <asp:Button ID="btnLogin" Text="Log in" CssClass="btn btn-dark" OnClick="btnLogin_Click" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
