<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokeForm.aspx.cs" Inherits="PokedexASP.PokeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label class="h1 mb-5 d-flex justify-content-start display-1"><%:TypeOfPage %>Pokemon</label>
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Id:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control col" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Name:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Number:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNumber" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Type:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlType" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Weakness:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlWeakness" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Description:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label class="col-sm-2 col-form-label text-end">Url Image:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUrlImage" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <div class="col-6">

                <asp:Image CssClass="pokeImage w-100" ImageUrl="Assets/Images/empty-pokemon.png" runat="server" />
            </div>
        </div>
        <div class="d-flex justify-content-start">
            <asp:Button ID="btnAccept" Text="Accept" runat="server" CssClass="btn btn-dark btn-lg me-2" OnClick="btnAccept_Click" />
            <a class="btn btn-dark btn-lg" href="/PokeList.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>
