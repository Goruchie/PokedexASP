<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokeList.aspx.cs" Inherits="PokedexASP.PokeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1 class="text-center">Pokemon List</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row align-items-center mb-3">
                <label class="col-auto col-form-label">Filter</label>
                <div class="col-3">
                    <asp:TextBox runat="server" ID="txtFilter" AutoPostBack="true" CssClass="form-control col" OnTextChanged="txtFilter_TextChanged" />
                </div>
                <div class="col-3">
                    <asp:CheckBox CssClass="" ID="ckbFilter" Text="Advanced filter" runat="server" AutoPostBack="true" OnCheckedChanged="ckbFilter_CheckedChanged" />
                </div>
            </div>
            <%if (ckbFilter.Checked)
                {
            %>
            <div class="row align-items-center mb-3">
                <div class="col">
                    <div class="row align-items-center">
                        <label class="col-auto col-form-label">Field</label>
                        <div class="col">
                            <asp:DropDownList ID="ddlField" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" runat="server">
                                <asp:ListItem Text="Name" />
                                <asp:ListItem Text="Number" />
                                <asp:ListItem Text="Element" />
                            </asp:DropDownList>
                        </div>
                        <label class="col-auto col-form-label">Criteria</label>
                        <div class="col">
                            <asp:DropDownList ID="ddlCriteria" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <label class="col-auto col-form-label">State</label>
                        <div class="col">
                            <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Active" />
                                <asp:ListItem Text="Disabled" />
                                <asp:ListItem Text="All" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="row align-items-center justify-content-end">
                        <div class="col-auto">
                            <asp:TextBox ID="txtAdFilter" CssClass="col-2 form-control" runat="server" />
                        </div>
                        <asp:Button ID="btnSearch" class="col-auto btn btn-dark" Text="Search" runat="server" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>

            <% 
                }
            %>


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
        </ContentTemplate>
    </asp:UpdatePanel>
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
