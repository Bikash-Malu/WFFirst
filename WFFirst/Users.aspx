<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WFFirst.Users" %>

<!DOCTYPE html>
<html>
<head>
    <title>Company Management</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body class="bg-light">
    <div class="container mt-4">
        <h2 class="text-center mb-4">Company Management</h2>
        <form id="form1" runat="server" class="card p-4 shadow-sm">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                    OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowDeleting="GridView1_RowDeleting"
                    DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" />
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="hfCompanyId" runat="server" />
            <div class="row mt-3">
                <div class="col-md-6 mb-3">
                    <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:" CssClass="form-label" />
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label" />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number:" CssClass="form-label" />
                    <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <asp:Label ID="lblFax" runat="server" Text="Fax:" CssClass="form-label" />
                    <asp:TextBox ID="txtFax" runat="server" CssClass="form-control" />
                </div>
                <div class="col-12 text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                </div>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>