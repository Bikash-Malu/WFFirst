<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WFFirst.Home" %>
<%@ Register TagPrefix="uc" TagName="MyUserControl" Src="~/MyUserControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow-lg" style="width: 25rem;">
            <div class="card-header text-center">
                <h3>Login</h3>
            </div>
            <div class="card-body">
                <h5 class="card-title text-center">Enter your credentials</h5>
                <div class="mb-3">
                    <label for="txtUsername" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" CssClass="text-danger" ErrorMessage="Username is required" Display="Dynamic" />
                </div>
                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="Password is required" Display="Dynamic" />
                </div>
                <div class="mb-3">
                      <div>
                    <h3> File Upload:</h3>
                        <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br /><br />
                    <asp:Button ID="btnsave" runat="server" onclick="btnsave_Click" CausesValidation="false"  Text="Save" style="width:85px" />
         <br /><br />
         <asp:Label ID="lblmessage" runat="server" />
      </div>
                </div>
                       <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger d-block text-center" Visible="False"></asp:Label>
                <div>
<asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
    <asp:ListItem Value="-1" Selected="True">Select one</asp:ListItem>
    <asp:ListItem Value="1">1</asp:ListItem>
    <asp:ListItem Value="2">2</asp:ListItem>
    <asp:ListItem Value="3">3</asp:ListItem>
</asp:DropDownList>

<br />
<asp:Label ID="lblSelectedValue" runat="server" ForeColor="Blue"></asp:Label>


                </div>
                   <div class="container mt-5">
        <h2>ASP.NET User Control Example</h2>
        <uc:MyUserControl ID="UserControl1" runat="server" />
    </div>
                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click"  />
                </div>
            </div>
            <div class="card-footer text-center">
                <small>Don't have an account? <a href="Register.aspx">Sign up</a></small>
            </div>
        </div>
    </div>
</asp:Content>
