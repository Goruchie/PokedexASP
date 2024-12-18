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
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="name@example.com" aria-label="name@example.com" />
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Name</label>
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Name" aria-label="Name" />                  
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Last name</label>
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Your last name" aria-label="Last Name" />   
                </div>
                <div class="mb-3">
                    <label class="form-label">Birth date</label>                  
                    <asp:TextBox ID="txtBirthDate" runat="server" TextMode="Date"/>
                </div>

                <div class="mb-3">
                    <label for="formFile" class="form-label">Profile Picture</label>
                    <input type="file" id="txtImage" runat="server" class="form-control" />
                </div>
            </div>
            <div class=" row ">
                <asp:Button ID="btnSave" Text="Save" runat="server" CssClass="btn btn-dark btn-lg me-2 col" OnClick="btnSave_Click" />
                <a class="btn btn-dark btn-lg col" href="/PokeList.aspx">Cancel</a>
            </div>
        </div>
        <div class="col-md-6">
            <div class="text-center">
                <asp:Image ID="profileImage" ImageUrl="Assets/Images/profile.png" runat="server" CssClass="rounded img-fluid" />
            </div>
        </div>

    </div>


</asp:Content>
