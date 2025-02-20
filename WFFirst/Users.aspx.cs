using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFFirst
{
    public partial class Users : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ID, CompanyName, ContactNumber, Fax FROM Company";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = string.IsNullOrEmpty(hfCompanyId.Value) ?
                    "INSERT INTO Company (CompanyName, Email, ContactNumber, Fax) VALUES (@CompanyName, @Email, @ContactNumber, @Fax)" :
                    "UPDATE Company SET CompanyName = @CompanyName, Email = @Email, ContactNumber = @ContactNumber, Fax = @Fax WHERE ID = @CompanyID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim()); // Added Email
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Fax", string.IsNullOrWhiteSpace(txtFax.Text) ? (object)DBNull.Value : txtFax.Text.Trim());

                    if (!string.IsNullOrEmpty(hfCompanyId.Value))
                    {
                        cmd.Parameters.AddWithValue("@CompanyID", hfCompanyId.Value);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            ClearForm();
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string companyId = (row.FindControl("lblCompanyId") as Label).Text;
            string companyName = (row.FindControl("txtCompanyName") as TextBox).Text;
            string email = (row.FindControl("txtEmail") as TextBox).Text;
            string contactNumber = (row.FindControl("txtContactNumber") as TextBox).Text;
            string fax = (row.FindControl("txtFax") as TextBox).Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Company SET CompanyName=@CompanyName, Email=@Email, ContactNumber=@ContactNumber, Fax=@Fax WHERE ID=@CompanyID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CompanyID", companyId);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName.Trim());
                    cmd.Parameters.AddWithValue("@Email", email.Trim()); // Added Email
                    cmd.Parameters.AddWithValue("@ContactNumber", contactNumber.Trim());
                    cmd.Parameters.AddWithValue("@Fax", string.IsNullOrWhiteSpace(fax) ? (object)DBNull.Value : fax.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string companyId = GridView1.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Company WHERE ID=@CompanyID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CompanyID", companyId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            BindGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void ClearForm()
        {
            hfCompanyId.Value = "";
            txtCompanyName.Text = "";
            txtEmail.Text = ""; // Added Email
            txtContactNumber.Text = "";
            txtFax.Text = "";
        }
    }
}
