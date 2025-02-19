<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyUserControl.ascx.cs" Inherits="WFFirst.MyUserControl" %>
<div class="p-3 border rounded">
    <h4>User Control Example</h4>
    <asp:Label ID="lblMessage" runat="server" Text="Welcome to User Control!" CssClass="text-primary" EnableViewState="true"></asp:Label>
    <br /><br />
    <asp:TextBox ID="txtInput" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="btnShowMessage" runat="server" Text="Show Message" CssClass="btn btn-success" OnClick="btnShowMessage_Click" CausesValidation="false" />
</div>
