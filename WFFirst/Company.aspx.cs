using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFFirst
{
    public partial class Company : System.Web.UI.Page
    {
        private string connStr = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanies();
            }
        }

        private void LoadCompanies()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Company1 ORDER BY Id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCompany.DataSource = dt;
                gvCompany.DataBind();
            }
        }

        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompany.PageIndex = e.NewPageIndex;
            LoadCompanies();
        }

        protected void gvCompany_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ViewState["CompanyData"] as DataTable;
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvCompany.DataSource = dv;
                gvCompany.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string lastColumn = ViewState["SortColumn"] as string;

            if (lastColumn != null && lastColumn == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if (lastDirection != null && lastDirection == "ASC")
                {
                    sortDirection = "DESC";
                }
            }

            ViewState["SortColumn"] = column;
            ViewState["SortDirection"] = sortDirection;
            return sortDirection;
        }


        protected void gvCompany_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvCompany.DataKeys[e.NewEditIndex].Value);
            LoadCompanyDetails(id);
        }

        private void LoadCompanyDetails(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company1 WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    hfCompanyId.Value = dr["Id"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    txtFax.Text = dr["Fax"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                }

                pnlCompanyList.Visible = false;
                pnlCompanyForm.Visible = true;
            }
        }

        protected void gvCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCompany.DataKeys[e.RowIndex].Value);
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Company1 WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadCompanies();
        }

        protected void btnShowForm_Click(object sender, EventArgs e)
        {
            hfCompanyId.Value = "";
            txtName.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            pnlCompanyList.Visible = false;
            pnlCompanyForm.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlCompanyForm.Visible = false;
            pnlCompanyList.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string query = string.IsNullOrEmpty(hfCompanyId.Value) ?
                        "INSERT INTO Company1 (Name, Fax, Email) VALUES (@Name, @Fax, @Email)" :
                        "UPDATE Company1 SET Name=@Name, Fax=@Fax, Email=@Email WHERE Id=@Id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Fax", txtFax.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    if (!string.IsNullOrEmpty(hfCompanyId.Value))
                    {
                        cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(hfCompanyId.Value));
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                pnlCompanyForm.Visible = false;
                pnlCompanyList.Visible = true;
                LoadCompanies();
            }
        }
    }
}
