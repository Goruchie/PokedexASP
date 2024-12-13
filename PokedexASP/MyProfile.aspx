<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="PokedexASP.MyProfileForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center mb-3">My Profile</h1>
    <div class="row">
        <div class="col-md-6 d-flex flex-column justify-content-between">
            <div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Email address</label>
                    <asp:TextBox runat="server" ID="txtEmail" runat="server" CssClass="form-control" placeholder="name@example.com" aria-label="name@example.com" />
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Name</label>
                    <asp:TextBox runat="server" ID="txtName" runat="server" CssClass="form-control" placeholder="Name" aria-label="Name" />                  
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Last name</label>
                    <asp:TextBox runat="server" ID="txtLastName" runat="server" CssClass="form-control" placeholder="Your last name" aria-label="Last Name" />   
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Birth date</label>                  
                    <input type="date" class="form-control" id="exampleFormControlInput1">
                </div>

                <div class="mb-3">
                    <label for="formFile" class="form-label">Profile Picture</label>
                    <input runat="server" class="form-control" id="formFile" type="file">
                </div>
            </div>
            <div class=" row ">
                <asp:Button ID="btnAccept" Text="Accept" runat="server" CssClass="btn btn-dark btn-lg me-2 col" />
                <a class="btn btn-dark btn-lg col" href="/PokeList.aspx">Cancel</a>
            </div>
        </div>
        <div class="col-md-6">
            <div class="text-center">
                <asp:Image ImageUrl="Assets/Images/profile.png" runat="server" CssClass="rounded img-fluid" />
            </div>
        </div>

    </div>


</asp:Content>
