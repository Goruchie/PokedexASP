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
                    <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com">
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Name</label>
                    <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="Your name">
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Last name</label>
                    <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="Your last name">
                </div>
                <div class="mb-3">
                    <label for="exampleFormControlInput1" class="form-label">Birth date</label>
                    <input type="date" class="form-control" id="exampleFormControlInput1">
                </div>

                <div class="mb-3">
                    <label for="formFile" class="form-label">Profile Picture</label>
                    <input class="form-control" id="formFile" type="file">
                </div>
            </div>
            <div class=" row ">
                <asp:Button ID="btnAccept" Text="Accept" runat="server" CssClass="btn btn-dark btn-lg me-2 col" />
                <a class="btn btn-dark btn-lg col" href="/PokeList.aspx">Cancel</a>
            </div>
        </div>
        <div class="col-md-6">
            <div class="text-center">
                <img src="Assets/Images/profile.png" class="rounded img-fluid" alt="Profile Picture" style="max-width: 100%; height: auto; max-height: 100%;">
            </div>
        </div>

    </div>


</asp:Content>
