<%@ Page Title="Company Management" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="WFFirst.Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <asp:Button ID="btnShowForm" runat="server" CssClass="btn btn-primary mb-3" Text="Add New Company" OnClick="btnShowForm_Click" />
        
        <asp:Panel ID="pnlCompanyList" runat="server">
      <asp:GridView ID="gvCompany" runat="server" CssClass="table table-bordered table-striped"
    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="5"
    OnPageIndexChanging="gvCompany_PageIndexChanging" OnRowEditing="gvCompany_RowEditing"
    OnRowDeleting="gvCompany_RowDeleting" OnSorting="gvCompany_Sorting"
    DataKeyNames="Id">

                
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Company Name" SortExpression="Name" />
                    <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-warning btn-sm me-2"
                                CommandName="Edit" CommandArgument='<%# Eval("Id") %>'>
                                <i class="fas fa-edit"></i> Edit
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm"
                                CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                OnClientClick="return confirm('Are you sure you want to delete this company?');">
                                <i class="fas fa-trash-alt"></i> Delete
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="pnlCompanyForm" runat="server" Visible="False" CssClass="card p-4 shadow-lg">
            <h3 class="mb-3 text-center">Company Form</h3>
            
            <asp:HiddenField ID="hfCompanyId" runat="server" />
            
            <div class="mb-3">
                <label class="form-label">Company Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="Company Name is required."></asp:RequiredFieldValidator>
            </div>
            
            <div class="mb-3">
                <label class="form-label">Fax</label>
                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="Email is required."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="Enter a valid email address."
                    ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$"></asp:RegularExpressionValidator>
            </div>
            
            <div class="text-center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary ms-2" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </asp:Panel>
    </div>

</asp:Content>
